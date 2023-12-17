using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class adminproducts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null || !(bool)Session["isAdmin"])
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminpanel.aspx");
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string productName = pname.Text;
        decimal price = decimal.Parse(productPrice.Text);
        int stock = int.Parse(productStock.Text);
        string categoryName = productCategory.Text;

        int categoryId = GetCategoryId(categoryName);

        if (categoryId != -1 && imageUpload.HasFile) // Ensure a file is uploaded and category is found
        {
            string uploadDirectory = Server.MapPath("~/images/"); // Directory to save images
            string fileName = Path.GetFileName(imageUpload.FileName); // Get uploaded file name
            string filePath = Path.Combine(uploadDirectory, fileName); // Combine with directory path
            imageUpload.SaveAs(filePath); // Save the uploaded file

            string imageURL = "~/images/" + fileName; // Image path to store in the database

            InsertProduct(productName, price, imageURL, stock, categoryId); // Insert into database
            successLabel.Visible = true;
            ClearFields();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please upload a file and select a valid category.');", true);
        }


    }

    private int GetCategoryId(string categoryName)
    {
        int categoryId = -1; // Default value if category is not found
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "SELECT category_id FROM Category WHERE category_name = @CategoryName";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@CategoryName", categoryName);

                con.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    categoryId = Convert.ToInt32(result);
                }
            }
        }

        return categoryId;
    }

    private void InsertProduct(string productName, decimal price, string imageURL, int stock, int categoryId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string insertQuery = "INSERT INTO Product (product_name, price, image_url, stock, category_id) " +
                             "VALUES (@ProductName, @Price, @ImageURL, @Stock, @CategoryId)";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, con))
            {
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@ImageURL", imageURL);
                command.Parameters.AddWithValue("@Stock", stock);
                command.Parameters.AddWithValue("@CategoryId", categoryId);

                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }

    private void ClearFields()
    {
        pname.Text = string.Empty;
        productPrice.Text = string.Empty;
        productStock.Text = string.Empty;
        productCategory.Text = string.Empty;
    }
}
