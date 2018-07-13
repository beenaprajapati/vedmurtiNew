<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .availablespan {
            color: #444;
            FONT-SIZE: 16px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="moments">
        <div class="container">
            <script src="js/jquery.chocolat.js" type="text/javascript"></script>

            <!--light-box-files -->
            <%--<script type="text/javascript">
                $(function () {
                    $('.moments-bottom a').Chocolat();
                });
            </script>--%>


            <div class="row">

                <asp:Repeater ID="rptdata" runat="server" OnItemDataBound="rptdata_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="product service-image-left">
                                <center>
                                    <img src='<%#"Product/"+Eval("Product_Image") %>' /></center>
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="material-view">
                                <asp:HiddenField ID="h1" runat="server" Value='<%#Eval("product_id") %>' Visible="false" />

                                <div class="product-title"><%#Eval("Product_Name") %></div>
                                <div class="product-desc"><%#Eval("Product_Description") %></div>
                                <%--<div class="">Availability:<asp:Label ID="lblmessage" runat="server"></asp:Label></div>--%>
                                <div class="product-price" id="price" runat="server">
                                    &#8377;
                                    <asp:Label ID="lblprice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                </div>
                                <div class="qty-div" id="stock" runat="server">
                                    <span class="availablespan">Availability:</span><asp:Label ID="lblmsg" runat="server" ForeColor="#888886" Style="padding: 5px;"></asp:Label>

                                </div>
                                <div class="qty-div" id="cart" runat="server">
                                    <asp:DropDownList ID="ddllise" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:HiddenField ID="hdnmaxqty" runat="server" Value='<%#Eval("MaxQuantity") %>' Visible="false" />
                                    <asp:HiddenField runat="server" ID="txtqty" Value='<%#Eval("StockQuantity") %>'></asp:HiddenField>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Quantity is required" ControlToValidate="txtqty" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>--%>

                                    <asp:HiddenField ID="hdnstock" runat="server" Value='<%#Eval("AvailableStock") %>' Visible="false" />
                                    <%--<asp:TextBox ID="HiddenField1" runat="server" Text='<%#Eval("AvailableStock") %>' Visible="false" />--%>
                                    <%--<asp:Button ID="btnaddtocart" class="btn btn-success" runat="server" OnClick="btnaddtocart_Click" ValidationGroup="a"></asp:Button>--%>
                                    <asp:LinkButton runat="server"  class="btn btn-success" ID="btnaddtocart" OnClick="btnaddtocart_Click" ValidationGroup="a">
                                    <i class="fa fa-shopping-cart" aria-hidden="true"></i>   Add To Cart
                                    </asp:LinkButton>
                                </div>

                               

                            </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="qty-div">
                    <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="h1" runat="server" Visible="false" />

                    <%-- <asp:TextBox runat="server" ID="txtqty" CssClass="form-control" ValidationGroup="valGroup"> </asp:TextBox>--%>
                    <%--<input id="qty"  class="form-control" runat="server" type="text" va="valGroup"/>--%>

                    <%--<div class="btn-group cart">
                        <asp:Button  ID="btnaddtocart"  Text="Add To Cart" class="btn btn-success" runat="server" OnClick="btnaddtocart_Click" />
                    </div>--%>
                    <%--  <asp:TextBox ID="txtqty" runat="server" CssClass="form-control"></asp:TextBox><label>Quantity</label>--%>
                </div>
            </div>


        </div>
    </div>





</asp:Content>

