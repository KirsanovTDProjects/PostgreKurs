using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace PostgreKurs
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};",
            "localhost", "5432", "postgres", "12345", "kurs");
        private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        private void users_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dvgData.DataSource = null;
                conn.Open();
                sql = "Select * From st_select_u()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dvgData.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * from st_insert_u(:_username, :_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_username", textUser.Text);
                cmd.Parameters.AddWithValue("_password", textPassword.Text);              

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Пользователь добавлен", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textUser.Text = textPassword.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите для изменения", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update_u( :_id, :_username, :_password)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                cmd.Parameters.AddWithValue("_username", textUser.Text);
                cmd.Parameters.AddWithValue("_password", textPassword.Text);

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Информация обновлена", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textUser.Text = textPassword.Text = null;
                    r = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Ошибка обновления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void dvgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dvgData.Rows[e.RowIndex];
                textID.Text = r.Cells["_id"].Value.ToString();
                textUser.Text = r.Cells["_username"].Value.ToString();
                textPassword.Text = r.Cells["_password"].Value.ToString();
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите для удаления", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Удалить[" + r.Cells["_password"].Value.ToString() + "]??",
                "Подтвердить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from st_delete_u(:_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("Удалено", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSelect.PerformClick();
                        textUser.Text = textPassword.Text = null;
                        r = null;
                    }

                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Error: " + ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}


