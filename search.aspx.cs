using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string searchTerm = txtSearch.Text.Trim();
        List<int> productIds = new List<int>();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            string query = "SELECT product_id FROM Product WHERE product_name LIKE @SearchTerm";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int productId = Convert.ToInt32(row["product_id"]);
                        productIds.Add(productId);
                    }

                    // Redirect to shop.aspx with product IDs as parameter
                    string productList = string.Join(",", productIds);
                    Response.Redirect($"shop.aspx?product={productList}");
                }
                else
                {
                    // No search result found
                    lblResults.Text = $"No results found for '{searchTerm}'";
                }
            }
        }
    }

}




