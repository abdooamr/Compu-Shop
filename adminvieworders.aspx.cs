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
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            BindOrders();
        }
    }

    private void BindOrders()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "SELECT order_id, customer_name, product, address, quantity, total_price FROM [order]";
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
        Response.Redirect("adminpanel.aspx");
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
