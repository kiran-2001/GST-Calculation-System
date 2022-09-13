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
    public partial class Form4 : Form
    {
        SqlConnection conn = null;
        string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\KIRAN\\Documents\\GSTDB.mdf;Integrated Security=True;Connect Timeout=30";
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price, total_Tax, ProductionCost;
            float profit, CGST, SGST, GST;
            price = int.Parse(txtProductionCost.Text);
            profit = (price * int.Parse(txtProfit.Text))/100;
            ProductionCost = price + (int)profit;
            GST = (ProductionCost *int.Parse(txtGST.Text))/100;
            CGST = (GST / 2);
            SGST = (GST / 2);
            total_Tax = (int)GST;
            txtCostOfProduction.Text = ProductionCost.ToString();
            txtCGST.Text = CGST.ToString();
            txtSGST.Text = SGST.ToString(); 
            txtTotalTax.Text = total_Tax.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Insert into Manufacturer values ( '" + txtID.Text + "' , '" + txtName.Text + "' , '" + txtProductionCost.Text + "' , '" + txtGST.Text + "' , '" + txtCostOfProduction.Text + "' , '" + txtCGST.Text + "' ,  '" + txtSGST.Text + "' , '" + txtTotalTax.Text + "', '" + txtProfit.Text + "')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Inserted Successfully");

            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Update Manufacturer set  Id = '" + txtID.Text + "'  , Price ='" + txtProductionCost.Text + "' , GST ='" + txtGST.Text + "' ,Cost= '" + txtCostOfProduction.Text + "' , CGST='" + txtCGST.Text + "' , SGST= '" + txtSGST.Text + "' , TotalTax='" + txtTotalTax.Text + "', Profit='" + txtProfit.Text + "' where ID = '" + txtID.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Updated Successfully");

            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "Delete from Manufacturer where  Id = '" + txtID.Text + "' ";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            MessageBox.Show("Record Deleted Successfully");
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            /*conn = new SqlConnection(conString);

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                string query = "select max(Id) as id from Manufacturer ";
                SqlCommand cmd = new SqlCommand(query, conn);
                MessageBox.Show("Hello");
                cmd.ExecuteNonQuery();
                int mid = Convert.ToInt32(query);
                mid = mid + 1;
                txtID.Text = mid.ToString();
                
            }
            */
           // conn.Close();
            Class1 cs = new Class1();
            DataTable dt = new DataTable();
            dt = cs.display_data();
            dataGridView1.DataSource = dt;


        }

        private void button6_Click(object sender, EventArgs e)
        {


        }
    }
}
