using System;
using System.Web;

namespace web_project_asp
{
    public class Global : HttpApplication
    {
        // Other events and methods...

        protected void Application_Error(object sender, EventArgs e)
        {
            // Get the last error from the server
            Exception exception = Server.GetLastError();

            // Log the error (you can implement your own logging mechanism here)
            // For example, log the exception to a file, database, or external service
            // Logging.Log(exception);

            // Clear the error to prevent further handling by the default handler
            Server.ClearError();

            // Redirect to a custom error page
            Response.Redirect("index.aspx");
        }
    }
}
