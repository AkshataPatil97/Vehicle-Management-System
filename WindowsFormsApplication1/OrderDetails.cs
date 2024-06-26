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
    public partial class OrderDetails : Form
    {
        dbcodeclass db = new dbcodeclass();
        public OrderDetails()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Manufacturer_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from orderdetails_tbl");
            db.FillCombo(cmbPartName,"select * from partsdetail_tbl","Part_Name","Part_Id");
            db.FillCombo(cmbManuName,"select * from manu_tbl","manu_name","manu_id");
            EnabledFalse();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMaxID();
            cmbManuName.Enabled = true;
        }
        void GetMaxID()
        {
            txtOrderID.Text = db.GetAutoID("select MAX(order_id) from orderdetails_tbl").ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtManuID.Text=="" || txtOrderID.Text==""||cmbManuName.Text=="")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("delete from order_LV_tbl where order_id="+txtOrderID.Text);
                db.ExecuteSqlQuery("Delete from orderdetails_tbl Where order_id =" + txtOrderID.Text);
            }
            db.FillGridData(dataGridView1, "Select * from orderdetails_tbl");

            cleardata();
            MessageBox.Show("Delete Data sucessfully..");
        }
        private void GriddataDisk1()
        {
            try
            {
                txtOrderID.Text = dataGridView1.SelectedRows[0].Cells["order_id"].Value.ToString();
              //  txtPartId.Text = dataGridView1.SelectedRows[0].Cells["part_id"].Value.ToString();
              //  cmbPartName.Text = dataGridView1.SelectedRows[0].Cells["part_name"].Value.ToString();
               txtManuID.Text = dataGridView1.SelectedRows[0].Cells["manu_id"].Value.ToString();
                cmbManuName.Text = dataGridView1.SelectedRows[0].Cells["manu_name"].Value.ToString();
                
             //   txtQuantity.Text= dataGridView1.SelectedRows[0].Cells["quantity"].Value.ToString();
                dtpOrder.Value = DateTime.Parse(dataGridView1.SelectedRows[0].Cells["date"].Value.ToString());
                



                //EnabledFalse();
               
                btnDelete.Enabled = true;
                btnNew.Enabled = false;


            }
            catch { }
        }
       
     void cleardata()
        {
            txtPartId.Text = "";
           // txtOrderID.Text = "";
           
            txtQuantity.Text = "";
            cmbPartName.Text = "";
            
        }

        void EnabledFalse()
        {
            btnSave.Enabled = true;
           
        }
        

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GriddataDisk1();
        }

        private void cmbPartName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPartId.Text = cmbPartName.SelectedValue.ToString();
            cmbManuName.Enabled = false;
        }

        private void cmbManuName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbManuName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtManuID.Text = cmbManuName.SelectedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "" || txtOrderID.Text == "" || txtManuID.Text == "")
            {
                MessageBox.Show("All fields are mandotary!");
            }
            if(txtQuantity.Text != "")
            {
                try
                {
                    listView1.Items.Add(txtPartId.Text).SubItems.AddRange(new string[] { cmbPartName.Text, txtQuantity.Text });

                }
                catch { }
                cleardata();
                TotQty();


                cmbManuName.Enabled = false;
                // DiscTotamt();
                // Clearitemsdata();

                if (MessageBox.Show("Do you want add another products ?", "Add Products", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    cmbPartName.Focus();

                }
                else
                {
                    cmbPartName.Enabled = false;
                    btnSave.Enabled = true;
                    btnAdd.Enabled = false;
                    btnSave.Focus();
                }
            }
                
        }
        void TotQty()
        {
            double sum = 0;
            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sum += double.Parse(listView1.Items[i].SubItems[2].Text);
                }
            }
            catch { }
            txtTotQuant.Text = sum.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (txtOrderID.Text !="" && cmbManuName.Text!="" && txtTotQuant.Text!="")
                {

                    db.ExecuteSqlQuery("insert into orderdetails_tbl(order_id,manu_name,manu_id,quantity,order_date)values('" + txtOrderID.Text + "','" + cmbManuName.Text + "','" + txtManuID.Text + "','" + txtTotQuant.Text + "','" + dtpOrder.Value.ToString("MM/dd/yyyy") + "')");
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        db.ExecuteSqlQuery("insert into order_LV_tbl( order_id,manu_id,part_id,part_name,quantity)values('" + txtOrderID.Text + "','" + txtManuID.Text + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + listView1.Items[i].SubItems[2].Text + "')");
                        listView1.Items.Clear();
                        db.FillGridData(dataGridView1, "select * from orderdetails_tbl");
                        cleardata();
                    }
                    MessageBox.Show("Record Saved Successfully...");
                    return;
                    
                    
                    //cleardata();
                  
                  
                }            
                else
                {
                    MessageBox.Show("Please Fill All Info...");
                    return;
                }

               

            }
            catch { }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtPartId.Text = listView1.SelectedItems[0].SubItems[0].Text;
                cmbPartName.Text = listView1.SelectedItems[1].SubItems[0].Text;
                txtQuantity.Text = listView1.SelectedItems[2].SubItems[0].Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
             listView1.SelectedItems[0].SubItems[0].Text=txtPartId.Text;
             listView1.SelectedItems[1].SubItems[0].Text=cmbPartName.Text;
             listView1.SelectedItems[2].SubItems[0].Text=txtQuantity.Text;
            
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuantity.Text) == true)
            {
                errorQuant.SetError(this.txtQuantity, "This is a required field!!");
            }
            else
            {
                errorQuant.Clear();
            }
        }

        private void dtpOrder_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            EnabledFalse();
            cleardata();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove Item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                
            }
        }

        private void txtTotQuant_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dtpOrder_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
