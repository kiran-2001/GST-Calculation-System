using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GST_Calculation_System
{
    internal class Class1
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KIRAN\Documents\GSTDB.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        SqlCommandBuilder bld;
        DataTable dt;


        public DataTable display_data()
        {
            string qry = "select * from Manufacturer";
            conn.Open();
            adpt = new SqlDataAdapter(qry, conn);
            bld = new SqlCommandBuilder(adpt);
            dt= new DataTable();    
            adpt.Fill(dt);
            conn.Close();
            return dt;
            

            
        }
        public DataTable display_data1()
        {
            string qry = "select * from saler";
            conn.Open();
            adpt = new SqlDataAdapter(qry, conn);
            bld = new SqlCommandBuilder(adpt);
            dt = new DataTable();
            adpt.Fill(dt);
            conn.Close();
            return dt;



        }
        public DataTable display_data2()
        {
            string qry = "select * from Buyer";
            conn.Open();
            adpt = new SqlDataAdapter(qry, conn);
            bld = new SqlCommandBuilder(adpt);
            dt = new DataTable();
            adpt.Fill(dt);
            conn.Close();
            return dt;



        }

        



    }
}
