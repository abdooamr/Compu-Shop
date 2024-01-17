using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class adminrestock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null || !(bool)Session["isAdmin"])
        {
            Response.Redirect("/Pages/login.aspx");
        }

        if (!IsPostBack)
        {
            BindProducts(); // Fetch and bind products on initial page load
        }
    }

    private void BindProducts()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string selectQuery = "SELECT product_id, product_name, stock FROM Product";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectQuery, con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(command))
                {
                    con.Open();
                    using (System.Data.DataTable dt = new System.Data.DataTable())
                    {
                        sda.Fill(dt);
                        productsGridView.DataSource = dt;
                        productsGridView.DataBind();
                    }
                }
            }
        }
    }

    protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Restock")
        {
            int rowIndex;
            if (int.TryParse(e.CommandArgument.ToString(), out rowIndex) && rowIndex >= 0 && rowIndex < productsGridView.Rows.Count)
            {
                GridViewRow row = productsGridView.Rows[rowIndex];
                TextBox restockQuantityTextBox = row.FindControl("restockQuantityTextBox") as TextBox;

                if (restockQuantityTextBox != null)
                {
                    int productId;
                    if (int.TryParse(row.Cells[0].Text, out productId)) // Assuming Product ID is in the first column
                    {
                        int newStockValue;
                        if (int.TryParse(restockQuantityTextBox.Text, out newStockValue))
                        {
                            // Perform restocking using the entered quantity
                            UpdateStock(productId, newStockValue);
                            restockSuccessLabel.Visible = true;
                            BindProducts(); // Rebind the GridView after restocking
                        }
                        else
                        {
                            // Handle invalid input for the quantity
                            restockErrorLabel.Text = "Please enter a valid quantity for restocking.";
                            restockErrorLabel.Visible = true;
                        }

                    }
                    else
                    {
                    }
                }
            }
            else
            {
             
            }
        }
    }


    private void UpdateStock(int productId, int newStock)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string updateQuery = "UPDATE Product SET stock = stock + @NewStock WHERE product_id = @ProductId";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(updateQuery, con))
            {
                command.Parameters.AddWithValue("@NewStock", newStock);
                command.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
