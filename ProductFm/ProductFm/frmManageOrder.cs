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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmManageOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        SqlCommand ExcuteCommand(string sqlQuery)
        {
            cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = connection;
            return cmd;
        }
        private void frmManageOrder_Load(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(connectionString))
            { 
            try
                {
                    connection.Open();
                    string sqlQuery = "select Order_ID, CusName from Orders where Status_ID = 2";
                    cmd = ExcuteCommand(sqlQuery);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Order_ID = reader.GetString(0); 
                            string CusName = reader.GetString(1); 

                            lboPending.Items.Add(Order_ID + " - " + CusName);
                        }
                    }

                }
                catch (Exception ex) {
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
    }
}
