using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Employee_details : Form
    {
        Regex ex = new Regex(@"^([6-9]{1})[0-9]{9}$");

        Regex ema = new Regex(@"^([\w\/\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        dbcodeclass db = new dbcodeclass();
        public Employee_details()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Employee_details_Load(object sender, EventArgs e)
        {
           db.FillGridData(dataGridView1, "select * from emp_tbl");
            btnNew.Focus();
            btnNew.Enabled = true;
            EnabledFalse();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "")
            {
                MessageBox.Show("Missing Fields");
                return;
            }

            if (MessageBox.Show("Do you want delete record", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.ExecuteSqlQuery("Delete from emp_tbl Where emp_id =" + txtEmpID.Text);
            }
            db.FillGridData(dataGridView1, "Select * from emp_tbl");

            cleardata();

            MessageBox.Show("Delete Data sucessfully..");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "" && txtEmpName.Text == "" && txtContact.Text == "" )
            {
                MessageBox.Show("All Fields are compulsory");
            }

            if (ex.IsMatch(txtContact.Text) && (ema.IsMatch(txtEmail.Text)))
            {
                db.ExecuteSqlQuery("Update emp_tbl SET emp_name= '" + txtEmpName.Text + "', emp_contact= '" + txtContact.Text + "', emp_gender= '" + comboGen.ToString() + "', emp_mail= '" + txtEmail.Text + "',emp_address='" + txtEmpAddress.Text + "',emp_sal= '" + txtSalary.Text + "' Where emp_id=" + txtEmpID.Text);

                db.FillGridData(dataGridView1, "Select * from emp_tbl");
                MessageBox.Show("Data Updated Successfully!");
                cleardata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEmpID.Text == "" && txtEmpName.Text=="" && txtContact.Text=="")
            {
                MessageBox.Show("Missing Fields!!");
                return;
            }

            if(ex.IsMatch(txtContact.Text)&& (ema.IsMatch(txtEmail.Text)))
            {

            db.ExecuteSqlQuery("insert into emp_tbl(emp_id, emp_name, emp_contact, emp_gender, emp_mail, emp_address,emp_sal)values('"+txtEmpID.Text+"','"+txtEmpName.Text+"','"+txtContact.Text+"','"+comboGen.Text+"','"+txtEmail.Text+"','"+txtEmpAddress.Text+"','"+txtSalary.Text+"')");
            db.FillGridData(dataGridView1, "Select * from emp_tbl");

            EnabledFalse();
            cleardata();
            btnNew.Focus();
            MessageBox.Show("Save Data sucessfully..");  
            }
        }
        void cleardata()
        {
            txtEmpID.Clear();
            txtEmpName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            txtEmpAddress.Clear();
            txtSalary.Clear();
            
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
             GetMaxID();
             btnSave.Enabled = true;
        }

       void GetMaxID()
        {
           txtEmpID.Text= db.GetAutoID("select MAX(emp_id) from emp_tbl").ToString(); 

        }
        void EnabledFalse()
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            //btnNew.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboGen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
           
            if (!ex.IsMatch(txtContact.Text))
            {
                errorMobile_No.SetError(this.txtContact,"Invalid Mobile number");
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                txtEmpID.Text = dataGridView1.SelectedRows[0].Cells["emp_id"].Value.ToString();
                txtEmpName.Text = dataGridView1.SelectedRows[0].Cells["emp_name"].Value.ToString();
                txtContact.Text = dataGridView1.SelectedRows[0].Cells["emp_contact"].Value.ToString();
                txtEmail.Text = dataGridView1.SelectedRows[0].Cells["emp_mail"].Value.ToString();
                comboGen.Text = dataGridView1.SelectedRows[0].Cells["emp_gender"].Value.ToString();
                txtEmpAddress.Text = dataGridView1.SelectedRows[0].Cells["emp_address"].Value.ToString();
                txtSalary.Text = dataGridView1.SelectedRows[0].Cells["emp_sal"].Value.ToString();

                EnabledFalse();
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;

            }
            catch { }
        }

        private void txtEmpID_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtEmpName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpName.Text) == true)
            {
                errorName.SetError(this.txtEmpName, "This is a required field!!");
            }
            else
            {
                errorName.Clear();
            }
        }

        private void comboGen_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboGen.Text) == true)
            {
                errorGender.SetError(this.comboGen, "This is a required field!!");
            }
            else
            {
                errorGender.Clear();
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

           if (!ema.IsMatch(txtEmail.Text))
           {
               errorEmail.SetError(this.txtEmail, "Invalid Email!!");

           }
           else
           {
               errorEmail.Clear();
           }
        
        }


        private void txtSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSalary.Text) == true)
            {
                errorSalary.SetError(this.txtSalary, "This is a required field!!");
            }
            else
            {
                errorSalary.Clear();
            }
        }

        private void txtContact_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContact.Text) == true)
            {
                errorMobile_No.SetError(this.txtContact, "This is a required field!!");
            }
            else
            {
                errorMobile_No.Clear();
            }

        }

        private void txtEmpID_Leave(object sender, EventArgs e)
        {

            
        }

        private void searchcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnNew.Focus();
            btnNew.Enabled = true;
            EnabledFalse();
            cleardata();
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    db.FillGridData(dataGridView1, "select * from emp_tbl");
                    return;
                }
                if (cmbSearch.SelectedIndex == 0)
                {
                    db.FillGridData(dataGridView1, "select * from emp_tbl where emp_id=" + txtSearch.Text);
                }
                else if (cmbSearch.SelectedIndex == 1)
                {
                    db.FillGridData(dataGridView1, "select * from emp_tbl where emp_name like '" + txtSearch.Text + "%'");
                }
            }
            catch { }
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                 e.Handled=true;
            }
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((!char.IsControl(e.KeyChar))&&!char.IsDigit(e.KeyChar))
            {
                e.Handled=true;
            }
        }
    }
}
