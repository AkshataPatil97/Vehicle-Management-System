using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Service_Type : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Service_Type()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Extra_Service_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from serv_type_tbl");
            btnADD.Enabled = false;
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMaxID();
            btnADD.Enabled = true;
        }
        public void GetMaxID()
        {
            txtServiceID.Text = db.GetAutoID("select MAX(Serv_Id) from serv_type_tbl").ToString();
            btnADD.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtServiceID.Text == "" && txtServName.Text == "" && txtRate.Text=="")
            {
                MessageBox.Show("All fields are mandatory!");
            }
            else if (txtServiceID.Text != "" && txtServName.Text != "" && txtRate.Text != "")
            {
                db.ExecuteSqlQuery("Insert into serv_type_tbl( Serv_Id, Serv_Type, Serv_Rate) values('" + txtServiceID.Text + "','" + txtServName.Text + "','" + txtRate.Text + "')");
                db.FillGridData(dataGridView1, "Select * from serv_type_tbl");

                cleardata();
              
                MessageBox.Show("Save Data sucessfully..");
            }
        }
        void cleardata()
        {
            txtRate.Text = "";
            txtServiceID.Text = "";
            txtServName.Text = "";
        
        }

       private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        private void GriddataDisk1()
        {
            try
            {
                txtServiceID.Text = dataGridView1.SelectedRows[0].Cells["Serv_Id"].Value.ToString();
                txtServName.Text = dataGridView1.SelectedRows[0].Cells["Serv_Type"].Value.ToString();
                txtRate.Text = dataGridView1.SelectedRows[0].Cells["Serv_Rate"].Value.ToString();
            }
            catch { }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GriddataDisk1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Update")
            {
                if (MessageBox.Show("Do you want update record ?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.ExecuteSqlQuery("Update serv_type_tbl SET Serv_Type ='" + txtServName.Text + "', Serv_Rate ='" + txtRate.Text + "' where  Serv_Id =" + txtServiceID.Text);
                    MessageBox.Show(" Data Updated  sucessfully..");
                    cleardata();
                }
                db.FillGridData(dataGridView1, "Select * from serv_type_tbl");
            }
            else if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Delete")
            {

                if (MessageBox.Show("Do you want delete record ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.ExecuteSqlQuery("Delete from serv_type_tbl where Serv_Id=" + txtServiceID.Text);
                    MessageBox.Show("Data Deleted sucessfully..");
                    cleardata();
                }
                db.FillGridData(dataGridView1, "Select * from serv_type_tbl");
            }
        }

        private void txtServName_KeyPress(object sender, KeyPressEventArgs e)
        {

           
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtServName_Validating(object sender, CancelEventArgs e)
        {
            if (txtServName.Text == "")
            {
                errorServ_Name.SetError(this.txtServName, "It is a required field!");
            }
            else 
            {
                errorServ_Name.Clear();
            }
        }

        private void txtRate_Validating(object sender, CancelEventArgs e)
        {
            if (txtRate.Text == "")
            {
                errorRate.SetError(this.txtRate, "It is a required field!");
            }
            else
            {
                errorRate.Clear();
            }
        }
    }
}
