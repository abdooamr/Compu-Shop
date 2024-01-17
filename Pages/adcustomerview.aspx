<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="/Pages/adcustomerview.aspx.cs" Inherits="adcustomerview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="contact_section layout_padding">
        <form runat="server">
            <div class="container-fluid">
                <div class="row">
                    <div class="offset-lg-2 col-md-10 offset-md-1">
                        <div class="heading_container">
                            <h2>Customers</h2>
                        </div>
                    </div>
                </div>

                <div class="layout_padding2-top">
                    <div class="row">
                        <div class="col-lg-4 offset-lg-2 col-md-5 offset-md-1">
                            <div class="contact_form-container">
                                <div>
                                    <asp:GridView ID="customersGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="customersGridView_RowDeleting" OnRowDataBound="customersGridView_RowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" ReadOnly="True" />
                                            <asp:BoundField DataField="firstname" HeaderText="First Name" />
                                            <asp:BoundField DataField="lastname" HeaderText="Last Name" />
                                            <asp:BoundField DataField="email" HeaderText="Email" />
                                            <asp:BoundField DataField="address" HeaderText="Address" />
                                            <asp:BoundField DataField="city" HeaderText="City" />
                                            <asp:BoundField DataField="IsAdmin" HeaderText="Is Admin" />
                                            <asp:TemplateField HeaderText="Actions">
                                                <ItemTemplate>
                                                    <asp:Button ID="addAdminButton" runat="server" Text="Add Admin" CommandName="AddAdmin" OnClick="addAdminButton_Click"
                                                        Visible='<%# Eval("IsAdmin").ToString().ToLower() == "false" %>'
                                                        CssClass="btn btn-success" />
                                                    <!-- Green color for Add Admin -->
                                                    <asp:Button ID="removeAdminButton" runat="server" Text="Remove Admin" CommandName="RemoveAdmin" OnClick="removeAdminButton_Click"
                                                        Visible='<%# Eval("IsAdmin").ToString().ToLower() == "true" %>'
                                                        CssClass="btn btn-danger" />
                                                    <!-- Red color for Remove Admin -->
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
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
