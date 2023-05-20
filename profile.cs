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
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void hmlabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new homepage().Show();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand("Select username,password,fullname,gender,[phone number],location,birthyear from tbl_users where password=@parm1", con);
            cmd.Parameters.AddWithValue("@parm1", sutextBox.Text);
            OleDbDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if(reader1.Read())
            {
                nametextBox.Text = reader1["fullname"].ToString();
                gendertextBox.Text = reader1["gender"].ToString();
                numbtextBox.Text = reader1["phone number"].ToString();
                locatetextBox.Text = reader1["location"].ToString();
                birthtextBox.Text = reader1["birthyear"].ToString();
            }
            else
            {
                MessageBox.Show("Password Incorrect");
            }
            con.Close();

        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            string query = "update tbl_users set fullname='" + nametextBox.Text+ "', gender='"+gendertextBox.Text+ "', [phone number]='" +numbtextBox.Text+ "', location='" +locatetextBox.Text+ "', birthyear='" +birthtextBox.Text+"'  ";
            MessageBox.Show(query);
            cmd.CommandText = query;

            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Changed Successful");
            con.Close();
        }
    }
}
