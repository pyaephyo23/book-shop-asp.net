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
    public partial class Seller : System.Web.UI.Page
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
            string query = "Select * From Seller";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvSeller.DataSource = dt;
            dgvSeller.DataBind();
            con.Close();
        }
        private void ClearData()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtPhNo.Text = "";
            txtPassword.Text = "";
            btnSave.Enabled = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int Phno;
            if (txtName.Text == string.Empty || txtEmail.Text == string.Empty || txtAddress.Text == string.Empty || txtPhNo.Text == string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Fill Data";
            }
            else if (!int.TryParse(txtPhNo.Text, out Phno))
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Phone Number must be a valid Ph No";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert Into Seller (SName,SEmail,SPassword,SPhone,SAddress) Values (@name,@email,@password,@phone,@address)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
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

        protected void dgvSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = dgvSeller.SelectedRow.Cells[2].Text;
            txtEmail.Text = dgvSeller.SelectedRow.Cells[3].Text;
            txtPassword.Text = dgvSeller.SelectedRow.Cells[4].Text;
            txtPhNo.Text = dgvSeller.SelectedRow.Cells[5].Text;
            txtAddress.Text = dgvSeller.SelectedRow.Cells[6].Text;
            btnSave.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty || txtEmail.Text == string.Empty || txtAddress.Text == string.Empty || txtPhNo.Text == string.Empty || txtPassword.Text==string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE Seller SET SName = @name, SEmail = @email, SPassword=@password, SPhone = @phone, SAddress= @address WHERE SId = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvSeller.SelectedRow.Cells[1].Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhNo.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
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
            if (txtName.Text == string.Empty || txtEmail.Text == string.Empty || txtAddress.Text == string.Empty || txtPhNo.Text == string.Empty)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Please Select Data";
            }
            else
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string selectQuery = "SELECT S.SId FROM Seller AS S JOIN Bill AS B ON S.SId = B.Seller Where S.SId=@id";
                SqlCommand selectCmd = new SqlCommand(selectQuery,con);
                selectCmd.Parameters.AddWithValue("@id",Convert.ToInt32(dgvSeller.SelectedRow.Cells[1].Text));
                SqlDataReader dr = selectCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    lblMessage.Text = "This Seller is currently in use";
                    lblMessage.CssClass = "text-danger";
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    string query = "Delete From Seller WHERE SId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvSeller.SelectedRow.Cells[1].Text));
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