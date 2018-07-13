<%@ Page Title="Contact US" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Contact-Us.aspx.cs" Inherits="Contact_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- banner -->

<!-- contact -->
<div class="contact">
	<div class="container">
			<div class="contact-info">
				<h3><asp:Label ID="pagename" runat="server"></asp:Label></h3>
			</div>
			
        	<div class="row">
		<div class="col-sm-6 col-md-5 col-lg-4">
		<div class="contact-detail">
     <p> <asp:Label ID="pagecontent" runat="server"></asp:Label></p>		
			
			</div>	
            </div>

<div class="col-sm-6 col-md-7 col-lg-8">
		<div class="contact-map">
				<iframe src="https://www.google.com/maps/d/embed?mid=1ogYvgmiHcCCO__KM3eaovMkra5c&hl=en_US&ll=23.074712935235535%2C72.52640578175351&z=16"></iframe>
			</div>
    </div>
	</div>
	</div>
</div>
<!-- //contact -->
</asp:Content>

