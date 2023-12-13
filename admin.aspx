<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <!-- contact section -->
    <section class="contact_section layout_padding">
        <div class="container-fluid">
            <div class="row">
                <div class="offset-lg-2 col-md-10 offset-md-1">
                    <div class="heading_container">
                        
                        <h2 >
                            Admin Login 
                        </h2>
                    </div>
                </div>
            </div>

            <div class="layout_padding2-top">
                <div class="row">
                    <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                        <form id="form1" runat="server">
                            <div class="contact_form-container">
                                <div>
                                    <div>
                                       <asp:TextBox ID="emailbox" TextMode="Email" placeholder="Email" runat="server" />
                                         <asp:RequiredFieldValidator ID="emailRequiredValidator" ControlToValidate="emailbox" ErrorMessage="Email is required." runat="server" ForeColor="Red" />
                                        <asp:RegularExpressionValidator ID="emailFormatValidator" ControlToValidate="emailbox" ErrorMessage="Invalid email format." ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" runat="server" ForeColor="Red" />
                                    </div>
                                    <div>
                                      <asp:TextBox ID="passbox" TextMode="Password" placeholder="Password" runat="server" />
                                    <asp:RequiredFieldValidator ID="passwordValidator" ControlToValidate="passbox" ErrorMessage="Password is required." runat="server" ForeColor="Red" />
                                        </div>


                                    <div>
                                         <asp:Button ID="loginbutton" runat="server" OnClick="Admin_Click" Text="Login" />
                                         
                                    </div>
               

                                </div>
                            </div>
                        </form>
                    </div>
                   
                </div>
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
    </section>
    <!-- end contact section -->

  


    <script type="text/javascript" src="js/jquery-3.4.1.min.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
</asp:Content>

