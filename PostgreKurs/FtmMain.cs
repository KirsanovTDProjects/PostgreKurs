
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
    public partial class FtmMain : Form
    {
        public FtmMain()
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
        private void FtmMain_Load(object sender, EventArgs e)
        {            
            conn = new NpgsqlConnection(connstring);
            btnSelect.PerformClick(); 
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dvgData.DataSource = null;
                conn.Open();
                sql = "Select * From st_select()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dvgData.DataSource = dt;

                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ ex.Message,"Error!!!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
              try
            {
              conn.Open();
                sql = @"select * from st_insert( :_num, :_mark, :_color, :_auto_personnel_id)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_num", textNum.Text);
                cmd.Parameters.AddWithValue("_mark", textMark.Text);
                cmd.Parameters.AddWithValue("_color", textColor.Text);
                cmd.Parameters.AddWithValue("_auto_personnel_id", Convert.ToInt32(textAd.Text));

                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                     MessageBox.Show("Авто добавлено", "Отлично!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
             btnSelect.PerformClick();
             textID.Text = textNum.Text = textMark.Text = textColor.Text = textAd.Text = null;
         }
     }
     catch (Exception ex)
     {
         MessageBox.Show("Error: " + ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
         conn.Close();
     }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Выберите авто для изменений", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                conn.Open();
                sql = @"select * from st_update( :_id, :_num, :_mark, :_color )";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                cmd.Parameters.AddWithValue("_num", textNum.Text);
                cmd.Parameters.AddWithValue("_mark", textMark.Text);
                cmd.Parameters.AddWithValue("_color", textColor.Text);
                cmd.Parameters.AddWithValue("_auto_personnel_id", Convert.ToInt32(textAd.Text)); 
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    conn.Close();
                    MessageBox.Show("Информация обновлена", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSelect.PerformClick();
                    textNum.Text = textMark.Text = textColor.Text = textAd.Text = null;
                    r = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
            }

        }

        private void dvgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dvgData.Rows[e.RowIndex];
                textID.Text = r.Cells["_id"].Value.ToString();
                textNum.Text = r.Cells["_num"].Value.ToString();
                textMark.Text = r.Cells["_mark"].Value.ToString();
                textColor.Text = r.Cells["_color"].Value.ToString();
                textAd.Text = r.Cells["_auto_personnel_id"].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Какое авто требует удаления?", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Удалить ["+r.Cells["_auto_personnel_id"].Value.ToString() +"]??",
                "Ожидается решение", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"select * from st_delete(:_id)";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("_id", Convert.ToInt32(r.Cells["_id"].Value.ToString()));
                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("Удалено"," ", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        btnSelect.PerformClick();
                        textNum.Text = textMark.Text = textColor.Text = textAd.Text = null;
                        r = null;
                    }
                        
                }
                catch(Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Error: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        Point lastpoint;
        private void FtmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void FtmMain_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}
