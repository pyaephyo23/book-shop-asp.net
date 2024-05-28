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

namespace BookShop.View
{
    public partial class Login : System.Web.UI.Page
    {
        public static string UName = "";
        public static int UserId;
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtPassword.Text == "")
            {
                lblMessage.Text = "Please Fill Data";
            }
            else if (txtEmail.Text == "Admin@gmail.com" && txtPassword.Text == "Password")
            {
                Response.Redirect("Admin/Books.aspx");
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Select * From Seller Where SEmail=@email and SPassword=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email",txtEmail.Text);
                cmd.Parameters.AddWithValue("@password",txtPassword.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    lblMessage.Text = "Incorrect Email or Password";
                    //Response.Redirect("Admin/Books.aspx");
                }
                else
                {
                    UName = txtEmail.Text;
                    UserId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    Response.Redirect("Seller/Sell.aspx?id=" + UserId);

                }
                con.Close();
            }
        }
    }
}