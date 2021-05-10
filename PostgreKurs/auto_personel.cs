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
    public partial class auto_personel : Form
    {
        public auto_personel()
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


        private void auto_personel_Load(object sender, EventArgs e)
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
                sql = "Select * From st_select_a_p()";
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
                sql = @"select * from st_insert_a_p(:_fist_name, :_last_name, :_pather_name)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_fist_name", textFistName.Text);
                cmd.Parameters.AddWithValue("_last_name", textLastName.Text);
                cmd.Parameters.AddWithValue("_pather_name", textPatherName.Text);                
                
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Сотрудник добавлен", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textFistName.Text = textLastName.Text = textPatherName.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Добавление не произошло", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update_a_p( :_id, :_fist_name, :_last_name, :_pather_name)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                cmd.Parameters.AddWithValue("_fist_name", textFistName.Text);
                cmd.Parameters.AddWithValue("_last_name", textLastName.Text);
                cmd.Parameters.AddWithValue("_pather_name", textPatherName.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Информация обновлена", "Всё хорошо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textFistName.Text = textLastName.Text = textPatherName.Text = null;
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
                textFistName.Text = r.Cells["_fist_name"].Value.ToString();
                textLastName.Text = r.Cells["_last_name"].Value.ToString();
                textPatherName.Text = r.Cells["_pather_name"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Удалить [" + r.Cells["_pather_name"].Value.ToString() + "]??",
                "confirf delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from st_delete_a_p(:_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("Завершение удаления.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSelect.PerformClick();
                        textFistName.Text = textLastName.Text = textPatherName.Text = null;
                        r = null;
                    }

                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Error: " + ex.Message, "Ошибка при удалении.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
