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
    public partial class Author : System.Web.UI.Page
    {
        
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
            string query = "Select * From Author";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvAuthor.DataSource = dt;
            dgvAuthor.DataBind();
            con.Close();
        }
        private void ClearData()
        {
            txtName.Text = "";
            cboCountry.SelectedIndex = -1;
            cboGender.SelectedIndex = -1;
            btnSave.Enabled = true;
        }


        protected void dgvAuthor_SelectedIndexChanged1(object sender, EventArgs e)
        {
            txtName.Text = dgvAuthor.SelectedRow.Cells[2].Text;
            ListItem genderItem = cboGender.Items.FindByText(dgvAuthor.SelectedRow.Cells[3].Text);
            if (genderItem != null)
            {
                cboGender.ClearSelection();
                genderItem.Selected = true;
            }

            ListItem countryItem = cboCountry.Items.FindByText(dgvAuthor.SelectedRow.Cells[4].Text);
            if (countryItem != null)
            {
                cboCountry.ClearSelection();
                countryItem.Selected = true;
            }
            btnSave.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            if (txtName.Text == string.Empty || cboGender.SelectedIndex == -1 || cboGender.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE Author SET AuthorName = @name, AuthorGender = @gender, AuthorCountry = @country WHERE AuthorId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvAuthor.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cboGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@country", cboCountry.SelectedItem.ToString());
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || cboGender.SelectedIndex == -1 || cboGender.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Fill Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert Into Author (AuthorName,AuthorGender,AuthorCountry) Values (@name,@gender,@country)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@gender", cboGender.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@country", cboCountry.SelectedItem.ToString());
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtName.Text == string.Empty || cboGender.SelectedIndex == -1 || cboGender.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string selectQuery = "SELECT B.BookId FROM Books AS B JOIN Author AS A ON B.BookAuthor = A.AuthorId WHERE A.AuthorId = @id";
                SqlCommand selectCmd = new SqlCommand(selectQuery, con);
                selectCmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvAuthor.SelectedRow.Cells[1].Text));
                SqlDataReader dr = selectCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    lblMessage.Text = "This Author is currently in use";
                    lblMessage.CssClass = "text-danger";
                    dr.Close();

                }
                else
                {
                    dr.Close();
                    string query = "Delete From Author WHERE AuthorId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvAuthor.SelectedRow.Cells[1].Text));
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