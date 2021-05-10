using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreKurs
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};", 
            "localhost", "5432", "postgres", "12345", "kurs");
       // private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {           

            try
            {
                conn.Open();
                sql = @"select * from u_login(:_username,:_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_username",txtUsername.Text);
                cmd.Parameters.AddWithValue("_password",txtPassword.Text);

                int result = (int)cmd.ExecuteScalar();
                
                conn.Close();
                if (result == 1)
                {
                       this.Hide();
                       new Text(txtUsername.Text).Show();
                } else
                {
                    MessageBox.Show("Необходимо перепроверить данные ", " ",
                       MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Что-то не так", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }
        Point lastpoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;


            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X,e.Y);
        }
    }
}
