using System;
using System.Web;
using System.Web.UI;

namespace web_project_asp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpException httpEx && httpEx.GetHttpCode() == 404.0)
            {

                // Redirect to /Pages/index.aspx for a 404 error
                Response.Redirect("~//Pages/index.aspx");
            }
        }
    }
}
