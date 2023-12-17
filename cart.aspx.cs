using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerId"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else if (!IsPostBack)
        {
            int customerId = int.Parse(Session["CustomerId"].ToString());
            DataTable cartData = GetCartData(customerId);

            customersGridView.DataSource = cartData;
            customersGridView.DataBind();
        }
    }

    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        int customerId = int.Parse(Session["CustomerId"].ToString());

        DataTable cartData = GetCartData(customerId);
        bool insufficientStock = false;

        foreach (DataRow row in cartData.Rows)
        {
            int productId = Convert.ToInt32(row["product_id"]);
            int quantity = int.Parse(row["Quantity"].ToString());
            int currentStock = GetCurrentStock(productId);

            if (currentStock < quantity)
            {
                insufficientStock = true;
                string productName = row["ProductName"].ToString();
                string errorMessage = $"Insufficient stock for {productName}. Available stock: {currentStock}";
                lblOrderStatus.Text = errorMessage;
                lblOrderStatus.ForeColor = System.Drawing.Color.Red;
                lblOrderStatus.Visible = true;
                break;
            }
        }

        if (!insufficientStock)
        {
            InsertOrder(customerId);
            ClearCart(customerId);
            lblOrderStatus.Text = "Order placed successfully";
            lblOrderStatus.ForeColor = System.Drawing.Color.Green;
            lblOrderStatus.Visible = true;
            Response.Redirect("usrorders.aspx");
        }
    }

    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("shop.aspx");
    }

    protected void customersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowIndex = e.RowIndex;
        int customerId = int.Parse(Session["CustomerId"].ToString());

        DataTable cartData = GetCartData(customerId);

        if (cartData.Rows.Count > rowIndex)
        {
            cartData.Rows[rowIndex].Delete();
            customersGridView.DataSource = cartData;
            customersGridView.DataBind();

            ClearCart(customerId);
        }
    }

    private void InsertOrder(int customerId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            DataTable cartData = GetCartData(customerId);

            string customerAddress = string.Empty;
            string customerQuery = "SELECT Address FROM Customers WHERE CustomerId = @CustomerId";
            SqlCommand customerCommand = new SqlCommand(customerQuery, connection);
            customerCommand.Parameters.AddWithValue("@CustomerId", customerId);
            SqlDataReader customerReader = customerCommand.ExecuteReader();

            if (customerReader.Read())
            {
                customerAddress = customerReader["Address"].ToString();
            }

            customerReader.Close();

            foreach (DataRow row in cartData.Rows)
            {
                int productId = Convert.ToInt32(row["product_id"]);
                string productName = row["ProductName"].ToString();
                int quantity = int.Parse(row["Quantity"].ToString());
                decimal totalPrice = decimal.Parse(row["TotalPrice"].ToString());

                string stockQuery = "SELECT stock FROM Product WHERE product_id = @ProductId";
                SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
                stockCommand.Parameters.AddWithValue("@ProductId", productId);
                int currentStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                if (currentStock >= quantity)
                {
                    int updatedStock = currentStock - quantity;

                    string updateStockQuery = "UPDATE Product SET stock = @UpdatedStock WHERE product_id = @ProductId";
                    SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
                    updateStockCommand.Parameters.AddWithValue("@UpdatedStock", updatedStock);
                    updateStockCommand.Parameters.AddWithValue("@ProductId", productId);
                    updateStockCommand.ExecuteNonQuery();
                }
                else
                {
                    string errorMessage = $"Insufficient stock for {productName}. Available stock: {currentStock}";
                    lblOrderStatus.Text = errorMessage;
                    lblOrderStatus.ForeColor = System.Drawing.Color.Red;
                    lblOrderStatus.Visible = true;


                }

                // Insert order details for each item in the cart
                string orderQuery = "INSERT INTO [order] (customer_id, product_id, address, quantity, total_price) " +
                    "VALUES (@CustomerId, @ProductId, @CustomerAddress, @Quantity, @TotalPrice)";
                SqlCommand command = new SqlCommand(orderQuery, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.ExecuteNonQuery();
            }

            // Clear the cart after processing all items
            ClearCart(customerId);
        }
    }



    private void ClearCart(int customerId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

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

            string query = "SELECT c.product_id, p.product_name AS ProductName, c.quantity AS Quantity, c.total_price AS TotalPrice " +
               "FROM cart c " +
               "INNER JOIN Product p ON c.product_id = p.product_id " +
               "WHERE c.customerid = @CustomerId";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(cartData);
        }

        return cartData;
    }

    private int GetCurrentStock(int productId)
    {
        int currentStock = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string stockQuery = "SELECT stock FROM Product WHERE product_id = @ProductId";
            SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
            stockCommand.Parameters.AddWithValue("@ProductId", productId);
            object result = stockCommand.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                currentStock = Convert.ToInt32(result);
            }
        }

        return currentStock;
    }
}
