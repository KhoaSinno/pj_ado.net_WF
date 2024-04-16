using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductFm
{
    public partial class FmProduct : Form
    {
        // declare var global
        string titleForm;
        string user_ID;

        // declare var impact db
        string connectionString = "Server=.\\SQLEXPRESS;Database=Ladada;Integrated Security=True";
        SqlConnection connection;
        SqlCommand cmd;
        SqlParameter param;

        // constructor
        public FmProduct()
        {
            InitializeComponent();
        }

        public FmProduct(string name, string user_ID) : this()
        {
            this.titleForm = name;
            this.user_ID = user_ID;
        }


        // default func
        void Clear_FormData()
        {
            txtDChi.Text = "";
            txtHoten.Text = "";
            txtReciever.Text = "";
            txtSdt.Text = "";
            cboQuan_Huyen.SelectedIndex = 0;
        }

        // validate
        bool IsEmptyData()
        {
           return string.IsNullOrWhiteSpace(txtDChi.Text) ||
           string.IsNullOrWhiteSpace(txtHoten.Text) ||
           string.IsNullOrWhiteSpace(txtSdt.Text);

        }

        // form load
        private void FmProduct_Load(object sender, EventArgs e)
        {
            //default value
            this.Text  = titleForm + " - Delivery Form";
            btnSave.Enabled = false;

            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                //string sql = "select * from Quan Order By Quan";
                //cmd = new SqlCommand();
                //cmd.CommandText = sql;
                //cmd.Connection = connection;

                cmd = ExcuteCommand("sp_GetQuan");
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    cboQuan_Huyen.Items.Clear();
                    clsQuan quan;
                while (dr.Read())
                {
                        quan = new clsQuan();
                        quan.Quan_ID = Convert.ToInt32(dr["Quan_ID"]);
                        quan.Quan = dr["Quan"].ToString();
                        cboQuan_Huyen.Items.Add(quan);
                }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            cboQuan_Huyen.DisplayMember = "Quan";
            cboQuan_Huyen.ValueMember = "Quan_ID";
            cboQuan_Huyen.SelectedIndex = 0;
        }

        // helper function
        SqlCommand ExcuteCommand(string sqlQuery)
        {
            cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = connection;
            return cmd;
        }

        public SqlParameter CreateParameter(string name, SqlDbType dbType, object value, int? size = null)
        {
            var parameter = new SqlParameter
            {
                ParameterName = name,
                SqlDbType = dbType,
                Value = value
            };

            if (size.HasValue)
            {
                parameter.Size = size.Value;
            }

            return parameter;
        }

        // handle logic
        private void cboQuan_Huyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboPhuong_Xa.Items.Clear();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                clsQuan quan = (clsQuan)cboQuan_Huyen.SelectedItem;
                //MessageBox.Show(quan.Quan_ID.ToString() + "\n" + quan.Quan);

                //Raw
                //string sql = "select * from Phuong where Quan_ID = @Quan_ID Order By Phuong";
                //cmd = new SqlCommand();
                //cmd.CommandText = sql;
                //cmd.Connection = connection;

                // Optimized 
                cmd = ExcuteCommand("select * from Phuong where Quan_ID = @Quan_ID Order By Phuong");


                //param = new SqlParameter();
                //param.SqlDbType = SqlDbType.Int;
                //param.ParameterName = "@Quan_ID";
                //param.Value = quan.Quan_ID;

                param = CreateParameter("@Quan_ID", SqlDbType.Int, quan.Quan_ID);
                cmd.Parameters.Add(param);
                //cmd.Parameters.AddWithValue("@Quan_ID", quan.Quan_ID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        cboPhuong_Xa.Items.Add(dr["Phuong"]);
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            if (cboQuan_Huyen.Items.Count > 0 && cboPhuong_Xa.Items.Count > 0)
            {
                cboPhuong_Xa.Enabled = true;
                cboPhuong_Xa.SelectedIndex = 0;
            } else
            {
                cboPhuong_Xa.Enabled = false;
            }

        }

        private void assign_txtReciever(string order_ID)
        {
            string Hoten = txtHoten.Text;
            string Sdt = txtSdt.Text;
            string DChi = txtDChi.Text;
            string Quan_Huyen = cboQuan_Huyen.Text;
            string Phuong_Xa = cboPhuong_Xa.Text;

            txtReciever.Text = $"Mã đơn hàng: {order_ID}{Environment.NewLine}" + $"Mã khách hàng: {user_ID}{Environment.NewLine}" + $"Họ tên: {Hoten}{Environment.NewLine}" +
                $"Số điện thoại: {Sdt}{Environment.NewLine}" +
                $"Địa chỉ: {DChi}{Environment.NewLine}" +
                $"QuậnHuyện: {Quan_Huyen}{Environment.NewLine}" +
                $"Phường/Xã: {Phuong_Xa} {Environment.NewLine}";
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                

                connection.Open();
                // insert data into db
                clsQuan quan = (clsQuan)cboQuan_Huyen.SelectedItem;

                string sql = "INSERT INTO Orders(Order_ID, CusName, PhoneNum, Del_info, User_ID, Status_ID) VALUES(@Order_ID, @CusName, @PhoneNum, @Del_info, @User_ID, @Status_ID)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                string randomID_order = 'D' + RandomIDGenerator.GenerateRandomID(5);
                //string randomID_cus = 'K' + RandomIDGenerator.GenerateRandomID(5);

                cmd.Parameters.AddWithValue("@Order_ID", randomID_order);
                cmd.Parameters.AddWithValue("@CusName",  txtHoten.Text.Trim());
                cmd.Parameters.AddWithValue("@PhoneNum", txtSdt.Text.Trim());
                cmd.Parameters.AddWithValue("@Del_info", txtDChi.Text.Trim());
                cmd.Parameters.AddWithValue("@User_ID", user_ID);
                cmd.Parameters.AddWithValue("@Status_ID", 2);

                cmd.ExecuteNonQuery();

                // assign to textBox reciever
                assign_txtReciever(randomID_order);

                MessageBox.Show("Thêm đơn hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                connection.Close();
                // clear data
                string prevData = txtReciever.Text;
                Clear_FormData();
                txtReciever.Text = prevData;
            }
        }

        private void txtDChi_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmptyData())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmptyData())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmptyData())
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FmProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void llbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Form frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
}
