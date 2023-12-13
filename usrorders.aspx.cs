using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class usrorders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindOrders();
        }
    }
    private void BindOrders()
    {
        int customerId = int.Parse(Session["CustomerId"].ToString());
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "SELECT order_id, customer_name, product, address, quantity, total_price FROM [order] Where customer_id=@customerId ";
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

        // Fetch order details including product and quantity
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string getOrderDetailsQuery = "SELECT product, quantity FROM [order] WHERE order_id = @OrderId";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand getOrderDetailsCommand = new SqlCommand(getOrderDetailsQuery, connection);
            getOrderDetailsCommand.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();
            SqlDataReader reader = getOrderDetailsCommand.ExecuteReader();

            string productName = "";
            int quantity = 0;

            if (reader.Read())
            {
                productName = reader["product"].ToString();
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
                string updateStockQuery = "UPDATE Product SET stock = stock + @Quantity WHERE product_name = @ProductName";
                SqlCommand updateStockCommand = new SqlCommand(updateStockQuery, connection);
                updateStockCommand.Parameters.AddWithValue("@Quantity", quantity);
                updateStockCommand.Parameters.AddWithValue("@ProductName", productName);
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