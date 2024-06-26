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
    public partial class Billing : Form
    {
        dbcodeclass db = new dbcodeclass();
        public Billing()
        {
            InitializeComponent();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            db.FillCombo(cmbPartName,"select * from partsdetail_tbl","Part_Name","Part_Id");
            db.FillCombo(cmbServices,"select * from serv_type_tbl","Serv_Type","Serv_Id");
            cleardata();
            GrossTotalPart();  
            EnabledFalse();

        }
        void EnabledFalse()
        {
            btnAdd.Enabled = false;
            cmbPartName.Enabled = false;
            btnSave.Enabled = false;
            
          
        
        }
        private void txtCustID_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = db.GettableData("select * from client_tbl where Client_Id=" + txtCustID.Text);
            if (dt.Rows.Count >= 1)
            {
                txtCustName.Text = dt.Rows[0]["First_Name"].ToString();
                txtContact.Text = dt.Rows[0]["Mobile_No"].ToString();
                btnAdd.Enabled = true;
            }
            else 
            {
                MessageBox.Show("User Does not Exists!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetMaxID();
        }

        void GetMaxID()
        {
            txtBillId.Text = db.GetAutoID("select MAX(Bill_Id) from bill_tbl").ToString(); 

        }

        private void cmbService_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
       
    
        private void Quantity_TextChanged(object sender, EventArgs e)
        {
             if (cmbPartName.SelectedIndex >= 0)
            {
                txtTotal.Text = (double.Parse(txtQuant.Text) * double.Parse(txtPrice.Text)).ToString();
            }
            
        }

     
        private void cmbPartName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtPartId.Text = cmbPartName.SelectedValue.ToString();

            DataTable dt = db.GettableData("Select * from partsdetail_tbl where Part_Id=" + txtPartId.Text);
            if (dt.Rows.Count >= 1)
            {
                txtQuant.Text = "";
                txtPrice.Text = dt.Rows[0]["Price"].ToString();
                txtAvailQty.Text = dt.Rows[0]["Quantity"].ToString();
            }
        }

        void cleardata()
        {
            txtPartId.Text = "";
            txtTotAmt.Text = "";
            txtPrice.Text = "";
            txtQuant.Text = "";
         
            txtTotal.Text = "";


        }

    


        private void txtQuant_ValueChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (double.Parse(txtPrice.Text) * double.Parse(txtQuant.ToString())).ToString();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                 if (txtPartId.Text != ""&&txtPrice.Text!="")
                {
                     int qty =Convert.ToInt32( txtQuant.Text);
                     int availqty=Convert.ToInt32(txtAvailQty.Text);
                     if (qty <= availqty)
                     {
                         listView1.Items.Add(txtPartId.Text).SubItems.AddRange(new string[] { cmbPartName.Text, txtPrice.Text, txtQuant.Text, txtTotal.Text });

                         txtQuant.Text = "";
                         txtPartId.Text = "";
                         txtPrice.Text = "";
                         btnRemove.Enabled = true;
                         errorAvailQty.Clear();
                     }
                     else
                     {
                         errorAvailQty.SetError(this.txtAvailQty, "Available stock is less!");
                         txtQuant.Text = "";
                         txtPartId.Text = "";
                         txtPrice.Text = "";
                     }
                }
                else if(lblservices.Text!=""&&txtRate.Text!="")
                {
                    listView2.Items.Add(lblservices.Text).SubItems.AddRange(new string[] { cmbServices.Text, txtRate.Text });

                    txtRate.Text = "";
                    lblservices.Text = "";
                    cmbServices.Text = "";
                    btnRemove.Enabled = true;
                }
                   
                   
                
            }
            catch { }

            GrossTotalPart();


            if (MessageBox.Show("Do you want add another products ?", "Add Products", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                cmbPartName.Enabled = true;
                txtPartId.Focus();
                cmbServices.Enabled = false;

            }
            else if(MessageBox.Show("Do you want add another services ?","Add Services",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
            {
                cmbServices.Enabled = true;
                cmbPartName.Enabled = false;

            }
            else
            {
             btnAdd.Enabled = false;
            
             
            }
        }

        void GrossTotalPart()
        {
            double sum = 0,sumPart=0,sumServ=0;

            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    sumPart += double.Parse(listView1.Items[i].SubItems[4].Text);
                }
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    sumServ += double.Parse(listView2.Items[i].SubItems[2].Text);
                }

            }
            catch { }

            sum = sumPart + sumServ;

            txtGrossAmt.Text = sum.ToString();
        }
        void GrossTotalServices()
        {
            double sum = 0;

            try
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    sum += double.Parse(listView2.Items[i].SubItems[4].Text);
                }
            }
            catch { }

            txtGrossAmt.Text = sum.ToString();
        }

       /* private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove Item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    if (listView2.SelectedItems.Count > 0)
                    {

                        listView2.Items.RemoveAt(listView2.SelectedIndices[0]);
                    }
                }

            }
        }*/

        


       

      


        private void cmbDisc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DISCALC();
        }

        double V_Discount = 0, V_DiscAmt = 0, V_GrossAmt=0 ,V_DnetAmt=0;
         void DISCALC()
        {
            V_DnetAmt = double.Parse(txtGrossAmt.Text);
            V_Discount = double.Parse(cmbDisc.Text);

             if (cmbDisc.SelectedIndex >= 0)
             {
                 V_DiscAmt = (V_DnetAmt * V_Discount) / 100;
                 V_GrossAmt = V_DnetAmt - V_DiscAmt;
             }
             txtTotAmt.Text = V_GrossAmt.ToString();
             txtDiscAmt.Text = V_DiscAmt.ToString();
        }

        

         private void btnSave_Click_1(object sender, EventArgs e)
         {
             if (txtBillId.Text != "" ||txtCustID.Text!=""||txtTotAmt.Text!=""||txtPaidAmt.Text!="")
             {
                 try
                 {
                     db.ExecuteSqlQuery("insert into bill_tbl (Bill_Id,Cust_Id,Cust_Name,Contact,DOI,Gross_Amt,Disc_Amt,TOT_Amt,Paid_Amt,Remaining_Amt)values('" + txtBillId.Text + "','" + txtCustID.Text + "','" + txtCustName.Text + "','" + txtContact.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + txtGrossAmt.Text + "','" + txtDiscAmt.Text + "','" + txtTotAmt.Text + "','" + txtPaidAmt.Text + "','" + txtRemaining.Text + "')");

                     


                     for (int i = 0; i < listView1.Items.Count; i++)
                     {
                         db.ExecuteSqlQuery("insert into bill_LV_tbl (Bill_Id,Item_Id,Item_Name,Quantity,Price,Total)values('" + txtBillId.Text + "','" + listView1.Items[i].SubItems[0].Text + "','" + listView1.Items[i].SubItems[1].Text + "','" + listView1.Items[i].SubItems[3].Text + "','" + listView1.Items[i].SubItems[2].Text + "','" + listView1.Items[i].SubItems[4].Text + "')");
                         
                         db.ExecuteSqlQuery("update partsdetail_tbl set Quantity=Quantity-'" + listView1.Items[i].SubItems[3].Text + "'where Part_Id=" + listView1.Items[i].SubItems[0].Text);

                     }

                     for (int i = 0; i < listView2.Items.Count;i++ )
                     {
                         db.ExecuteSqlQuery("insert into bill_LV2_tbl(Bill_Id,Serv_Id,Serv_Name,Rate)values('" + txtBillId.Text + "','" + listView2.Items[i].SubItems[0].Text + "','" + listView2.Items[i].SubItems[1].Text + "','" + listView2.Items[i].SubItems[2].Text + "')");

                     }
                     MessageBox.Show("Data Saved Successfully!");
                 }
                 catch
                 { }
             }
             else 
             {
                 MessageBox.Show("Required Fields Missing!");
             }
         }

         private void txtPaidAmt_TextChanged(object sender, EventArgs e)
         {

             txtRemaining.Text= (double.Parse( txtTotAmt.Text) - double.Parse(txtPaidAmt.Text)).ToString();
             btnSave.Enabled = true;

         }

         private void txtCustID_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
             {
                 e.Handled = true;
             }
         }

         private void txtQuant_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsDigit(e.KeyChar))
             {
                 e.Handled = true;
             }
         }

         private void txtPaidAmt_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (!char.IsDigit(e.KeyChar))
             {
                 e.Handled = true;
             }
         }


       

         private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             lblservices.Text = cmbServices.SelectedValue.ToString();

             DataTable dt = db.GettableData("select * from serv_type_tbl where Serv_Id="+lblservices.Text);
             if (dt.Rows.Count >= 1)
             {
                 txtRate.Text = dt.Rows[0]["Serv_Rate"].ToString();
             }
         }

         private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
         {

         }
       
        }
}

        
    

