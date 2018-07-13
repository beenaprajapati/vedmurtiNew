<%@ Page Title="Product" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <script src="js/jquery.chocolat.js" type="text/javascript"></script>
   <%-- <script type="text/javascript">
        $(function () {
            $('.moments-bottom a').Chocolat();
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- gallery -->
    <%--<div class="moments">
        <h3>Products</h3>
        <div class="container">
    --%>
    <div class="container">
        <div class="moments">
            <asp:Repeater ID="rpt_Product" runat="server" OnItemDataBound="rpt_Product_ItemDataBound">
                <HeaderTemplate>
                    <div class="row">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-6 col-md-4 moments-left">
                        <div class="moments-left1">
                            <div class="thumbnail">
                                <a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>
                                    <img src='<%#"Product/"+Eval("Product_IMage") %>' alt="image" />
                                </a>
                            </div>
                            <div class="description1">
                                <h2><a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'><%#Eval("Product_Name") %></a></h2>
                                <p><%#LimitContent(Eval("Product_Description"))%></p>
                            </div>
                            <a class="button-read1" href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>Read More</a>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                        <div id="dvNoRecords" runat="server" visible="false" style="padding:20px 20px; text-align:center; color:Red;">
        No records to display.
        </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            <br />
            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPage"
                        Style="padding: 8px; margin: 2px; border: solid 1px #666; font-weight: bold"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                        runat="server" Font-Bold="True"><%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
            <%-- </div>
    </div>--%>
        </div>
    </div>
</asp:Content>

