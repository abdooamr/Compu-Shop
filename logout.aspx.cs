using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Clear session variables
        Session.Clear();

        // Redirect the user to the desired page after logout
        Response.Redirect("index.aspx");
    }
}