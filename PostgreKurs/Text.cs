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
    public partial class Text : Form
    {

        public Text(string username)
        {
            this.username = username;
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Rows.Add("Автомобилисты");
            dt.Rows.Add("Journal");
            dt.Rows.Add("Место назначения (Улицы)");
            dt.Rows.Add("Авто");
            dt.Rows.Add("Число пользователей");
            DataRow dr = dt.NewRow();
            dr["Title"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Title";
            comboBox1.ValueMember = "Title";
        }

        private string username;
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};",
            "localhost", "5432", "postgres", "12345", "kurs");
        private DataTable dt;
        private NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedValue.ToString() == "Авто")
            {
                if (Application.OpenForms.OfType<FtmMain>().Count() == 1)
                    Application.OpenForms.OfType<FtmMain>().First().Close();
                FtmMain frm = new FtmMain();
                frm.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Автомобилисты")
            {
                if (Application.OpenForms.OfType<auto_personel>().Count() == 1)
                    Application.OpenForms.OfType<auto_personel>().First().Close();
                auto_personel frm = new auto_personel();
                frm.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Journal")
            {
                if (Application.OpenForms.OfType<journal>().Count() == 1)
                    Application.OpenForms.OfType<journal>().First().Close();
                journal frm = new journal();
                frm.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Место назначения (Улицы)")
            {
                if (Application.OpenForms.OfType<routes>().Count() == 1)
                    Application.OpenForms.OfType<routes>().First().Close();
                routes frm = new routes();
                frm.Show();
            }
            else if (comboBox1.SelectedValue.ToString() == "Число пользователей")
            {
                if (Application.OpenForms.OfType<users>().Count() == 1)
                    Application.OpenForms.OfType<users>().First().Close();
                users frm = new users();
                frm.Show();
            }
        }

        private void Glavnaya_Load(object sender, EventArgs e)
        {
            lblUser.Text = lblUser.Text + username;
            conn = new NpgsqlConnection(connstring);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //формирование отчёта
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            var cmd = new NpgsqlCommand("SELECT db_to_csv('C:/DataKeeper');", conn);//(необходимо чтобы на диске С была папка datasklad)
            var reader = cmd.ExecuteReader();
            conn.Close();
        }

        Point lastpoint;
        private void Glavnaya_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;

            }
        }

        private void Glavnaya_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }
    }
}
