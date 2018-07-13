<%@ Page Title="Download" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- banner -->

    <!-- about -->
    <!-- about-page -->
    <div class="about-page">
        <h3>Download</h3>
        <div class="container">
            <div class="row">
                <div class="broucher">

                    <asp:Repeater ID="rpt_Product" runat="server">
                        <ItemTemplate>
                            <div class="download-broucher">

                                <h3><%#Eval("download_name") %></h3>
                                <a href='<%#"download/"+Eval("download_file") %>' target="_blank">
                                    <img src="images/pdflogo.png" /></a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPage"
                        Style="padding: 8px; margin: 2px;border: solid 1px #666;  font-weight: bold"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server" Font-Bold="True"><%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
                    <%--<div class="download-broucher">	
<h3>Product Broucher </h3>
		<a href="download/Leaflet.pdf"> <img src="images/pdflogo.png"/></a>
			
			<div class="clearfix"></div>
		</div>--%>
                </div>
            </div>

        </div>
    </div>
    <!-- test -->
</asp:Content>

