<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="adminrestock.aspx.cs" Inherits="adminrestock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <form id="form1" runat="server">
        <section class="contact_section layout_padding">
            <!-- Your HTML content -->
            <div class="row">
                <div class="offset-lg-2 col-md-10 offset-md-1">
                    
                </div>
            </div>

            <div class="layout_padding2-top">
                <div class="row">
                    <div class="col-lg-8 offset-lg-2 col-md-10 offset-md-1">
                        <!-- Display Products in GridView -->
                        <asp:GridView ID="productsGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="ProductsGridView_RowCommand" CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="product_id" HeaderText="Product ID" ReadOnly="True" ItemStyle-CssClass="table-header" />
        <asp:BoundField DataField="product_name" HeaderText="Product Name" ReadOnly="True" ItemStyle-CssClass="table-header" />
        <asp:BoundField DataField="stock" HeaderText="Stock" ReadOnly="True" ItemStyle-CssClass="table-header" />
        <asp:TemplateField HeaderText="Restock" ItemStyle-CssClass="table-header">
            <ItemTemplate>
                <div class="input-group">
                    <asp:TextBox ID="restockQuantityTextBox" runat="server" placeholder="Quantity" CssClass="form-control" Width="50"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button runat="server" CommandName="Restock" CommandArgument="<%# Container.DataItemIndex %>" Text="Restock" CssClass="btn btn-primary" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

                        <asp:Label ID="restockSuccessLabel" runat="server" Visible="false" Text="Restocked successfully!" CssClass="success-message" />
                        <asp:Label ID="restockErrorLabel" runat="server" Visible="false" Text="" CssClass="error-message" />
                    </div>
                </div>
            </div>
        </section>
    </form>
</asp:Content>
