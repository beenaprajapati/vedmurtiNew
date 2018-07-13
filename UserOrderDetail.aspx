<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="UserOrderDetail.aspx.cs" Inherits="UserOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .button-read {
            padding: 7px 8px;
            background-color: #12A6F0;
            width: 147px;
            color: #fff;
            margin: 0px auto;
        }

        .form-control[disabled] {
            background-color: #fff;
        }

        .itemstyle {
            border: 1px solid #ddd;
        }

        .list-group-item {
            font-size: 16px;
            font-weight: bold;
            border: none !important;
            margin-bottom: -10px !important;
        }
            .lblinfo {
                font-weight:normal;
            }
        .title{
            font-size:16px;
        }
        .info{
            font-size:15px;
        }

        .list-group {
            margin-bottom: 40px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="moments">
        <div class="container">
            <header class="panel-heading btn-primary">
                        Order Information
                    </header>
            <%--<p>
                <asp:Button ID="btnPdf" runat="server" Text="PDF Invoice" OnClick="btnPdf_Click" CssClass="btn button-read" />
            </p>--%>
            <asp:Panel ID="pnlorder" runat="server">
                <div class="panel-body">
                    <div class="maindiv">
                        <div class="row text-center Order">
                            <ul class="list-group">
                                <li class="list-group-item">Order #
                                    <asp:Label ID="lblorderno" runat="server"> </asp:Label>
                                </li>
                                <li class="list-group-item">Order Date:
                                    <asp:Label ID="lblorderDate" runat="server" CssClass="lblinfo">
                                    </asp:Label>
                                </li>
                                  <li class="list-group-item">VA Code:
                                    <asp:Label ID="lblvacode" runat="server" CssClass="lblinfo">
                                    </asp:Label>
                                </li>
                            </ul>
                            <%--<p>
                                <b>Order # </b>
                                
                            </p>
                            <p>
                                <b></b>
                                
                            </p>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="title"><strong>Customer Address</strong></div>
                            <div class="info">
                                <ul>
                                    <li>
                                        <asp:Label ID="lblCustomername" runat="server">
                                        </asp:Label></li>
                                    <li>
                                        <asp:Label ID="lblname" runat="server"></asp:Label>

                                    </li>

                                    <li>Email:<asp:Label ID="lblemail" runat="server"></asp:Label>

                                    </li>

                                    <li>Phone:<asp:Label ID="lblphone" runat="server"></asp:Label>

                                    </li>
                                    <li>
                                        <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblstate" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="title"><strong>VA Address</strong></div>
                            <div class="info">
                                <ul>
                                    <li>
                                        <asp:Label ID="lblvaname" runat="server">
                                        </asp:Label></li>
                                    
                                    <li>Email:<asp:Label ID="lblvaemail" runat="server"></asp:Label>
                                    </li>

                                    <li>Phone:<asp:Label ID="lblvaphone" runat="server"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblvaaddress" runat="server"></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblvastate" runat="server"></asp:Label>

                                    </li>



                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <h4 class="h4">Order Items</h4>
                <div class="order-div">
                    <asp:GridView ID="grduserorder" runat="server" AutoGenerateColumns="false" CssClass="gridorder" Width="100%" PageSize="10" AllowPaging="true" OnPageIndexChanging="grduserorder_PageIndexChanging" EmptyDataText="No Record Found">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="itemstyle">
                                <HeaderTemplate>
                                    Sr. No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--  <asp:TemplateField>
                            <HeaderTemplate>
                                Image
                            </HeaderTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:Image ID="imgCover" runat="server" AlternateText="Image Cover" Height="60" Width="60" ImageUrl='<%# Eval("Product_Image","~/Product/{0}") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            
                            <asp:TemplateField ItemStyle-CssClass="itemstyle">
                                <HeaderTemplate>
                                    Name
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="h1" runat="server" Value='<%#Eval("product_id") %>' Visible="false" />
                                    <%#Eval("Product_Name") %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="itemstyle">
                                <HeaderTemplate>
                                    Price
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblprice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="itemstyle">
                                <HeaderTemplate>
                                    Quantity
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("MaxQuantity") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />

                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-CssClass="itemstyle">
                                <HeaderTemplate>
                                    Total
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>
                <h4></h4>
                <div class="subtotal-div">
                    <p>
                        Sub-Total: &#8377;
                        <asp:Label ID="lblsubtotal" runat="server"></asp:Label>
                    </p>
                    <p>
                        Order Total: &#8377; <b></b>
                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                    </p>
                </div>
                <div id="divnote" runat="server" class="order-div">
                    <h4 class="h4">OrderNote:</h4>
                    <div>
                        <asp:TextBox ID="txtnote" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                </div>

            </asp:Panel>
        </div>
    </div>
</asp:Content>

