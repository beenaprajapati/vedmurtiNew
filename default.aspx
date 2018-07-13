<%@ Page Title="Vedmurti Corporation" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="banner">
        <asp:Repeater ID="bannerID" runat="server">
            <HeaderTemplate>
                <ul class="rslides" id="slider3">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <img alt="" src='<%#"banner/"+Eval("banner_image") %>' /></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <!----banner script 15/2/1015--->


    <!-- welcome -->
    <div class="welcome">
        <div class="container">
            <div class="wel-header">
                <h3>
                    <asp:Label ID="pagename" runat="server"></asp:Label></h3>
                <p>
                    <asp:Label ID="pagecontent" runat="server"></asp:Label>
                    <br />
                </p>

                <div class="button-read">
                    <a href="Aboutus.aspx">Read More </a>
                </div>
            </div>
        </div>
    </div>
    <!-- //welcome -->


<!-- pests control -->
    <div class="pests">

			<div class="container">
   <div class="pests-header">
                <h3><span class="pesttitle">Vedmurti Fertilizers</span></h3>
				<nav class="slidernav">
      <div id="navbtns" class="clearfix">
        <a href="#" class="previous"><span class="glyphicon glyphicon-menu-left"></span></a>
        <a href="#" class="next"><span class="glyphicon glyphicon-menu-right"></span></a>
      </div>
    </nav>
                
            </div>
    
    
    <div class="crsl-items" data-navigation="navbtns">
      <div class="crsl-wrap">
        
		<asp:Repeater ID="rpt_Product" runat="server">
            <ItemTemplate>
                <div class="crsl-item">
                <div class="thumbnail">
                       <a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>
                                <img src='<%#"Product/"+Eval("Product_Image") %>' alt="" class="img img-thumbnail" height="100px" width="100px" /></a>
                </div>
                <div class="description1">
                    <h2> <a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'><%#Eval("Product_Name") %></a></h2>
                    <p><%#LimitContent(Eval("Product_Description")) %></p>
                   
                </div>
                        <a class="button-read1" href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>Read More</a>
                    </div>
            </ItemTemplate>
		</asp:Repeater>
            
			
        <!-- post #5 -->
		

        
      </div>
    </div>
    
  </div>
			</div>
    <!-- //pests control -->
    </div>
   <div class="clearfix"></div>
    <!-- news -->
    <div class="news">
        <div class="container">
            <div class="news-text">
                <h3>NEWS</h3>
                <p></p>
            </div>
            <div class="news-grids">

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>

                        <div class="col-md-3 news-grid mask">
                            <a href="News.aspx">
                                <h4><%#Eval("Brochure_Name") %> </h4>
                            </a>
                            
                            <a href="News.aspx" class="mask">
                                <img src='<%#"brochure/"+Eval("brochure_Image") %>' alt="image" class="img-responsive zoom-img"></a>
                            <div class="news-info">
                                <p><%#Eval("Brochure_Content") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    <!-- //news -->

    <!--FlexSlider-->
   
    <!--FlexSlider-->
</asp:Content>

