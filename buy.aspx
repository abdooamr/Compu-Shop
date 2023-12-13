<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="buy.aspx.cs" Inherits="buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="contact_section layout_padding">
        <h2>Product</h2>
        <div class="product-container">
            <asp:Image ID="imgProduct" runat="server" Height="400px"  style="margin-right: 10px;" />
            <div class="product-details">
                <div>
                    <label>Product Name:</label>
                    <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <label>Product Price:</label>
                    <asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label>
                </div>
                <div>
                    <form runat="server">
                        <label for="quantityy" style="display: inline;">Qty:</label>
                        <asp:TextBox type="number" ID="quantityy" runat="server" name="quantity" min="1" max="" step="1" value="1" style="display: inline;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="quantityValidator" ControlToValidate="quantityy" ErrorMessage="Quantity is required." runat="server" ForeColor="Red" Display="Dynamic" />
                        <asp:CustomValidator ID="quantityZeroValidator" ControlToValidate="quantityy" ErrorMessage="Quantity cannot be zero." OnServerValidate="QuantityZeroValidator_ServerValidate" runat="server" ForeColor="Red" Display="Dynamic" />
                       <asp:Button type="button" ID="Button1" runat="server" OnClick="btnAddToCart_Click" Text="Add to Cart" />



                        

                    </form>
                </div>
            </div>
        </div>
        <div>
            <label>Product ID:</label>
            <asp:Label ID="lblProductId" runat="server" Text=""></asp:Label>
        </div>
        <div class="message">
            <asp:Label ID="lblSuccessMessage" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
        </div>
    </section>










        <style>

        

/* Section styles */
.contact_section {
    padding: 50px 0;
    text-align: center;
    background-color: #f9f9f9;
    border-radius: 8px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

/* Product container */
.product-container {
    display: flex;
    justify-content: center;
    align-items: center;
    flex-wrap: wrap;
    padding: 20px;
    background-color: #fff;
    border-radius: 6px;
    box-shadow: 0 0 8px rgba(0, 0, 0, 0.1);
    margin-bottom: 20px;
}

/* Product details */
.product-details {
    margin-left: 20px;
}

label {
    font-weight: bold;
    display: block;
    margin-bottom: 6px;
}

input[type="number"] {
    width: 60px;
    padding: 8px;
    border: 1px solid #ccc;
    border-radius: 4px;
    transition: border-color 0.3s ease;
}

input[type="number"]:focus {
    outline: none;
    border-color: #007bff;
}

.btn-add-to-cart {
    padding: 12px 24px;
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.btn-add-to-cart:hover {
    background-color: #0056b3;
}

/* Messages */
.message {
    margin-top: 20px;
    font-style: italic;
}

.error-message {
    color: red;
}

    </style>
</asp:Content>
