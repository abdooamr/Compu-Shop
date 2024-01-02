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
        string brandFilter = Request.QueryString["brand"]; // New brand filter

        // Use StringBuilder for efficient string concatenation
        System.Text.StringBuilder whereClause = new System.Text.StringBuilder();

        if (!string.IsNullOrEmpty(categoryFilter))
        {
            brandDropdown.Visible = false;
            brandLabel.Visible = false;
            btnLowToHigh.Visible = false;
            btnHighToLow.Visible = false;
            whereClause.Append(" WHERE category_id = @CategoryId");
        }
        else
        {
            brandDropdown.Visible = true;
            brandLabel.Visible = true;
            btnLowToHigh.Visible = true;
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
        if (!string.IsNullOrEmpty(brandFilter))
        {
            btnLowToHigh.Visible = false;
            btnHighToLow.Visible = false;
            if (whereClause.Length > 0)
            {
                whereClause.Append(" AND");
            }
            else
            {
                whereClause.Append(" WHERE");
            }
            whereClause.Append(" brand IN (");

            // Split the brand names by comma and create parameters for each brand
            string[] brandNames = brandFilter.Split(',');
            for (int i = 0; i < brandNames.Length; i++)
            {
                whereClause.Append("@BrandName" + i);
                if (i < brandNames.Length - 1)
                {
                    whereClause.Append(",");
                }
            }

            whereClause.Append(")");
        }

        query += whereClause.ToString();
        string sort = Request.QueryString["sort"]; // Parameter for sorting

        if (sort == "low_to_high")
        {
            query += " ORDER BY price ASC"; // Sort by price in ascending order
        }
        else if (sort == "high_to_low")
        {
            query += " ORDER BY price DESC"; // Sort by price in descending order
        }

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
            if (!string.IsNullOrEmpty(brandFilter))
            {
                // Set parameters for each brand name
                string[] brandNames = brandFilter.Split(',');
                for (int i = 0; i < brandNames.Length; i++)
                {
                    command.Parameters.AddWithValue("@BrandName" + i, brandNames[i]);
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
                priceLabel.Text = "Price: " + price + " EGP";
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
    protected void brandDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Retrieve the selected brand from the dropdown
        string selectedBrand = brandDropdown.SelectedValue;

        // Redirect to the same page with brand filter in query string
        Response.Redirect("shop.aspx?brand=" + selectedBrand);
    }
    protected void btnLowToHigh_Click(object sender, EventArgs e)
    {
        Response.Redirect("shop?sort=low_to_high");
    }

    protected void btnHighToLow_Click(object sender, EventArgs e)
    {
        Response.Redirect("shop?sort=high_to_low");
    }


}
