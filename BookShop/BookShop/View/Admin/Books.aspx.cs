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
    public partial class Books : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
                GetCategory();
                GetAuthor();
            }

            
        }
        private void ShowData()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * From Books";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvBook.DataSource = dt;
            dgvBook.DataBind();
            con.Close();
        }
        private void ClearData()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            cboAuthor.SelectedIndex = -1;
            cboCategory.SelectedIndex = -1;
            btnSave.Enabled = true;
        }
        private void GetCategory()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * From Category";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            cboCategory.DataSource = dr;
            cboCategory.DataTextField = "CategoryName";
            cboCategory.DataValueField = "CategoryId";
            cboCategory.DataBind();
            con.Close();
        }
        private void GetAuthor()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select * From Author";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            cboAuthor.DataSource = dr;
            cboAuthor.DataTextField = "AuthorName";
            cboAuthor.DataValueField = "AuthorId";
            cboAuthor.DataBind();
            con.Close();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int qty, price;
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQty.Text) || string.IsNullOrEmpty(txtPrice.Text) || cboCategory.SelectedIndex == -1 || cboAuthor.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else if (!int.TryParse(txtQty.Text, out qty))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Quantity must be a valid integer";
            }
            else if (!int.TryParse(txtPrice.Text, out price))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Price must be a valid integer";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert Into Books (BookName,BookAuthor,BookCategory,BookQty,BookPrice) Values (@name,@author,@category,@qty,@price)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@author", cboAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("@category", cboCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtQty.Text));
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
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

        protected void dgvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = dgvBook.SelectedRow.Cells[2].Text;
            cboAuthor.SelectedValue = dgvBook.SelectedRow.Cells[3].Text;
            cboCategory.SelectedValue = dgvBook.SelectedRow.Cells[4].Text;
            txtQty.Text = dgvBook.SelectedRow.Cells[5].Text;
            txtPrice.Text = dgvBook.SelectedRow.Cells[6].Text;
            btnSave.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int qty, price;
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtQty.Text) || string.IsNullOrEmpty(txtPrice.Text) || cboCategory.SelectedIndex == -1 || cboAuthor.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else if (!int.TryParse(txtQty.Text, out qty))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Quantity must be a valid integer";
            }
            else if (!int.TryParse(txtPrice.Text, out price))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Price must be a valid integer";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE Books SET BookName = @name, BookAuthor = @author, BookCategory = @category, BookQty= @qty, BookPrice=@price WHERE BookId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvBook.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@author", cboAuthor.SelectedValue);
                cmd.Parameters.AddWithValue("@category", cboCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtQty.Text));
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
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
            if (txtName.Text == string.Empty || txtQty.Text == string.Empty || txtPrice.Text == string.Empty || cboCategory.SelectedIndex == -1 || cboAuthor.SelectedIndex == -1)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Delete From Books WHERE BookId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvBook.SelectedRow.Cells[1].Text));
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
                con.Close();

            }
        }
    }
}