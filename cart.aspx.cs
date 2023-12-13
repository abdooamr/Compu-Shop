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

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
            if (Session["CustomerId"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
       if (!IsPostBack)
        {
            int customerId = int.Parse(Session["CustomerId"].ToString());
            // Retrieve cart data from the database or any other source
            DataTable cartData = GetCartData(customerId);

            // Bind the cart data to the GridView
            customersGridView.DataSource = cartData;
            customersGridView.DataBind();
        }

    }
    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        int customerId = int.Parse(Session["CustomerId"].ToString());

        InsertOrder(customerId);

        ClearCart(customerId);

        lblOrderStatus.Text = "Order placed successfully";
        lblOrderStatus.ForeColor = System.Drawing.Color.Green;
        lblOrderStatus.Visible = true;
        customersGridView.DataSource = null;
        customersGridView.DataBind();
        Response.Redirect("usrorders.aspx");

    }
    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("shop.aspx");
    }
    private void InsertOrder(int customerId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Retrieve cart items for the customer including product details
            DataTable cartData = GetCartData(customerId);

            // Get customer name and address from the Customers table
            string customerName = string.Empty;
            string customerAddress = string.Empty;
            string customerQuery = "SELECT FirstName, Address FROM Customers WHERE CustomerId = @CustomerId";
            SqlCommand customerCommand = new SqlCommand(customerQuery, connection);
            customerCommand.Parameters.AddWithValue("@CustomerId", customerId);
            SqlDataReader customerReader = customerCommand.ExecuteReader();

            if (customerReader.Read())
            {
                customerName = customerReader["FirstName"].ToString();
                customerAddress = customerReader["Address"].ToString();
            }

            customerReader.Close();

            foreach (DataRow row in cartData.Rows)
            {
                string productName = row["ProductName"].ToString();
                int quantity = int.Parse(row["Quantity"].ToString());
                decimal totalPrice = decimal.Parse(row["TotalPrice"].ToString());

                // Fetch current stock for the product
                string stockQuery = "SELECT stock FROM Product WHERE product_name = @ProductName";
                SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
                stockCommand.Parameters.AddWithValue("@ProductName", productName);
                int currentStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                if (currentStock >= quantity)
                {
                    // Reduce the stock after the order
                    int updatedStock = currentStock - quantity;

                    // Perform the stock update query
                    string updateStockQuery = "UPDATE Product SET stock = @UpdatedStock WHERE product_name = @ProductName";
                    SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
                    updateStockCommand.Parameters.AddWithValue("@UpdatedStock", updatedStock);
                    updateStockCommand.Parameters.AddWithValue("@ProductName", productName);
                    updateStockCommand.ExecuteNonQuery();

                    // Insert order details
                    string orderQuery = "INSERT INTO [Order] (customer_id, customer_name, address, product, quantity, total_price) VALUES (@CustomerId, @CustomerName, @CustomerAddress, @Product, @Quantity, @TotalPrice)";
                    SqlCommand command = new SqlCommand(orderQuery, connection);
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@CustomerName", customerName);
                    command.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                    command.Parameters.AddWithValue("@Product", productName);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    command.ExecuteNonQuery();
                }
                else
                {
                    // Handle insufficient stock scenario (notify the user, log, etc.)
                    // For example:
                    // Response.Write("Insufficient stock for product: " + productName);
                }
            }
        }
    }




    private void ClearCart(int customerId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Perform the delete query to remove the cart items for the customer
            string query = "DELETE FROM cart WHERE customerid = @CustomerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            command.ExecuteNonQuery();
        }
    }

    private DataTable GetCartData(int customerId)
    {
        DataTable cartData = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT product AS ProductName, quantity AS Quantity, total_price AS TotalPrice FROM cart WHERE customerid = @CustomerId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(cartData);
        }

        return cartData;
    }
    protected void customersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;

        // Assuming you have stored the customerId somewhere accessible
        int customerId = int.Parse(Session["CustomerId"].ToString());

        // Retrieve cart data
        DataTable cartData = GetCartData(customerId);

        // Remove the selected item from the cart DataTable
        if (cartData.Rows.Count > rowIndex)
        {
            cartData.Rows[rowIndex].Delete();

            // Update the cart display
            customersGridView.DataSource = cartData;
            customersGridView.DataBind();

            // Clear the entire cart and update the database
            ClearCart(customerId);
           
        }
    }


}