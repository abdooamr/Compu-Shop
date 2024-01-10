



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
    {
        try
        {
            bool shouldHideDiv = true;

            if (shouldHideDiv)
            {
                productDiv.Visible = false; // productDiv is the ID of the div containing the label
            }
            else
            {
                productDiv.Visible = true;
            }
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
                string query = "SELECT product_name, price , stock, image_url FROM Product WHERE product_id = @ProductID";

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
                                int stock = Convert.ToInt32(reader["stock"]);
                                string imageUrl = reader["image_url"].ToString();

                                lblProductName.Text = productName;
                                lblProductPrice.Text = productPrice;
                                if (stock <= 5 && stock != 0)
                                {
                                    lblProductStock.ForeColor = System.Drawing.Color.Red;
                                    lblProductStock.Text = "Hurry Up the product is running out of stock. the remaining stock is " + stock.ToString();

                                }
                                else if (stock == 0)
                                {
                                    lblProductStock.ForeColor = System.Drawing.Color.Red;
                                    lblProductStock.Text = "Out of Stock";
                                    Button1.Enabled = false;
                                }
                                else
                                {
                                    lblProductStock.ForeColor = System.Drawing.Color.Green;
                                    lblProductStock.Text = "In Stock";
                                }
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


        double totalPrice = Convert.ToDouble(productPrice) * quantity;


        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string query = "INSERT INTO cart (customerid, product_id , quantity, total_price) VALUES (@custid, @productId, @quantity, @totalPrice)";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@custid", custid);
                command.Parameters.AddWithValue("@productId", productId);
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
