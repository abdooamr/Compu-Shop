<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="usrorders.aspx.cs" Inherits="usrorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="contact_section layout_padding">
        <form runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="offset-lg-2 col-md-10 offset-md-1">
                        <div class="heading_container">
                            <h2>Orders</h2>
                        </div>
                    </div>
                </div>

                <div class="layout_padding2-top">
                    <div class="row">
                        <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                            <div class="contact_form-container">
                                <div>
                                    <asp:GridView ID="customersGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="customersGridView_RowDeleting" DataKeyNames="order_id">
                                        <Columns>
                                            <asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
                                            <asp:BoundField DataField="product" HeaderText="Product" />
                                            <asp:BoundField DataField="address" HeaderText="Address" />
                                            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                                            <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Delete order" />
                                        </Columns>
                                    </asp:GridView>
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="" ></asp:Label>
                                    <br />
                                    <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </section>
</asp:Content>

