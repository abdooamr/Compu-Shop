using System;
using System.Net;
using System.Net.Mail;
using System.Web.UI;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if the user is logged in
            if (Session["CustomerId"] != null)
            {
                string loggedInUserEmail = GetLoggedInUserEmail(); // Get the logged-in user's email
                txtEmail.Text = loggedInUserEmail; // Populate the 'From' field with the user's email
            }
            else
            {
                Response.Redirect("/Pages/login.aspx");
            }

        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            // Get the values entered by the user in the form
            string senderEmail = txtEmail.Text.Trim();
            string recipientEmail = "compu.shop1@outlook.com"; // Your email address
            string messageSubject = txtSubject.Text.Trim();
            string messageBody = txtMessage.Text.Trim();

            // Set up the SMTP client to send an email
            SmtpClient smtpClient = new SmtpClient("server.com"); // Replace with your SMTP server
            smtpClient.Port = 587; // Replace with your SMTP port
            smtpClient.Credentials = new NetworkCredential("email", "password"); // Replace with your credentials
            smtpClient.EnableSsl = true; // Enable SSL if your SMTP server requires it

            // Set up the email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(senderEmail);
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = messageSubject;
            mailMessage.Body = messageBody;

            // Send the email
            smtpClient.Send(mailMessage);

            // Display a success message or redirect to a thank you page
            lblMessage.Text = "Your message has been sent successfully!";
        }
        catch (Exception ex)
        {
            // Display an error message or log the exception
            lblMessage.Text = "An error occurred while sending your message. Please try again later." + ex;
        }
    }

    // Implement this method to get the logged-in user's email
    private string GetLoggedInUserEmail()
    {
        string userEmail = string.Empty;
        if (Session["Email"] != null)
        {
            userEmail = Session["Email"].ToString();
        }
        return userEmail;
    }

}
