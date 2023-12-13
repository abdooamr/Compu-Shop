using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string query = "SELECT product_id, product_name, price, image_url FROM Product";
        string categoryFilter = Request.QueryString["category"];
        string productFilter = Request.QueryString["product"];

        // Use StringBuilder for efficient string concatenation
        System.Text.StringBuilder whereClause = new System.Text.StringBuilder();

        if (!string.IsNullOrEmpty(categoryFilter))
        {
            whereClause.Append(" WHERE category_id = @CategoryId");
        }
        if (!string.IsNullOrEmpty(productFilter))
        {
            if (whereClause.Length > 0)
            {
                whereClause.Append(" AND");
            }
            else
            {
                whereClause.Append(" WHERE");
            }
            whereClause.Append(" product_id IN(");

            // Split the product IDs by comma and create parameters for each ID
            string[] productIds = productFilter.Split(',');
            for (int i = 0; i < productIds.Length; i++)
            {
                whereClause.Append("@ProductId" + i);
                if (i < productIds.Length - 1)
                {
                    whereClause.Append(",");
                }
            }

            whereClause.Append(")");
        }

        query += whereClause.ToString();

        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            SqlCommand command = new SqlCommand(query, con);

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                command.Parameters.AddWithValue("@CategoryId", categoryFilter);
            }
            if (!string.IsNullOrEmpty(productFilter))
            {
                // Set parameters for each product ID
                string[] productIds = productFilter.Split(',');
                for (int i = 0; i < productIds.Length; i++)
                {
                    command.Parameters.AddWithValue("@ProductId" + i, productIds[i]);
                }
            }

            con.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int productId = Convert.ToInt32(reader["product_id"]);
                string productName = reader["product_name"].ToString();
                string imageUrl = reader["image_url"].ToString();
                string price = reader["price"].ToString();

                // Create the product elements
                Panel productPanel = new Panel();
                productPanel.CssClass = "box";

                Image productImage = new Image();
                productImage.ImageUrl = imageUrl;
                productImage.AlternateText = "";
                productPanel.Controls.Add(productImage);

                Panel linkBox = new Panel();
                linkBox.CssClass = "link_box";

                Label productNameLabel = new Label();
                productNameLabel.ID = "productname";
                productNameLabel.Text = productName;
                linkBox.Controls.Add(productNameLabel);

                Label priceLabel = new Label();
                priceLabel.Text = "Price: " + price;
                linkBox.Controls.Add(priceLabel);

                // Add more controls as needed

                HyperLink buyNowLink = new HyperLink();
                buyNowLink.NavigateUrl = "buy.aspx?product=" + productId;
                buyNowLink.Text = "Buy Now";
                linkBox.Controls.Add(buyNowLink);

                productPanel.Controls.Add(linkBox);

                // Add the product panel to the compu_container
                compu_container.Controls.Add(productPanel);
            }

            reader.Close();
        }
    }
}
