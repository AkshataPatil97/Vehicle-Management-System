using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        dbcodeclass db = new dbcodeclass();
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password  and username...!");
                txtPassword.Focus();
                return;
            }

            DataTable dt = db.GettableData("Select * from login where username='" + cmbUserName.Text + "' AND password='" + txtPassword.Text + "'");

            if (dt.Rows.Count >= 1)
            {
                if (dt.Rows[0]["usertype"].ToString().Equals("sampada"))
                {
                    Admin_hp frm = new Admin_hp();
                    frm.Show();
                    this.Hide();
                }
           
                else if (dt.Rows[0]["usertype"].ToString().Equals("akshata"))
                {
                    Admin_hp frm = new Admin_hp();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid username and password !!");
                //cledata();
            }


 }
        private void login_Load(object sender, EventArgs e)
        {
            db.FillCombo(cmbUserName, "select * from login", "username", "usetype");
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
