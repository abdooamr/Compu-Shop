using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class adcustomerview : System.Web.UI.Page
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
            BindCustomers();
        }
    }

    private void BindCustomers()
    {
        // Retrieve customer data from the database
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "SELECT CustomerId, firstname, lastname, email, address, city,IsAdmin FROM Customers";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Bind the customer data to the GridView control
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
        // Get the ID of the customer to be deleted
        int customerId = Convert.ToInt32(customersGridView.DataKeys[e.RowIndex].Value);

        // Delete the customer from the database
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "DELETE FROM Customers WHERE id = @CustomerId";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Refresh the GridView to reflect the changes
                BindCustomers();
                Label1.Text = "Customer deleted successfully.";
            }
            else
            {
                Label1.Text = "Failed to delete the customer.";
            }
        }
    }
    protected void addAdminButton_Click(object sender, EventArgs e)
    {
        Button addAdminButton = (Button)sender;
        int customerId = Convert.ToInt32(addAdminButton.CommandArgument);

        // Update the IsAdmin field to 1 in the database for the selected customer
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "UPDATE Customers SET IsAdmin = 1 WHERE CustomerId = @CustomerId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Successful update
                Label1.Text = "Customer promoted to admin successfully.";
            }
            else
            {
                // Failed to update
                Label1.Text = "Failed to promote customer to admin.";
            }
        }

        // Refresh the GridView after updating the admin status
        BindCustomers();
    }


    protected void removeAdminButton_Click(object sender, EventArgs e)
    {
        Button removeAdminButton = (Button)sender;
        int customerId = Convert.ToInt32(removeAdminButton.CommandArgument);

        // Update the IsAdmin field to 0 in the database for the selected customer
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        string query = "UPDATE Customers SET IsAdmin = 0 WHERE CustomerId = @CustomerId";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                // Successful update
                Label1.Text = "Admin status removed successfully.";
            }
            else
            {
                // Failed to update
                Label1.Text = "Failed to remove admin status.";
            }
        }

        // Refresh the GridView after updating the admin status
        BindCustomers();
    }

    protected void customersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            Button addAdminButton = (Button)e.Row.FindControl("addAdminButton");
            Button removeAdminButton = (Button)e.Row.FindControl("removeAdminButton");

            bool isAdmin = Convert.ToBoolean(rowView["IsAdmin"]);

            if (isAdmin)
            {
                removeAdminButton.Visible = true;
                removeAdminButton.CommandArgument = rowView["CustomerId"].ToString();
            }
            else
            {
                addAdminButton.Visible = true;
                addAdminButton.CommandArgument = rowView["CustomerId"].ToString();
            }
        }
    }

}