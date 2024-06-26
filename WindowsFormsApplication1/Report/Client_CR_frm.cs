using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace WindowsFormsApplication1.Report
{
    public partial class Client_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Client_CR_frm()
        {
            InitializeComponent();
        }

        private void Client_CR_frm_Load(object sender, EventArgs e)
        {
            Customer("Select * from client_tbl ", db.cn);
        }
        public void Customer(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds, "client_tbl");

            Client_Reports cr = new Client_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;

        }
    }
}
