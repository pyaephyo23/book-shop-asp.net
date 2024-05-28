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
    public partial class Categories : System.Web.UI.Page
    {
        private int key = 0;
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        private void ShowData()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * From Category";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvCategory.DataSource = dt;
            dgvCategory.DataBind();
            con.Close();
        }
        private void ClearData()
        {
            txtName.Text = "";
            txtDesc.Text="";
            btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtDesc.Text==string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Fill Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert Into Category (CategoryName,CategoryDesc) Values (@name,@desc)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Successfully Saved";
                    ClearData();
                    ShowData();
                }
                else
                {
                    lblMessage.Text = "Failed";
                    lblMessage.CssClass = "text-danger";
                }
                con.Close();

            }
        }

        protected void dgvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = dgvCategory.SelectedRow.Cells[2].Text;
            txtDesc.Text = dgvCategory.SelectedRow.Cells[3].Text;
            btnSave.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtDesc.Text==string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE Category SET CategoryName = @name, CategoryDesc = @desc WHERE CategoryId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvCategory.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "Successfully Updated";
                    ClearData();
                    ShowData();
                }
                else
                {
                    lblMessage.Text = "Failed";
                    lblMessage.CssClass = "text-danger";
                }
                con.Close();

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtDesc.Text==string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string selectQuery = "SELECT B.BookCategory FROM Books AS B JOIN Category AS C ON B.BookCategory = C.CategoryId Where C.CategoryId=@id";
                SqlCommand selectCmd = new SqlCommand(selectQuery,con);
                selectCmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvCategory.SelectedRow.Cells[1].Text));
                SqlDataReader dr = selectCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    lblMessage.Text = "This category is currently in use";
                    lblMessage.CssClass = "text-danger";
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    string query = "Delete From Category WHERE CategoryId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvCategory.SelectedRow.Cells[1].Text));
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0)
                    {
                        lblMessage.CssClass = "text-success";
                        lblMessage.Text = "Successfully Deleted";
                        ClearData();
                        ShowData();
                    }
                    else
                    {
                        lblMessage.Text = "Failed";
                        lblMessage.CssClass = "text-danger";
                    }
                }
                
                con.Close();

            }
        }
    }
}