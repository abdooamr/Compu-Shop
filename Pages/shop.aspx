<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeFile="/Pages/shop.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <section class="compu_section layout_padding">
            <div class="container">
                <div class="heading_container"></div>
            </div>



            <div class="container-fluid">
                <div>
                    <asp:Label runat="server" ID="brandLabel" for="brandDropdown">Select Brand:</asp:Label>
                    <asp:DropDownList ID="brandDropdown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="brandDropdown_SelectedIndexChanged"
                        Style="width: 15%; padding: 8px; font-size: 16px; border: 1px solid #ccc; border-radius: 4px; background-color: #fff; color: #333; cursor: pointer; transition: border-color 0.3s ease-in-out;">
                        <asp:ListItem Text="-- Select Brand --" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="AMD" Value="AMD"></asp:ListItem>
                        <asp:ListItem Text="AORUS" Value="AORUS"></asp:ListItem>
                        <asp:ListItem Text="ASUS" Value="ASUS"></asp:ListItem>
                        <asp:ListItem Text="COOLER MASTER" Value="COOLER MASTER"></asp:ListItem>
                        <asp:ListItem Text="Corsair" Value="Corsair"></asp:ListItem>
                        <asp:ListItem Text="Cougar" Value="Cougar"></asp:ListItem>
                        <asp:ListItem Text="GIGABYTE" Value="GIGABYTE"></asp:ListItem>
                        <asp:ListItem Text="INTEL" Value="INTEL"></asp:ListItem>
                        <asp:ListItem Text="KINGSTON" Value="KINGSTON"></asp:ListItem>
                        <asp:ListItem Text="MSI" Value="MSI"></asp:ListItem>
                        <asp:ListItem Text="SAMSUNG" Value="SAMSUNG"></asp:ListItem>
                        <asp:ListItem Text="SEAGATE" Value="SEAGATE"></asp:ListItem>
                        <asp:ListItem Text="WD" Value="WD"></asp:ListItem>
                        <asp:ListItem Text="XIGMATEK" Value="XIGMATEK"></asp:ListItem>
                        <asp:ListItem Text="XPG" Value="XPG"></asp:ListItem>

                    </asp:DropDownList>
                    <asp:Button ID="btnLowToHigh" runat="server" Text="Sort Low to High" CssClass="btn-sort" OnClick="btnLowToHigh_Click" />
                    <asp:Button ID="btnHighToLow" runat="server" Text="Sort High to Low" CssClass="btn-sort" OnClick="btnHighToLow_Click" />



                </div>


                <asp:Panel ID="compu_container" CssClass="compu_container" runat="server">
                </asp:Panel>
            </div>
        </section>
    </form>
</asp:Content>
