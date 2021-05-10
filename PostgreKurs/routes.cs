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
    public partial class routes : Form
    {
        public routes()
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

        private void routes_Load(object sender, EventArgs e)
        {
            dvgData.BackgroundColor = System.Drawing.SystemColors.Control;
            conn = new NpgsqlConnection(connstring);
            btnSelect.PerformClick();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dvgData.DataSource = null;
                conn.Open();
                sql = "Select * From st_select_r()";
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
                sql = @"select * from st_insert_r(:_name)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_name", textName.Text);
                

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Значение включено", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textName.Text = null;
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
                MessageBox.Show("Выберите для обновления", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update_r( :_id, :_name)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                cmd.Parameters.AddWithValue("_name", textName.Text);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Информация обновлена", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textName.Text  = null;
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
                textName.Text = r.Cells["_name"].Value.ToString();
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите для удаления", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить [" + r.Cells["_name"].Value.ToString() + "]??",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from st_delete_r(:_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("Удалено успешно", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSelect.PerformClick();
                        textName.Text  = null;
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
        Point lastpoint;
        private void routes_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void routes_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;


            }
        }
    }
}
