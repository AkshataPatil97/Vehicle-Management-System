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
    public partial class Service_CR_frm : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Service_CR_frm()
        {
            InitializeComponent();
        }

        private void Service_CR_frm_Load(object sender, EventArgs e)
        {
            Service("select * from serv_type_tbl",db.cn);

        }
        public void Service(string sql,SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql,con);

            DataSet1 ds = new DataSet1();
            da.Fill(ds,"serv_type_tbl");
            Service_Reports cr = new Service_Reports();
            cr.SetDataSource(ds);
            crystalReportViewer1.ReportSource=cr;


        }
        
    }
}
