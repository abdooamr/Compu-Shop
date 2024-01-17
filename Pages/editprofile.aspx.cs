using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class editprofile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["CustomerId"] == null)
        {
            // Redirect the user to the login page or any other appropriate page
            Response.Redirect("/Pages/login.aspx");
        }

        if (!IsPostBack)
        {
            // Retrieve the user's existing profile information
            int userId = GetLoggedInUserId(); // Implement this method to get the logged-in user's ID

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string query = "SELECT FirstName, LastName, Email, City, Address FROM Customers WHERE CustomerId = @userId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtemail.Text = reader["Email"].ToString();
                            txtCity.Text = reader["City"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                        }
                    }
                }
            }
        }
    }


    protected void btnEditUsername_Click(object sender, EventArgs e)
    {
        try
        {
            // Retrieve the updated profile information
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Email = txtemail.Text;
            string City = txtCity.Text;
            string Address = txtAddress.Text;

            // Update the table with the new profile information
            int userId = GetLoggedInUserId(); // Implement this method to get the logged-in user's ID

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                con.Open();
                string query = "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Email=@Email, City=@City, Address=@Address WHERE CustomerId=@userId";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@userId", userId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Profile updated successfully
                        Labelmsg.Text = "Profile updated successfully!";
                    }
                    else
                    {
                        // Profile update failed
                        Labelmsg.Text = "Failed to update profile. Please try again.";
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

    // Implement this method to get the logged-in user's ID
    private int GetLoggedInUserId()
    {
        int id = (int)Session["CustomerId"];
        return id;
    }
}
