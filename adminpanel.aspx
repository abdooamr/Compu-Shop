<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="adminpanel.aspx.cs" Inherits="adminpanel" %>

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
                            Admin Panel 
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
                                         <asp:Button ID="usersbutton" runat="server"  Text="View Customers" OnClick="adcustomerview_Click"/>
                                         <asp:Button ID="productsButton" runat="server"  Text="Add Products"  OnClick="adminproducts_Click" />
                                         <asp:Button ID="restockButton" runat="server"  Text="Restock Products"  OnClick="adminrestock_Click" />
                                         <asp:Button ID="ordersButton" runat="server"  Text="View Orders" OnClick="adminview_Click"/>

                                         
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

</asp:Content>

