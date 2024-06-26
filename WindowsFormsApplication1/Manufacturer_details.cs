using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Manufacturer_details : Form
    {
        dbcodeclass db = new dbcodeclass();
        Regex ex = new Regex(@"^[0-9]{10}$");
        Regex ema = new Regex(@"^([\w\/\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public Manufacturer_details()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Manufacturer_details_Load(object sender, EventArgs e)
        {
            db.FillGridData(dataGridView1, "select * from manu_tbl");
            btnNew.Focus();
            btnNew.Enabled = true;
            EnabledFalse();

        }
        void EnabledFalse() 
        
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            //btnNew.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GetMaxID();
            btnSave.Enabled = true;
        }

        public void GetMaxID()
        {
            txtid.Text = db.GetAutoID("Select MAX(manu_id) from manu_tbl").ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtcname.Text == "" || txtcontact.Text=="" || txtemail.Text == "" || txtid.Text == "" || txtlocation.Text == "")
            {
                MessageBox.Show("All fields are compulsary!!");
                
            }

            if (txtcontact.Text.Length == 10 &&(ex.IsMatch(txtcontact.Text)) && (ema.IsMatch(txtemail.Text))&&txtid.Text!="")
            {

                db.ExecuteSqlQuery("insert into manu_tbl(manu_id, manu_name, manu_location, manu_email, manu_contact)values('" + txtid.Text + "','" + txtcname.Text + "','" + txtlocation.Text + "','" + txtemail.Text + "','" + txtcontact.Text + "')");
                db.FillGridData(dataGridView1, "Select * from manu_tbl");

                EnabledFalse();
                cleardata();
                btnNew.Focus();
                MessageBox.Show("Save data successfully..");
            }
    
        }
        void cleardata()
        {
            txtid.Clear();
            txtcname.Clear();
            txtlocation.Clear();
            txtemail.Clear();
            txtcontact.Clear();
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtcname.Text == "" || txtcontact.Text=="" || txtemail.Text == "" || txtid.Text == "" || txtlocation.Text == "")
            {
                MessageBox.Show("All Fields are compulsory");
            }

            if (txtcontact.Text.Length == 10 && (ex.IsMatch(txtcontact.Text)) && (ema.IsMatch(txtemail.Text)))
            {
                db.ExecuteSqlQuery("Update manu_tbl SET manu_name= '" + txtcname.Text + "',manu_location='" + txtlocation.Text + "',manu_email= '" + txtemail.Text + "', manu_contact= '" + txtcontact.Text + "' where manu_id=" + txtid.Text);

                db.FillGridData(dataGridView1, "Select * from manu_tbl");
                MessageBox.Show("Data Updated Successfully!");
                cleardata();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            griddisk();
            btnNew.Enabled = false;

        }
        void griddisk()
        {
            try
            {
                txtid.Text = dataGridView1.SelectedRows[0].Cells["manu_id"].Value.ToString();
                txtcname.Text = dataGridView1.SelectedRows[0].Cells["manu_name"].Value.ToString();
                txtlocation.Text = dataGridView1.SelectedRows[0].Cells["manu_location"].Value.ToString();
                txtemail.Text = dataGridView1.SelectedRows[0].Cells["manu_email"].Value.ToString();
                txtcontact.Text = dataGridView1.SelectedRows[0].Cells["manu_contact"].Value.ToString();

                EnabledFalse();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;

            }
            catch { }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtcname.Text == "" || txtcontact.Text == "" || txtemail.Text == "" || txtid.Text == "" || txtlocation.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("Delete from manu_tbl Where manu_id =" + txtid.Text);
            }
            db.FillGridData(dataGridView1, "Select * from manu_tbl");

            cleardata();

            MessageBox.Show("Delete Data sucessfully..");
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtid_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtcname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtcname.Text) == true)
            {
                errorComName.SetError(this.txtcname, "It is a required field!!");
            }
            else
            {
                errorComName.Clear();
            }
        }

        private void txtemail_Validating(object sender, CancelEventArgs e)
        {
            if (!ema.IsMatch(txtemail.Text))
            {
                errorEmail.SetError(this.txtemail, "Invalid Email!");
            }
            else
            {
                errorEmail.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            btnNew.Focus();
            btnNew.Enabled = true;
            EnabledFalse();
            cleardata();
        }



        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtsearch.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from manu_tbl");
                    return;
                }

                else if (searchcombo.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "select * from manu_tbl where manu_id=" + txtsearch.Text);
                }
                else if (searchcombo.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from manu_tbl where manu_name like '" + txtsearch.Text + "%'");
                }
            }
            catch
            { }
        }

        private void txtcontact_Validating(object sender, CancelEventArgs e)
        {
            if (!ex.IsMatch(txtcontact.Text))
            {
                errorContact.SetError(this.txtcontact, "Invalid Mobile No!!");
            }
            else 
            {
                errorContact.Clear();
            }
        }

        private void txtlocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            
            }
        }

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
    }
}
