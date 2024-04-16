using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProductFm
{
    public partial class frmManageOrder : Form
    {

        // declare var impact db
        string connectionString = "Server=.\\SQLEXPRESS;Database=Ladada;Integrated Security=True";
        SqlConnection connection;
        SqlCommand cmd;
        SqlParameter param;

        public frmManageOrder()
        {
            InitializeComponent();
        }

        // helper Func
        SqlCommand ExcuteCommand(string sqlQuery)
        {
            cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = connection;
            return cmd;
        }

        void FetchDataOrders(ListBox listBox, string Status_ID)
        {
            //ReFetchOrders();
            string sqlQuery = "select Order_ID, CusName, PhoneNum, Del_Info from Orders where Status_ID = " + Convert.ToString(Status_ID);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                cmd = ExcuteCommand(sqlQuery);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Order_ID = reader.GetString(0);
                        string CusName = reader.GetString(1);
                        string PhoneNum = reader.GetString(2);
                        //string Del_Info = reader.GetString(3);

                        listBox.Items.Add(Order_ID + " - " + CusName + " - " + PhoneNum);
                    }
                }
            }
        }

        void FetchAllOrder()
        {
            FetchDataOrders(lboPending, "2");
            FetchDataOrders(lboApproved, "1");
            FetchDataOrders(lboReject, "0");
        }

        void ReFetchOrders()
        {
            lboApproved.Items.Clear();
            lboPending.Items.Clear();
            lboReject.Items.Clear();
        }

        void UpdateOrderStatus(ListBox listBox, int Status_ID)
        {
            string data = listBox.SelectedItem.ToString();
            string Order_ID = data.Split(new string[] { " - " }, StringSplitOptions.None)[0];
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (cmd = ExcuteCommand("usp_UpdateOrderStatus"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Status_ID", Status_ID);
                        cmd.Parameters.AddWithValue("@Order_ID", Order_ID);
                        int effect = cmd.ExecuteNonQuery();
                    }

                    ReFetchOrders();
                    FetchAllOrder();
                }
                catch (SqlException ex)
                {
                    foreach (SqlError error in ex.Errors)
                    {
                        if (error.Class == 16)
                        {
                            MessageBox.Show("Error: " + error.Message, "Sql Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        // handle frm
        private void frmManageOrder_Load(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    ReFetchOrders();
                    FetchAllOrder();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Form frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lboPending.SelectedItem != null)
            {
                UpdateOrderStatus(lboPending, 1);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục trước khi xác nhận!");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (lboPending.SelectedItem != null)
            {
                UpdateOrderStatus(lboPending, 0);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục trước khi xác nhận!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReFetchOrders();
            FetchAllOrder();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmManageOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
