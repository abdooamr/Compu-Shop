<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="adminrestock.aspx.cs" Inherits="adminrestock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="contact_section layout_padding">
        <div class="row">
            <div class="offset-lg-2 col-md-10 offset-md-1">
                <div class="heading_container">
                    <h2>
                        Admin Restock
                    </h2>
                </div>
            </div>
        </div>

        <div class="layout_padding2-top">
            <div class="row">
                <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                    <form id="formRestock" runat="server">
                        <div class="contact_form-container">
                            <div>
                                <div>
                                    <asp:TextBox ID="productIdTextBox" placeholder="Product ID" runat="server" />
                                    <asp:RequiredFieldValidator ID="productIdValidator" ControlToValidate="productIdTextBox" ErrorMessage="Product ID is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:TextBox ID="newStockTextBox" placeholder="New Stock" runat="server" />
                                    <asp:RegularExpressionValidator ID="newStockValidator" runat="server" ControlToValidate="newStockTextBox"
                                         ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" />
                                    <asp:RequiredFieldValidator ID="newStockReqValidator" ControlToValidate="newStockTextBox" ErrorMessage="New Stock is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="restockButton" runat="server" OnClick="RestockButton_Click" Width="184px" Text="Restock" />
                                    <asp:Button ID="backButton" runat="server" OnClick="BackButton_Click" Width="184px" Text="Back" />
                                </div>
                                <div>
                                    <asp:Label ID="restockSuccessLabel" runat="server" Visible="false" Text="Restocked successfully!" CssClass="success-message" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
