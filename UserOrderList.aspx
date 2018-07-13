<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="UserOrderList.aspx.cs" Inherits="UserOrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .shopping-cart-row  th{
            text-align:center;
        }
         .form-control[disabled]
        {

            background-color:#fff;
        }
          .itemstyle{
            	border: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="moments">
        <div class="container">
            <div class="order-div">
            <asp:GridView ID="grdOrderlist" AllowPaging="true" EmptyDataText="No Record Found" PageSize="10" OnPageIndexChanging="grdOrderlist_PageIndexChanging"  runat="server"  AutoGenerateColumns="false" CssClass="shopping-cart-row first-shopping-div" Style="text-align: center;" PagerStyle-CssClass="itemstyle">
                <Columns>
                    <asp:TemplateField HeaderText="Sr.No." HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                                  <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OrderNo" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnID" runat="server" Value='<%#Eval("OrderID") %>' />
                            <%#Eval("OrderNo") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Payment Status" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                            <%#Eval("Status") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate><%# Eval("OrderDate", "{0:dd/MM/yyyy}") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Products" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                                <%#Eval("totalproducts") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Amount" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                                <%#Eval("OrderTotalAmount") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                                <asp:LinkButton ID="lnkview" runat="server" Text="View" OnClick="lnkview_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </div>
        </div>
    </div>
</asp:Content>

