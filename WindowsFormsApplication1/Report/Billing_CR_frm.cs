using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.Report
{
    public partial class Billing_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Billing_CR_frm()
        {
            InitializeComponent();
        }

        private void Billing_CR_frm_Load(object sender, EventArgs e)
        {
            Billing("select * from bill_tbl", db.cn);
        }
        public void Billing(string sql, SqlConnection con) 
        {
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds,"bill_tbl");

            Billing_Reports cr = new Billing_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
            

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
