<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .grid_4 th {
            text-align: center;
        }

        .imagebtn {
            width: 60px;
        }
        .itemstyle{
            	border: 1px solid #ddd;



        }
        .qtydiv .form-control {
            background: #fff none repeat scroll 0 0;
            border-radius: 0;
            box-shadow: none;
            color: #888886;
            font-size: 14px;
            height: 46px;
            margin: 0 6px 0 0;
            padding: 5px 4px 5px 7px;
            text-align: center;
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="moments">
        <div class="container">
            <div class="cart-div">
                <asp:GridView ID="grdviewcart" runat="server" AutoGenerateColumns="false" EmptyDataText="No Record Found" Width="100%" DataKeyNames="ProductID" AllowPaging="true" PageSize="20" CssClass="grid_4" OnPageIndexChanging="grdviewcart_PageIndexChanging">
                    <Columns>
                        <%-- <asp:TemplateField HeaderText="Remove">
                            <ItemTemplate>
                                <label class="visible-sm hidden-lg hidden-xs hidden-md">Remove</label>
                                <asp:CheckBox ID="chkremove" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Product" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>
                                    <img src='<%#"Product/"+Eval("Product_Image") %>' height="60px" width="60px" /></center>
                                <asp:HiddenField ID="hdncatid" runat="server" Value='<%#Eval("product_category") %>'></asp:HiddenField>
                                </a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <a href='<%#"Productdetails.aspx?Id="+Eval("Product_ID") %>'>
                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("Product_name") %>'></asp:Label>
                                </a>
                                <br />
                                <asp:Label ID="lblmessage" runat="server" Visible="false" ForeColor="Red"> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="10%" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <div class="qtydiv">
                                     <asp:HiddenField ID="hdnqty" runat="server" Value='<%#Eval("qty") %>' Visible="false" />
                                     <asp:HiddenField ID="hdnmaxqty" runat="server" Value='<%#Eval("MaxQuantity") %>' Visible="false" />
                                    <asp:HiddenField runat="server"  ID="txtqty"  Value='<%#Eval("StockQuantity") %>'> </asp:HiddenField>
                                     <asp:DropDownList ID="ddllise" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddllise_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <%-- <EditItemTemplate>
                                <asp:TextBox ID="lblqty1" runat="server" Text='<%#Eval("MaxQuantity") %>' CssClass="form-control" Width="50px"></asp:TextBox>
                            </EditItemTemplate>--%>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                <asp:HiddenField ID="hdnstock" runat="server" Value='<%#Eval("AvailableStock") %>'></asp:HiddenField>
                                <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("ProductID") %>'></asp:HiddenField>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <%--  <asp:CommandField ButtonType="Image" ItemStyle-HorizontalAlign="Center"    UpdateImageUrl="~/sw-login/images/Updat-btn.jpg" EditImageUrl="sw-login/images/pencil.gif" ShowEditButton="true"  ShowCancelButton="true" SelectImageUrl="sw-login/images/pencil.gif" UpdateText="Update Cart" HeaderText="Edit" CancelImageUrl="~/sw-login/images/Cancel-btn.jpg"/>--%>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-CssClass="itemstyle">
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="lnkedit" runat="server" OnClick="lnkedit_Click"><img src="sw-login/images/pencil.gif" alt="" style="border:0;" /></asp:LinkButton>|--%>
                                <asp:LinkButton ID="btndelete" runat="server" OnClick="btndelete_Click" OnClientClick="return confirm('Do you wish to delete record ?');"><img src="sw-login/images/delete.png" alt="" style="border:0;" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    
                </asp:GridView>
            </div>
            <div class="row-btn">
                <asp:Button ID="btncontinue" OnClick="btncontinue_Click" runat="server" Text="Continue Shopping" CssClass="btn-details" Style="margin-left: 10px; float: right;" />
                <asp:Button ID="btnUpdatecart" OnClick="btnUpdatecart_Click" runat="server" Text="Update Cart" CssClass="btn-details" Style="float: right;" Visible="false"/>
                &nbsp;&nbsp;
                
            </div>

            <div class="totals" runat="server" id="totals">
                <div class="total-info">
                    <table class="cart-total">
                        <tbody>
                            <tr class="order-subtotal">
                                <td class="cart-total-left">
                                    <label>Sub-Total:</label>
                                </td>
                                <td class="cart-total-right">
                                    <span class="value-summary">&#8377; <asp:Label ID="lblsubtotal" runat="server"></asp:Label></span>
                                </td>
                            </tr>
                            <tr class="shipping-cost">
                                <td class="cart-total-left">
                                    <label>Shipping:</label>
                                </td>
                                <td class="cart-total-right">
                                    <span class="value-summary">&#8377; 0.00</span>
                                </td>
                            </tr>
                            
                            <tr class="order-total">
                                <td class="cart-total-left">
                                    <label>Total:</label>
                                </td>
                                <td class="cart-total-right">
                                    <span class="value-summary"><strong>&#8377; <asp:Label ID="lbltotal" runat="server"></asp:Label></strong></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="checkout-buttons">

                    <asp:Button ID="btncheckout" OnClick="btncheckout_Click" runat="server" Text="CheckOut" CssClass="btn-details" />
                </div>
                <div class="addon-buttons">
                </div>
            </div>
            <%-- <div class="subtotal-div" id="subtotal" runat="server">
              
                <p class="subtotal"><b>Sub-Total: </b>$</p>
                <p class="total""><b>Total: </b>$></p>
            </div>
            <br />
            <div class="row-btn">
               
            </div>
        </div>--%>
        </div>
</asp:Content>

