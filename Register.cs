using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace The_Food_Taxi
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent(); 
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void registerbutton_Click(object sender, EventArgs e)
        {
            if(usernametextBox.Text=="" && passwordtextBox.Text=="" && confirmtextBox.Text=="")
            {
                MessageBox.Show("Please Input Username and Password", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(passwordtextBox.Text==confirmtextBox.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES('" + usernametextBox.Text + "' , '" + passwordtextBox.Text + "' , '" + nametextBox1.Text+ "' , '" +gendertextBox1.Text+"' , '" +numbtextBox1.Text+"' , '" +locatetextBox1.Text+"' , '" +birthtextBox1.Text+"')";
                cmd=new OleDbCommand(register,con);
                cmd.ExecuteNonQuery();
                con.Close();

                usernametextBox.Clear();
                passwordtextBox.Clear();
                confirmtextBox.Clear();

                MessageBox.Show("Your Account has been created successfully","Registration Successful",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password does not match,Plaese Re-enter","Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtextBox.Clear();
                confirmtextBox.Clear();
                passwordtextBox.Focus();
            }
        }

        private void showpasscheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(showpasscheckBox.Checked) 
            {
                passwordtextBox.PasswordChar= '\0';
                confirmtextBox.PasswordChar= '\0';
            }
            else
            {
                passwordtextBox.PasswordChar= '*';
                confirmtextBox.PasswordChar= '*';
            }
        }

        private void clearregbutton_Click(object sender, EventArgs e)
        {
            usernametextBox.Clear();
            passwordtextBox.Clear();
            confirmtextBox.Clear();
            usernametextBox.Focus();
        }

        private void btloginlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();

        }
    }
}
