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
    public partial class Client_detail : Form
    {
        Regex ex = new Regex(@"^([6-9]{1})[0-9]{9}$");


        dbcodeclass db = new dbcodeclass();
        public Client_detail()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "" || txtClientId.Text == "" || txtCar_No.Text=="" || txtFirstName.Text=="" || txtMiddleName.Text==""|| txtAddress.Text=="" || txtMobile_No.Text=="")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (ex.IsMatch(txtMobile_No.Text) && txtMobile_No.Text.Length==10)
            {

                db.ExecuteSqlQuery("Insert into client_tbl( Client_Id, First_Name, Middle_Name, Last_Name, Mobile_No, Address, Comment, Vehicle_No, Model) values('" + txtClientId.Text + "','" + txtFirstName.Text + "','" + txtMiddleName.Text + "','" + txtLastName.Text + "','" + txtMobile_No.Text.ToString() + "','" + txtAddress.Text + "','" + txtComment.Text + "','" + txtCar_No.Text + "','" + txtModel.Text + "')");
                db.FillGridData(dataGridView1, "Select * from client_tbl");

                EnabledFalse();
                cleardata();
                btnNew.Focus();
                MessageBox.Show("Save Data sucessfully..");

            }

            cleardata();
            
        }

        private void Client_detail_Load(object sender, EventArgs e)
        {
            
            btnNew.Focus();
            EnabledFalse();
            db.FillGridData(dataGridView1, "Select * from client_tbl");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMaxID();
            btnSave.Enabled = true;
        }

        void EnabledFalse()
        {
           
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
        }
            
        public void GetMaxID()
        {
            txtClientId.Text = db.GetAutoID("select MAX(Client_Id) from client_tbl").ToString();
        }
        void cleardata()
        {
            txtClientId.Text="";
            txtFirstName.Text="";
            txtMiddleName.Text="";
            txtLastName.Text="";
            txtMobile_No.Text="";
            txtComment.Text="";
            txtCar_No.Text="";
            txtAddress.Text="";
            txtModel.Text = "";
 
        }

        private void GriddataDisk1()
        {
            try
            {
                txtClientId.Text = dataGridView1.SelectedRows[0].Cells["Client_Id"].Value.ToString();
                txtFirstName.Text = dataGridView1.SelectedRows[0].Cells["First_Name"].Value.ToString();
                txtMiddleName.Text = dataGridView1.SelectedRows[0].Cells["Middle_Name"].Value.ToString();
                txtLastName.Text = dataGridView1.SelectedRows[0].Cells["Last_Name"].Value.ToString();
                txtMobile_No.Text = dataGridView1.SelectedRows[0].Cells["Mobile_No"].Value.ToString();
                txtAddress.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
                txtComment.Text = dataGridView1.SelectedRows[0].Cells["Comment"].Value.ToString();
                txtCar_No.Text = dataGridView1.SelectedRows[0].Cells["Vehicle_No"].Value.ToString();
                txtModel.Text = dataGridView1.SelectedRows[0].Cells["Model"].Value.ToString();

                EnabledFalse();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
              
               
            }
            catch { }
        }
        
        private void button3_Click_1(object sender, EventArgs e)
        {


            if (txtFirstName.Text == "" && txtClientId.Text == "" && txtCar_No.Text == "" && txtFirstName.Text == "" && txtMiddleName.Text == "" && txtAddress.Text == "" && txtMobile_No.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (ex.IsMatch(txtMobile_No.Text) && txtMobile_No.Text.Length == 10)
            {
                if (MessageBox.Show("Do you want delete record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    db.ExecuteSqlQuery("Delete from client_tbl Where Client_Id =" + txtClientId.Text);
                    MessageBox.Show("Data Deleted sucessfully..");
                }
                db.FillGridData(dataGridView1, "Select * from client_tbl");
            }
            cleardata();
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "" && txtClientId.Text == "" && txtCar_No.Text == "" && txtFirstName.Text == "" && txtMiddleName.Text == "" && txtAddress.Text == "" && txtMobile_No.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }
            if (ex.IsMatch(txtMobile_No.Text) && txtMobile_No.Text.Length == 10)
            {
                db.ExecuteSqlQuery("Update client_tbl SET First_Name ='" + txtFirstName.Text + "', Middle_Name ='" + txtMiddleName.Text + "', Last_Name ='" + txtLastName.Text + "', Mobile_No = '" + txtMobile_No.Text + "', Address ='" + txtAddress.Text + "',Comment = '" + txtComment.Text + "' ,Vehicle_No = '" + txtCar_No.Text + "',Model = '" + txtModel.Text + "' Where  Client_Id ='" + txtClientId.Text + "'");
                db.FillGridData(dataGridView1, "Select * from client_tbl");

                MessageBox.Show(" Data Updated  sucessfully..");
            }
            cleardata();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            btnNew.Focus();
            btnNew.Enabled = true;
            cleardata();
            EnabledFalse();
        }

        private void txtMobile_No_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txtMiddleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        
        private void txtClientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            GriddataDisk1();
            btnNew.Enabled = false;
        }

        private void txtMobile_No_Validating(object sender, CancelEventArgs e)
        {
            
            if (!ex.IsMatch(txtMobile_No.Text))
            {
                errorMob.SetError(this.txtMobile_No,"Invalid Mobile Number");
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) == true)
            {
                errorFN.SetError(this.txtFirstName, "It is a required field!");
               
            }
            else
            {
                errorFN.Clear();
            }
        }

        private void txtMiddleName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMiddleName.Text) == true)
            {
                errorMN.SetError(this.txtMiddleName, "It is a required field!");
                
            }
            else
            {
                errorMN.Clear();
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text) == true)
            {
                errorLN.SetError(this.txtLastName, "It is a required field!");
              
            }
            else
            {
                errorLN.Clear();
            }
        }

        private void txtMobile_No_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMobile_No.Text) == true)
            {
                errorMob.SetError(this.txtMobile_No, "It is a required field!");
             
            }
            else
            {
                errorMob.Clear();
            }
        }

        private void Client_detail_Leave(object sender, EventArgs e)
        {

        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text) == true)
            {
                errorAddress.SetError(this.txtAddress, "It is a required field!");
                
            }
            else
            {
                errorAddress.Clear();
            }
        }

        private void txtCar_No_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCar_No.Text))
            {
                errorCarNo.SetError(this.txtCar_No, "It is a required field!");
            }
            else
            {
                errorCarNo.Clear();
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtsearch.Text == "")
                {
                    db.FillGridData(dataGridView1, "Select * from client_tbl");
                    return;
                }

                else if (searchcombo.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "Select * from client_tbl where Client_Id=" + txtsearch.Text);
                }
                else if (searchcombo.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "Select * from client_tbl where Model like '" + txtsearch.Text + "%'");
                }
              
            }
            catch
            { }
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

    }
}

