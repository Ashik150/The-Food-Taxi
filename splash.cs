using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Food_Taxi
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void timersplash_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            progress.Value= startpos;
            if(startpos <=20)
            {
                loadinglabel.Text = "Professional Application";
                loadinglabel.ForeColor= Color.WhiteSmoke;
            }
            else if (startpos > 20 && startpos <= 40)
            {
                loadinglabel.Text = "Developed by Professional Team";
                loadinglabel.ForeColor = Color.WhiteSmoke;
            }
            else if (startpos > 40 && startpos <= 60)
            {
                loadinglabel.Text = "OOP Project by C#: The Food Taxi";
                loadinglabel.ForeColor = Color.WhiteSmoke;
            }
            else if(startpos>60 && startpos<=80)
            {
                loadinglabel.Text = "The Food Taxi:Developed in .NET";
                loadinglabel.ForeColor = Color.WhiteSmoke;
            }
            else if(startpos>80)
            {
                loadinglabel.Text = "Contact: Ashik,Esham And Ayon";
                loadinglabel.ForeColor = Color.WhiteSmoke;
            }
            if(progress.Value==100)
            {
                progress.Value = 0;
                timersplash.Stop();
                this.Hide();
                new Login().Show();
            }

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timersplash.Start();
        }
    }
}
