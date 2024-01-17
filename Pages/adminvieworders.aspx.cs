using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class adminvieworders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isAdmin"] == null || !(bool)Session["isAdmin"])
        {
            // Redirect the user to the login page or any other appropriate page
            Response.Redirect("/Pages/login.aspx");
        }
        if (!IsPostBack)
        {
            BindOrders();
        }
    }

    private void BindOrders()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "SELECT o.order_id, c.FirstName + ' ' + c.LastName AS customer_name, p.product_name AS product, " +
                       "o.address, o.quantity, o.total_price " +
                       "FROM [order] o " +
                       "INNER JOIN Product p ON o.product_id = p.product_id " +
                       "INNER JOIN Customers c ON o.customer_id = c.CustomerId";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
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
        Response.Redirect("/Pages/adminpanel.aspx");
    }

    protected void customersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the order to be deleted
        int orderId = Convert.ToInt32(customersGridView.DataKeys[e.RowIndex].Value);

        // Delete the order from the database
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "DELETE FROM [order] WHERE order_id = @OrderId";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@OrderId", orderId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Refresh the GridView to reflect the changes
                BindOrders();
                Label1.Text = "Order deleted successfully.";
            }
            else
            {
                Label1.Text = "Failed to delete the order.";
            }
        }
    }
}
