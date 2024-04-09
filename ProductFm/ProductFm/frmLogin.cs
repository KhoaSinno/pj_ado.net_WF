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
                        int result = (int)cmd.ExecuteScalar();

                        if(result == 1)
                        {
                            this.Hide();
                            Form frmDeliveryInfo = new FmProduct(txtUsername.Text);
                            frmDeliveryInfo.Show();
                            MessageBox.Show("Xác thực thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
