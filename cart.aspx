<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <div>
                                    <!-- Add your radio button list here -->
                                    <asp:RadioButtonList ID="paymentTypeRadioButtonList" runat="server" RepeatDirection="Horizontal" CssClass="payment-options" onchange="toggleCreditCardForm()">
                                        <asp:ListItem Text='<img src="images/COD.jpg" alt="COD" /> Cash On Delivery' Value="COD" Selected="True" />
                                        <asp:ListItem Text='<img src="images/CARD.jpg" alt="Card" />Credit/Debit Card' Value="CARD" />
                                    </asp:RadioButtonList>

                                </div>
                                <div id="creditCardForm" style="display: none;">
                                    <div class="credit-card-info--form">
                                        <div class="input_container">
                                            <label for="txtFullName" class="input_label">Card holder full name</label>
                                            <asp:TextBox ID="txtFullName" CssClass="input_field" runat="server" placeholder="Enter your full name"></asp:TextBox>
                                        </div>
                                        <div class="input_container">
                                            <label for="txtCardNumber" class="input_label">Card Number</label>
                                            <asp:TextBox ID="txtCardNumber" CssClass="input_field" runat="server" placeholder="0000 0000 0000 0000"></asp:TextBox>
                                        </div>
                                        <div class="input_container">
                                            <label for="txtExpiryDate" class="input_label">Expiry Date</label>
                                            <div class="split">
                                                <asp:TextBox ID="txtExpiryDate" CssClass="input_field" runat="server" placeholder="MM/YY"></asp:TextBox>
                                                <asp:TextBox ID="txtCVV" CssClass="input_field" runat="server" placeholder="CVV"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <br />
                                <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" OnClick="btnPlaceOrder_Click" OnClientClick="return onPlaceOrderButtonClick();" />
                                <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
                                <asp:Label ID="lblOrderStatus" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>

    </section>
    <script>
        function toggleCreditCardForm() {
            var creditCardForm = document.getElementById('creditCardForm');
            var radioButton = document.getElementById('<%= paymentTypeRadioButtonList.ClientID %>');

            if (radioButton) {
                var selectedValue = radioButton.querySelector('input[type="radio"]:checked').value;

                if (selectedValue === 'CARD') {
                    creditCardForm.style.display = 'block'; // Show the credit card form
                } else {
                    creditCardForm.style.display = 'none'; // Hide the credit card form
                }
            }
        }
    </script>
</asp:Content>
