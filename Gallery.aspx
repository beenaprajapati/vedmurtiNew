<%@ Page Title="Gallery" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link rel="stylesheet" type="text/css" href="css/component.css" />
<link rel="stylesheet" href="css/lightbox.css" type="text/css" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!-- banner -->

<!-- about -->
<!-- about-page -->
<div class="about-page">
<h3>Gallery</h3>
<div class="container">
	<div class="gallery">
	
	<div class="container">
		<div class="gallery-bottom row">
                    <asp:Repeater ID="rpt_Product" runat="server">
                    <ItemTemplate>
							<div class="col-xs-6 col-sm-4 col-md-3">
							<div class="gallery-grid">
								<a class="example-image-link" href='<%#"Gallery/"+Eval("Gallery_Image") %>' data-lightbox="example-set" data-title="Click the right half of the image to move forward."><img class="example-image" src='<%#"Gallery/"+Eval("Gallery_Image") %>' alt=""/></a>
							</div>
                                </div>
							</ItemTemplate>
                            </asp:Repeater>
							<div class="clearfix"> </div>
		</div>
	</div>
</div>

					
  </div>
					<div class="clearfix"> </div>
			</div>
</asp:Content>

