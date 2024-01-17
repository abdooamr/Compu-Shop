<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="/Pages/adminproducts.aspx.cs" Inherits="adminproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="contact_section layout_padding">
        <div class="row">
            <div class="offset-lg-2 col-md-10 offset-md-1">
                <div class="heading_container">
                    <h2>
                        Add Product
                    </h2>
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
                                    <asp:TextBox ID="pname" placeholder="Product Name" runat="server" />
                                    <asp:RequiredFieldValidator ID="pnameValidator" ControlToValidate="pname" ErrorMessage="Product Name is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:TextBox ID="productPrice" placeholder="Price" runat="server" />
                                    <asp:RegularExpressionValidator ID="priceValidator" runat="server" ControlToValidate="productPrice"
                                         ErrorMessage="Please enter a valid number" ValidationExpression="^\d+(\.\d+)?$" />
                                    <asp:RequiredFieldValidator ID="priceReqValidator" ControlToValidate="productPrice" ErrorMessage="Price is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:TextBox ID="productCategory" placeholder="Category Name" runat="server" />
                                    <asp:RequiredFieldValidator ID="categoryReqValidator" ControlToValidate="productCategory" ErrorMessage="Category Name is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:FileUpload ID="imageUpload" runat="server" />
                                    <asp:RequiredFieldValidator ID="imageUploadValidator" ControlToValidate="imageUpload" ErrorMessage="Please select an image" runat="server" ForeColor="Red" />
                                    <asp:RegularExpressionValidator ID="imageFormatValidator" ControlToValidate="imageUpload" ErrorMessage="Only JPG, JPEG, or PNG files are allowed." ValidationExpression="^.*\.(jpg|jpeg|png|JPG|JPEG|PNG)$" runat="server" ForeColor="Red" Display="Dynamic" />
                                </div>
                                <br />
                                <div>
                                    <asp:TextBox ID="productStock" placeholder="Stock" runat="server" />
                                    <asp:RegularExpressionValidator ID="stockValidator" runat="server" ControlToValidate="productStock"
                                         ErrorMessage="Please enter a valid number" ValidationExpression="^\d+$" />
                                    <asp:RequiredFieldValidator ID="stockReqValidator" ControlToValidate="productStock" ErrorMessage="Stock is required" runat="server" ForeColor="Red" />
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="submit" runat="server" OnClick="Submit_Click" Width="184px" Text="Add" />
                                    <asp:Button ID="back" runat="server" OnClick="Back_Click" Width="184px" Text="Back" />
                                </div>
                                <div>
                                    <asp:Label ID="successLabel" runat="server" Visible="false" Text="Product added successfully!" CssClass="success-message" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
