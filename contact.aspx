<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Your styles -->
    <style>
        .form-table {
     width: 100%;
     border-collapse: collapse;
     margin-bottom: 20px;
 }

 .form-table td {
     padding: 10px;
 }

 .form-table label {
     font-weight: bold;
     display: block;
     margin-bottom: 5px;
 }

 .form-table input[type="text"],
 .form-table input[type="email"],
 .form-table input[type="submit"],
 .form-table input[type="button"] {
     width: calc(100% - 20px);
     padding: 10px;
     margin-bottom: 10px;
     border: 1px solid #ccc;
     border-radius: 4px;
     box-sizing: border-box;
 }

 .error-message {
     color: red;
     font-size: 12px;
     margin-top: 5px;
 }

 .update-button {
     background-color: #007bff;
     color: #fff;
     border: none;
     padding: 10px 20px;
     border-radius: 4px;
     cursor: pointer;
     transition: background-color 0.3s ease;
 }

 .update-button:hover {
     background-color: #0056b3;
 }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
        <br />
        <h2>Contact Us</h2>
        <table class="form-table">
            <tr>
                <td><label for="txtFrom">From:</label></td>
                <td>
                    <asp:TextBox ID="txtEmail" placeholder="From" runat="server" CssClass="form-control" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td><label for="txtTo">To:</label></td>
                <td>
                    <asp:TextBox ID="txtTo" Text="compu.shop1@outlook.com" placeholder="To" runat="server" CssClass="form-control" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td><label for="txtSubject">Subject:</label></td>
                <td>
                    <asp:TextBox ID="txtSubject" placeholder="Subject" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="subjectValidator" ControlToValidate="txtSubject" ErrorMessage="Subject is required." runat="server" CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td><label for="txtMessage">Message:</label></td>
                <td>
                    <asp:TextBox ID="txtMessage" placeholder="Write your message here" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" />
                    <asp:RequiredFieldValidator ID="messageValidator" ControlToValidate="txtMessage" ErrorMessage="Message is required." runat="server" CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="sendButton" type="submit" CssClass="update-button" runat="server" OnClick="btnSend_Click" Text="Send" />
                    <asp:Label ID="lblMessage" runat="server" Text="" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" />
        <br />
        <br />
    </form>
</asp:Content>
