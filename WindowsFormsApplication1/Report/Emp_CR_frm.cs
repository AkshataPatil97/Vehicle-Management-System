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
    public partial class Emp_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Emp_CR_frm()
        {
            InitializeComponent();
        }

        private void Emp_CR_frm_Load(object sender, EventArgs e)
        {
            Employee("Select * from emp_tbl", db.cn);
        }
        public void Employee(string sql, SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds, "emp_tbl");

            Emp_Reports cr = new Emp_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
