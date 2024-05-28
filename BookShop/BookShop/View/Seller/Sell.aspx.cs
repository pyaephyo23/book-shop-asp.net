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

namespace BookShop.View.Seller
{
    public partial class Sell : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        int SellerId = Login.UserId;
        string Seller = Login.UName;
        int total;
        private int amount;
        int stock = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowData();
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                {
                    new DataColumn("ID"),
                    new DataColumn("Book"),
                    new DataColumn("Price"),
                    new DataColumn("Quantity"),
                    new DataColumn("Total")
                });
                ViewState["Bill"] = dt;
                this.BoundGrid();
            }
        }
        protected void BoundGrid()
        {
            dgvBill.DataSource = ViewState["Bill"];
            dgvBill.DataBind();
        }

        private void ShowData()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select BookId as Code, BookName as Name,BookQty as Stock,BookPrice as Price From Books";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            dgvBook.DataSource = dt;
            dgvBook.DataBind();
            con.Close();
        }

        private void UpdateStock()
        {
            int newQty = Convert.ToInt32(dgvBook.SelectedRow.Cells[3].Text) - Convert.ToInt32(txtQty.Text);
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "UPDATE Books SET BookQty= @qty WHERE BookId = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvBook.SelectedRow.Cells[1].Text));
            cmd.Parameters.AddWithValue("@qty", newQty);
            int row = cmd.ExecuteNonQuery();
            if (row > 0)
            {
                //lblMessage.CssClass = "text-success";
                //lblMessage.Text = "Successfully Updated";
                ShowData();
            }
            else
            {
                //lblMessage.Text = "Failed";
                //lblMessage.CssClass = "text-danger";
            }
            con.Close();
        }


        protected void dgvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBook.Text = dgvBook.SelectedRow.Cells[2].Text;
            stock = Convert.ToInt32(dgvBook.SelectedRow.Cells[3].Text);
            txtPrice.Text = dgvBook.SelectedRow.Cells[4].Text;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int price, qty;
            if (txtBook.Text == "" || txtPrice.Text == "" || txtQty.Text == "")
            {
                lblMessage.Text = "Please Insert Data";
            }
            else
                if (!int.TryParse(txtPrice.Text, out price))
                {
                    lblMessage.Text = "Price must be a valid number";
                    return;
                }
                else

                    if (!int.TryParse(txtQty.Text, out qty))
                    {
                        lblMessage.Text = "Quantity must be a valid number";
                        return;
                    }
                    else
                    {
                        total = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQty.Text);
                        DataTable dt = (DataTable)ViewState["Bill"];
                        dt.Rows.Add(dgvBill.Rows.Count + 1,
                            txtBook.Text.Trim(),
                            txtPrice.Text.Trim(),
                            txtQty.Text.Trim(),
                            total);
                        ViewState["Bill"] = dt;
                        this.BoundGrid();
                        UpdateStock();

                        total = 0;
                        for (int i = 0; i < dgvBill.Rows.Count; i++)
                        {
                            total = total + Convert.ToInt32(dgvBill.Rows[i].Cells[4].Text);
                        }
                        amount = total;
                        lblTotal.Text = amount.ToString();
                        txtBook.Text = "";
                        txtPrice.Text = "";
                        txtQty.Text = "";
                        total = 0;
                        lblMessage.Text = "";
                    }

        }
        private void InsertBill()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Insert Into Bill (BillDate,Seller,Amount) Values (@date,@seller,@amount)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@seller", Convert.ToInt32(Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@amount", Convert.ToInt32(lblTotal.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            InsertBill();
        }
    }
}