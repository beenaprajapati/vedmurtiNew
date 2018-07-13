<%@ Page Title="News" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- about -->
    <!-- about-page -->

    <div class="container">
        <div class="about-page">
            <h3>News</h3>

            <asp:Repeater ID="rpt_Product" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="media">
                        <div class="media-left" title="Click to download">
                            <a href='<%#"brochure/"+Eval("brochure_File") %>' target="_blank">
                                <img src='<%#"brochure/"+Eval("brochure_Image") %>' /></a>
                        </div>


                        <div class="media-body">
                            <h3 class="media-heading"><%#Eval("Brochure_Name") %></h3>
                            <p><%#Eval("Brochure_Content") %></p>

                        </div>
                    </div>
                    <%----%>
                </ItemTemplate>

                <FooterTemplate></FooterTemplate>
            </asp:Repeater>
            <div class="clearfix"></div>
        </div>
    </div>
</asp:Content>

