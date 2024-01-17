<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="/Pages/editprofile.aspx.cs" Inherits="editprofile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">
        <br />
        <h2>Edit Profile</h2>
        <table class="form-table">
            <tr>
                <td>
                    <label for="txtFirstName">First Name:</label></td>
                <td>
                    <asp:TextBox ID="txtFirstName" placeholder="First Name" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="nameValidator" ControlToValidate="txtFirstName" ErrorMessage="First Name is required." runat="server" CssClass="error-message" />
                    <asp:RegularExpressionValidator ID="nameFormatValidator" ControlToValidate="txtFirstName" ErrorMessage="Invalid First Name format. Only letters are allowed." ValidationExpression="^[a-zA-Z]+$" runat="server" CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtLastName">Last Name:</label></td>
                <td>
                    <asp:TextBox ID="txtLastName" placeholder="Last Name" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="nameValidator2" ControlToValidate="txtLastName" ErrorMessage="Last Name is required." runat="server" CssClass="error-message" />
                    <asp:RegularExpressionValidator ID="nameFormatValidator2" ControlToValidate="txtLastName" ErrorMessage="Invalid Last Name format. Only letters are allowed." ValidationExpression="^[a-zA-Z]+$" runat="server" CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtemail">E-mail:</label></td>
                <td>
                    <asp:TextBox ID="txtemail" TextMode="Email" placeholder="Email" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="emailRequiredValidator" ControlToValidate="txtemail" ErrorMessage="Email is required." runat="server" CssClass="error-message" />
                    <asp:RegularExpressionValidator ID="emailFormatValidator" ControlToValidate="txtemail" ErrorMessage="Invalid email format." ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" runat="server" CssClass="error-message" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtCity">City:</label></td>
                <td>
                    <asp:TextBox ID="txtCity" placeholder="City" runat="server" CssClass="form-control" />
                    <!-- You can add validators for city if required -->
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtAddress">Address:</label></td>
                <td>
                    <asp:TextBox ID="txtAddress" placeholder="Address" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                    <!-- You can add validators for address if required -->
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="updatebtn" type="submit" CssClass="update-button" runat="server" OnClick="btnEditUsername_Click" Text="Update" />
                </td>

                <td>
                    <asp:Label ID="Labelmsg" runat="server" Text="" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" />
        <asp:Label ID="Labelid" runat="server" Text="" />
        <br />
        <br />
    </form>
</asp:Content>
