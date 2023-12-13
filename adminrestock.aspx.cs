using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

public partial class adminrestock : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null || !(bool)Session["isAdmin"])
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void BackButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminpanel.aspx");
    }

    protected void RestockButton_Click(object sender, EventArgs e)
    {
        int productId;
        if (int.TryParse(productIdTextBox.Text, out productId))
        {
            int newStock;
            if (int.TryParse(newStockTextBox.Text, out newStock))
            {
                UpdateStock(productId, newStock);
                restockSuccessLabel.Visible = true;
                ClearFields();
            }
            else
            {
                // Handle if the new stock value is not a valid integer
            }
        }
        else
        {
            // Handle if the product ID is not a valid integer
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

    private void ClearFields()
    {
        productIdTextBox.Text = string.Empty;
        newStockTextBox.Text = string.Empty;
    }
}
