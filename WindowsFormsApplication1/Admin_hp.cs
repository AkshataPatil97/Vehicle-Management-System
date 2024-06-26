using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.Report;


namespace WindowsFormsApplication1
{
    public partial class Admin_hp : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Admin_hp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Client_detail c = new Client_detail();
            c.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            login obj = new login();
            obj.Show();
        }

        private void Admin_hp_Load(object sender, EventArgs e)
        {

        }

        private void Admin_hp_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            Part_detail s = new Part_detail();
            s.Show();
            
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client_detail cs = new Client_detail();
            cs.Show();
           
           
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_details es = new Employee_details();
            es.Show();
           
        }

        private void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manufacturer_details ms = new Manufacturer_details();
            ms.Show();
          
        }

        private void partDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Part_detail ps = new Part_detail();
            ps.Show();
            
        }

        private void analyticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void billingDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void billDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing bs = new Billing();
            bs.Show();
            
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderDetails os = new OrderDetails();
            os.Show();
            
        }

        private void analyticsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Analytics ss = new Analytics();
            ss.Show();
           
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutUs mm = new AboutUs();
            mm.Show();
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void customerReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client_CR_frm cust = new Client_CR_frm();
            cust.Show();
            
        }

        private void manufacturerRepotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manu_CR_frm manu = new Manu_CR_frm();
            manu.Show();
        }

        private void employeeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_CR_frm emp = new Emp_CR_frm();
            emp.Show();
        }

        private void orderReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_CR_frm ord = new Order_CR_frm();
            ord.Show();
        }

        private void partReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Part_CR_frm par = new Part_CR_frm();
            par.Show();
        }

        private void serviceReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Service_CR_frm ser = new Service_CR_frm();
            ser.Show();
        }

        private void billingReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing_CR_frm bill = new Billing_CR_frm();
            bill.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
