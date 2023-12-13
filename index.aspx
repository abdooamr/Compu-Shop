<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="web_project_asp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!-- compu section -->

  <section class="compu_section layout_padding">
    <div class="container">

      <div class="heading_container">
        
        <h2>
          Categories
        </h2>
      </div>

    </div>

    <div class="container-fluid">

      <div class="compu_container">

        <div class="box">
          <img src="images/processor.png" alt="">

          <div class="link_box">

            <h5>
              Processor
            </h5>

            <a href="shop?category=1">
              Buy Now
            </a>

          </div>

        </div>

        <div class="box">
          <img src="images/Graphics Card.jpg" alt="">

          <div class="link_box">

            <h5>
              Graphics Card
            </h5>

            <a href="shop?category=2">
              Buy Now
            </a>

          </div>

        </div>

        <div class="box">
          <img src="images/ram.jpg" alt="">

          <div class="link_box">

            <h5>
              Ram
            </h5>

            <a href="shop?category=3">
              Buy Now
            </a>

          </div>

        </div>

        <div class="box">
          <img src="images/Motherboard.jpg" alt="">

          <div class="link_box">
            <h5>
              Motherboard
            </h5>

            <a href="shop?category=4">
              Buy Now
            </a>

          </div>

        </div>

        <div class="box">
          <img src="images/Storage.jpg" alt="">

          <div class="link_box">
            <h5>
              Storage
            </h5>
            <a href="shop?category=5">
              Buy Now
            </a>
          </div>

        </div>

        <div class="box">
          <img src="images/PowerSupply.jpg" alt="">

          <div class="link_box">
            <h5>
              Power Supply
            </h5>
            <a href="shop?category=6">
              Buy Now
            </a>
          </div>

        </div>

      </div>
    </div>
  </section>

  <!-- end compu section -->




 


  



  <!-- footer section -->
  <section class="container-fluid footer_section ">
    
  </section>
  <!-- footer section -->

  <script type="text/javascript" src="js/jquery-3.4.1.min.js"></script>
  <script type="text/javascript" src="js/bootstrap.js"></script>
  <script type="text/javascript" src="js/custom.js"></script>
</asp:Content>
