



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.SessionState;

public partial class buy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   try 
       {
            if (Session["CustomerId"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
        {
            string productId = Request.QueryString["product"];
            lblProductId.Text = productId;

            // Retrieve product details from the database
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "SELECT product_name, price , image_url FROM Product WHERE product_id = @ProductID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string productName = reader["product_name"].ToString();
                            string productPrice = reader["price"].ToString();
                                string imageUrl = reader["image_url"].ToString();

                                lblProductName.Text = productName;
                                lblProductPrice.Text = productPrice;
                                imgProduct.ImageUrl = imageUrl;

                            }
                    }
                }
            }
        }
       }
        catch (Exception ex)
        {
            // Log the exception or display an error message
            lblErrorMessage.Text = "An error occurred: " + ex.Message;
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        string productId = lblProductId.Text;
        string productName = lblProductName.Text;
        string productPrice = lblProductPrice.Text;
        int custid = Convert.ToInt32(Session["CustomerId"]);
        int quantity = Convert.ToInt32(quantityy.Text); 

        
        decimal totalPrice = Convert.ToDecimal(productPrice) * quantity;

       
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string query = "INSERT INTO cart (customerid, product, quantity, total_price) VALUES (@custid, @ProductName, @quantity, @totalPrice)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@custid", custid);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@totalPrice", totalPrice);

                command.ExecuteNonQuery();
            }
        }

       
        lblSuccessMessage.Text = "Product added to cart successfully!";

        
        Response.Redirect("cart.aspx");
    

    
    lblSuccessMessage.Text = "Product added to cart successfully!";

      
        Response.Redirect("cart.aspx");
    }
    protected void QuantityZeroValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        decimal quantity;

        if (decimal.TryParse(args.Value, out quantity))
        {
            if (quantity != 0)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        else
        {
            args.IsValid = false;
        }
    }


}


/*
        // Retrieve the product name from the page
        string productName = lblProductName.Text;

        // Retrieve the quantity value
        decimal quantity = decimal.Parse(quantityy.Text);

        // Retrieve the product price
        decimal price = decimal.Parse(lblProductPrice.Text);

        // Calculate the total price
        decimal totalPrice = price * quantity;

        // Retrieve the customer ID from the session (assuming you have the customer ID stored in the session)
        int customerId = (int)Session["CustomerId"];

        // Insert the data into the database table (assuming you have a valid database connection)
        using (SqlConnection connection = new SqlConnection("your_connection_string"))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO cart (customerid, product, quantity, total_price) VALUES (@customerId, @productName, @quantity, @totalPrice)", connection);
            command.Parameters.AddWithValue("@customerId", customerId);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@quantity", quantity);
            command.Parameters.AddWithValue("@totalPrice", totalPrice);
            command.ExecuteNonQuery();
        }

        // Clear the quantity input field after adding to cart
        quantity.Text = "1";*/

