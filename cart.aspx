<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="contact_section layout_padding">
        <form runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="offset-lg-2 col-md-10 offset-md-1">
                        <div class="heading_container">
                            <h2>Cart</h2>
                        </div>
                    </div>
                </div>

                <div class="layout_padding2-top">
                    <div class="row">
                        <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                            <div class="contact_form-container">
                                <div>
                                    <asp:GridView ID="customersGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="customersGridView_RowDeleting">
    <Columns>
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this item?');" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-danger btn-sm" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

                                    <br />
                                    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" />
                                    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
                                    <asp:Label ID="lblOrderStatus" runat="server" Text="" Visible="false"></asp:Label>

                                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </section>
</asp:Content>
