using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace BookShop.View.Admin
{
    public partial class SalesOverview : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private void ShowAll()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT B.BillId, B.BillDate, S.SName, B.Amount FROM Bill AS B JOIN Seller AS S ON B.Seller = S.SId";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvBill.DataSource = dt;
            dgvBill.DataBind();

            int totalAll = dt.AsEnumerable().Sum(row => row.Field<int>("Amount"));
            lblMessage.Text = "Total All: " + totalAll.ToString() +" Kyat"; 
            con.Close();
      
        }
        private void ShowToday()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = @"SELECT B.BillId, B.BillDate, S.SName, B.Amount 
                            FROM Bill AS B 
                            JOIN Seller AS S ON B.Seller = S.SId
                            WHERE CONVERT(date, B.BillDate) = CONVERT(date, GETDATE());";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvBill.DataSource = dt;
            dgvBill.DataBind();

            int totalToday = dt.AsEnumerable().Sum(row => row.Field<int>("Amount"));
            lblMessage.Text = "Total Today: " + totalToday.ToString() +" Kyat";
            con.Close();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        protected void btnShowToday_Click(object sender, EventArgs e)
        {
            ShowToday();
        }
    }
}