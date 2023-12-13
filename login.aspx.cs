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




public partial class login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        string uid = emailbox.Text;
        string pass = passbox.Text;
        int userId = 0;
        string email = string.Empty;
        string firstName = string.Empty;
        string lastName = string.Empty;

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            string query = "SELECT * FROM Customers WHERE Email = @Email AND Password = @Password";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Email", uid);
                cmd.Parameters.AddWithValue("@Password", pass);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader["CustomerId"]);
                    firstName = reader["FirstName"].ToString();
                    lastName = reader["LastName"].ToString();
                    email = reader["Email"].ToString();

                    Session["CustomerId"] = userId;
                    Session["FirstName"] = firstName;
                    Session["LastName"] = lastName;
                    Session["Email"] = email;


                    string role = reader["IsAdmin"].ToString();



                    if (role == "True")
                    {
                        Session["isAdmin"] = true;
                        Response.Redirect("adminpanel.aspx");
                    }
                    else
                    {

                        Session["isAdmin"] = false;
                        Response.Redirect("index.aspx");


                    }
                }
                else
                {
                    Label1.Text = "Incorrect email or password.";
                }

                reader.Close();
            }



            con.Close();
        }


    }
}
