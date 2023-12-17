using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class usrorders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerId"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            BindOrders();
        }
    }
    private void BindOrders()
    {
        int customerId = int.Parse(Session["CustomerId"].ToString());
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        // Modify the SQL query to join 'order' table with 'Product' table to get product_name
        string query = "SELECT o.order_id, c.FirstName + ' ' + c.LastName AS customer_name, p.product_name AS product, " +
                       "o.address, o.quantity, o.total_price " +
                       "FROM [order] o " +
                       "INNER JOIN Product p ON o.product_id = p.product_id " +
                       "INNER JOIN Customers c ON o.customer_id = c.CustomerId " +
                       "WHERE o.customer_id = @customerId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@customerId", customerId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the order data to the GridView control
            customersGridView.DataSource = dataTable;
            customersGridView.DataBind();
        }
    }



    protected void backButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void customersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the order to be deleted
        int orderId = Convert.ToInt32(customersGridView.DataKeys[e.RowIndex].Value);

        // Fetch order details including product_id and quantity
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string getOrderDetailsQuery = "SELECT product_id, quantity FROM [order] WHERE order_id = @OrderId";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand getOrderDetailsCommand = new SqlCommand(getOrderDetailsQuery, connection);
            getOrderDetailsCommand.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();
            SqlDataReader reader = getOrderDetailsCommand.ExecuteReader();

            int productId = 0;
            int quantity = 0;

            if (reader.Read())
            {
                productId = Convert.ToInt32(reader["product_id"]);
                quantity = Convert.ToInt32(reader["quantity"]);
            }

            reader.Close();

            // Delete the order from the database
            string deleteOrderQuery = "DELETE FROM [order] WHERE order_id = @OrderId";
            SqlCommand deleteOrderCommand = new SqlCommand(deleteOrderQuery, connection);
            deleteOrderCommand.Parameters.AddWithValue("@OrderId", orderId);

            int rowsAffected = deleteOrderCommand.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                // Update the product's stock in the Products table
                string updateStockQuery = "UPDATE Product SET stock = stock + @Quantity WHERE product_id = @ProductId";
                SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
                updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateStockCommand.Parameters.AddWithValue("@ProductId", productId);
                updateStockCommand.ExecuteNonQuery();

                // Refresh the GridView to reflect the changes
                BindOrders();
                Label1.Text = "Order deleted successfully, quantity returned to stock.";
            }
            else
            {
                Label1.Text = "Failed to delete the order.";
            }
        }
    }


}