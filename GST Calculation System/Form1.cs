using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GST_Calculation_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string userId = txtUserName.Text;
            string pass = txtPassword.Text;
            if (userId =="Admin" && pass =="root123")
            {

            Form2 form = new Form2();   
            form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials");
            }
        }
    }
}
