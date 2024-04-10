using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductFm
{
    public partial class frmLogin : Form
    {

        string connectionString = "Server=.\\SQLEXPRESS;Database=Ladada;Integrated Security=True";
        SqlConnection connection;
        SqlCommand cmd;
        SqlParameter param;

        // start form
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // validate 

        public bool ValidateCredentials(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false; 
            }
            if (username.Length < 3 || password.Length < 4)
            {
                return false; 
            }

            return true; 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (!ValidateCredentials(username, password))
            {
                MessageBox.Show("Phải nhập đúng định dạng tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (cmd = new SqlCommand("AuthenticateUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputUsername", username);
                        cmd.Parameters.AddWithValue("@inputPassword", password);

                        // return a string message
                        string userId = (string)cmd.ExecuteScalar();

                        if(userId != "-1")
                        {
                            this.Hide();
                            //MessageBox.Show("Xác thực thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            using ( cmd= new SqlCommand("usp_GetUserRoles", connection))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Thêm tham số cho câu truy vấn
                                cmd.Parameters.AddWithValue("@User_ID", userId);

                                // Tạo đối tượng SqlDataAdapter
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                                // Tạo đối tượng DataTable để chứa kết quả
                                DataTable dataTable = new DataTable();

                                // Đổ dữ liệu từ SqlDataAdapter vào DataTable
                                adapter.Fill(dataTable);

                                string message = "";

                                string userID = dataTable.Rows[0]["User_ID"].ToString();
                                string roleName = dataTable.Rows[0]["RoleName"].ToString();
                                string roleID = dataTable.Rows[0]["Role_ID"].ToString();

                                if(roleID == "0")
                                {
                                    Form frmManageOrder = new frmManageOrder();
                                    frmManageOrder.Show();
                                }
                                else if (roleID == "1")
                                {
                                    Form frmDeliveryInfo = new FmProduct(txtUsername.Text);
                                    frmDeliveryInfo.Show();
                                }

                                message = $"User ID: {userID}, Role Name: {roleName}, Role ID: {roleID}{Environment.NewLine}";
                                MessageBox.Show(message, "User Roles");

                            }


                            
                            
                        } else
                        {
                            MessageBox.Show("Lỗi xác thực!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form frmRegister = new frmRegister();
            frmRegister.Show();
        }
    }
}
