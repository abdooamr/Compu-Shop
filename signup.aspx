<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Signup section -->
    <section class="contact_section layout_padding">
        <div class="container-fluid">
            <div class="row">
                <div class="offset-lg-2 col-md-10 offset-md-1">
                    <div class="heading_container">
                        <h2>Signup</h2>
                    </div>
                </div>
            </div>

            <div class="layout_padding2-top">
                <div class="row">
                    <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                        <form id="form2" runat="server">
                            <div class="contact_form-container">
                                <div>
                                    <div>
                                        <asp:TextBox ID="firstnamebox" CssClass="input" placeholder="First Name" runat="server" />
                                        <asp:RequiredFieldValidator ID="firstnameValidator" ControlToValidate="firstnamebox" ErrorMessage="First name is required." runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="lastnamebox" CssClass="input" placeholder="Last Name" runat="server" />
                                        <asp:RequiredFieldValidator ID="lastnameValidator" ControlToValidate="lastnamebox" ErrorMessage="Last name is required." runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="emailbox" CssClass="input" TextMode="Email" placeholder="Email" runat="server" />
                                        <asp:RequiredFieldValidator ID="emailRequiredValidator" ControlToValidate="emailbox" ErrorMessage="Email is required." runat="server" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="emailFormatValidator" ControlToValidate="emailbox" ErrorMessage="Invalid email format." ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="addressbox" CssClass="input" placeholder="Address" runat="server" />
                                        <asp:RequiredFieldValidator ID="addressvalidator" ControlToValidate="addressbox" ErrorMessage="Address is required." runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="citybox" CssClass="input" placeholder="City" runat="server" />
                                        <asp:RequiredFieldValidator ID="cityValidator" ControlToValidate="citybox" ErrorMessage="City is required." runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:TextBox ID="passbox" CssClass="input" TextMode="Password" placeholder="Password" runat="server" />
                                        <asp:RequiredFieldValidator ID="passwordValidator" ControlToValidate="passbox" ErrorMessage="Password is required." runat="server" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="passwordRegexValidator" ControlToValidate="passbox" ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase and one lowercase letter." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z]).{8,}$" runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                        <asp:Button ID="signupbutton" runat="server" OnClick="Signup_Click" Text="Create account" CssClass="form-btn" />
                                        <label>Have an account? Login <a href="login.aspx" class="sign-up-link">Here</a></label>
                                    </div>

                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </section>
    <!-- End Signup section -->

    <!-- Footer section -->
    <section class="container-fluid footer_section">
        <!-- Your footer content here -->
    </section>
    <!-- End Footer section -->

    <!-- Include your JavaScript files here -->
    <script type="text/javascript" src="js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
</asp:Content>
