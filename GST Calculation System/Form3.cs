using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GST_Calculation_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection conn= null;
        string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KIRAN\\Documents\\GSTDB.mdf;Integrated Security=True;Connect Timeout=30";

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            int price, Total_Tax, TotalProductionCost;
            float CGST, SGST , GST;

            price = int.Parse(txtProductPrice.Text);
            
            GST = (price*int.Parse(txtGST.Text))/100;

            TotalProductionCost = price + (int) GST;

            CGST = (GST/2);

            SGST = (GST/2);

            Total_Tax = (int) GST;

            txtCost.Text = TotalProductionCost.ToString();

            txtCGST.Text = CGST.ToString();

            txtSGST.Text = SGST.ToString();

            txtTotalTax.Text = Total_Tax.ToString();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Insert into Buyer values ( '" + txtProductID.Text + "' , '" + txtProductName.Text + "' , '" + txtProductPrice.Text + "' , '" + txtGST.Text + "' , '" + txtCost.Text + "' , '" + txtCGST.Text + "' ,  '" + txtSGST.Text + "' , '" + txtTotalTax.Text + "')";
                
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Inserted Successfully");
            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data2();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Update Buyer set  ID = '" + txtProductID.Text + "' , Price ='" + txtProductPrice.Text + "' , GST ='" + txtGST.Text + "' ,Cost= '" + txtCost.Text + "' , CGST='" + txtCGST.Text + "' , SGST= '" + txtSGST.Text + "' , TotalTax='" + txtTotalTax.Text + "' where ID = '" + txtProductID.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Updated Successfully");

            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data2();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Delete from Buyer where  ID = '" + txtProductID.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Deleted Successfully");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data2();
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
