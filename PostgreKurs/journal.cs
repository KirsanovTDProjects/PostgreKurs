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
    public partial class journal : Form
    {
      
        public journal()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = String.Format("Server={0};Port={1};" + "User Id={2};Password={3};Database={4};",
            "localhost", "5432", "postgres", "12345", "kurs");
        private string sql = null;
        private DataTable dt;
        private NpgsqlCommand cmd;

        private void journal_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            dvgData.DataSource = null;
            conn.Open();
            sql = "SELECT journal.id, journal.time_out, journal.time_in, auto.num, routes.name FROM auto join journal ON journal.auto_id = auto.id join routes ON routes.id = journal.routes_id";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dvgData.DataSource = dt;
            conn.Close();
        }
    }
}
