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
    public partial class Manu_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Manu_CR_frm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Manufacturer("Select * from manu_tbl", db.cn);
        }
        public void Manufacturer(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds, "manu_tbl");

            Manu_Reports cr = new Manu_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
