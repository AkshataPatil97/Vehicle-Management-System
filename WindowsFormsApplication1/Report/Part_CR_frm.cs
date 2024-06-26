using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.Report
{
    public partial class Part_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Part_CR_frm()
        {
            InitializeComponent();
        }

        private void Part_CR_frm_Load(object sender, EventArgs e)
        {
            Part("Select * from partsdetail_tbl", db.cn);
        }
        public void Part(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds, "partsdetail_tbl");

            Part_Reports cr = new Part_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;

        }
    }
}
