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
    public partial class Part_detail : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Part_detail()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
           GetMaxID();
           btnSubmit.Enabled = true; 
        }
            
        public void GetMaxID()
        {
            txtPartId.Text = db.GetAutoID("Select MAX(Part_Id) from partsdetail_tbl").ToString();
        }
        void cleardata()
        {
            txtPartId.Text="";
            txtQuantity.Text="";
            txtPartName.Text="";
            txtPrice.Text="";
            comboManu.Text = "";
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPartId.Text == "" && txtPartName.Text == "" && txtPrice.Text=="" && txtQuantity.Text=="")
            {
                MessageBox.Show("All Fields are compulsory");
            }
            if (txtPartId.Text != "" && txtPartName.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                db.ExecuteSqlQuery("Update partsdetail_tbl SET Quantity= '" + txtQuantity.Text + "', Part_Name= '" + txtPartName.Text + "', Price= '" + txtPrice.Text + "', Manufacturer= '" + comboManu.ToString() + "', DoP= '" + dtp_DateOfPurchase.Value.ToString("MM/dd/yyyy") + "' Where Part_Id=" + txtPartId.Text);
                db.FillGridData(dataGridView1, "Select * from partsdetail_tbl");
                MessageBox.Show("Data Updated Successfully!");
            }
            


        }   

        void EnabledFalse()
        {
           // btnNew.Enabled = false;
            btnSubmit.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtPartName.Text == "" || txtPartId.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            if (txtPartId.Text != "" && txtPartName.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                db.ExecuteSqlQuery("Insert into partsdetail_tbl( Part_Id, Quantity, Part_Name, Price, Manufacturer,DoP) values('" + txtPartId.Text + "','" + txtQuantity.Text + "','" + txtPartName.Text + "','" + txtPrice.Text + "','" + comboManu.Text.ToString() + "','" + dtp_DateOfPurchase.Value.ToString("MM/dd/yyyy") + "') ");
                db.FillGridData(dataGridView1, "Select * from partsdetail_tbl");

                cleardata();
                MessageBox.Show("Save Data sucessfully..");
            }
        }

        private void Stock_detail_Load(object sender, EventArgs e)
        {
            
            btnNew.Focus();
            EnabledFalse();
            db.FillGridData(dataGridView1, "Select * from partsdetail_tbl");
            db.FillCombo(comboManu,"select * from manu_tbl","manu_name","manu_id");
        }

        

        private void dataGriddisk()
        {
            try
            {
                txtPartId.Text = dataGridView1.SelectedRows[0].Cells["Part_Id"].Value.ToString();
                txtQuantity.Text = dataGridView1.SelectedRows[0].Cells["Quantity"].Value.ToString();
                txtPartName.Text = dataGridView1.SelectedRows[0].Cells["Part_Name"].Value.ToString();
                txtPrice.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
                comboManu.Text = dataGridView1.SelectedRows[0].Cells["Manufacturer"].Value.ToString();
                dtp_DateOfPurchase.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["DoP"].Value.ToString());
                
                EnabledFalse();
                btnNew.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSubmit.Enabled = false;

            }
            catch { }

        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGriddisk();
         }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPartId.Text == "" && txtPartName.Text == "" && txtPrice.Text == "" && txtQuantity.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("Delete from partsdetail_tbl Where Part_Id =" + txtPartId.Text);
            }
            db.FillGridData(dataGridView1, "Select * from partsdetail_tbl");
            
            cleardata();           
            MessageBox.Show("Delete Data sucessfully..");
        }

        private void comboManu_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lblmanu_ID.Text = comboManu.SelectedValue.ToString();

            DataTable dt = db.GettableData("Select * from manu_tbl where manu_id=" + lblmanu_ID.Text);
                       
        }

        private void txtPartId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

      

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EnabledFalse();
            cleardata();
        }

    }
}
