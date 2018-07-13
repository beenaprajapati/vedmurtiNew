<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .panel-heading {
            background-color: #f5f5f5;
            border: 1px solid #fff;
        }

        /*.panel-body {
            
            border-radius: 5px;
        }*/
        /*.active {
            background-color: #12a6f0;
        }*/

        .login-bg {
            background: #f8f8f8 none repeat scroll 0 0;
            float: left;
            margin-bottom: 15px;
            padding: 15px;
            width: 100%;
        }

            .login-bg .form-group {
                float: left;
                margin-bottom: 8px;
                width: 100%;
            }

        .title {
            color: #444;
            font-size: 16px;
            margin: 0 0 15px;
        }

        .required {
            color: red;
            font-size: 16px;
        }

        .gender {
            float: left;
            width: 100%;
        }

            .gender input[type="radio"], .gender input[type="checkbox"] {
                float: left;
                line-height: normal;
                margin: 4px 0 0;
            }

            .gender .radio, .gender .checkbox {
                display: block;
                float: left;
                margin: 0 5px;
                position: relative;
            }

        .payment {
            margin: 0 11px 20px;
            font-size: 0;
        }

            .payment li {
                display: inline-block;
                width: 100px;
                height: 30px;
                background: url(../images/PayUMoney.png) no-repeat;
                background-size: contain;
            }

            .payment .chk1 {
                background-position: 0 0;
                margin-right: 17px;
            }

            .payment .chk2 {
                background-position: -50px 0;
                margin-right: 14px;
            }

            .payment .chk3 {
                background-position: -100px 0;
                margin-right: 19px;
            }

            .payment .chk4 {
                background-position: -147px 0;
            }

            .payment input[type="radio"] {
                line-height: normal;
                margin: 4px -18px 0px;
            }

        .btn {
            background: #12a6f0 none repeat scroll 0 0;
            color: #fff;
            text-transform: uppercase;
            font-size: 12px;
        }

            .btn:hover {
                color: #fff !important;
                background: #1b2266 none repeat scroll 0 0 !important;
            }

        .accordianspan {
            border-right: 1px solid #fff;
            padding: 14px 12px 14px 11px;
            font-size: 16px;
            color: #444;
        }

        .accordiantitle {
            padding: 10px;
            color: #444;
            font-size: 16px;
            margin: 0 0 15px;
        }

        .pnlpay {
            margin: 12px 0 0 39px;
        }

        .OrderAddress {
            background-color: #f9f9f9;
            width: 50%;
        }

        .first-shopping-div tr:nth-last-child(1) {
            border: 1px solid #ddd;
        }
        .subtotal-div
        {
            background-color:#f9f9f9 !important;
            margin-top:10px;
        }
    </style>
    <%--<script>
        $(function () {
            var activeIndex = parseInt($('#<%=hidAccordionIndex.ClientID %>').val());

            $("#accordion").accordion({
                autoHeight: false,
                event: "mousedown",
                active: activeIndex,
                change: function (event, ui) {
                    var index = $(this).children('h3').index(ui.newHeader);
                    $('#<%=hidAccordionIndex.ClientID %>').val(index);
                }
            });
        });
    </script>--%>
    <%-- <script type="text/javascript">
        function TriggerButtonClick() {
            
            $("#hdnCountryID").val($("#ddlcountry").val());
            $("#btnShow").click();
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="sc" runat="server"></cc1:ToolkitScriptManager>
    <div class="moments">
        <div class="container">
            <cc1:Accordion ID="AccordionCtrl" runat="server" HeaderCssClass="panel-heading" CssClass="accordian" HeaderSelectedCssClass="panel-heading" ContentCssClass="panel-body" RequireOpenedPane="true" SelectedIndex="0" Width="100%">
                <Panes>
                    <cc1:AccordionPane ID="Accorrdion0" runat="server" ContentCssClass="panel-body">
                        <Header>
                            <span class="accordianspan">1</span>
                            <span class="accordiantitle">Customer Details</span>
                        </Header>
                        <Content>
                            <asp:Panel ID="pnlnew" runat="server">

                                <div class="form-fields login-bg">
                                    <asp:DropDownList ID="ddladdress" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddladdress_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="buttons" style="text-align: center;">
                                    <asp:Button ID="Button1" runat="server" class="btn" OnClick="Button1_Click" Text="Continue" ValidationGroup="a" />
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="panel1" runat="server" CssClass="col-sm-6 col-sm-offset-3">
                                <div class="form-fields login-bg">
                                    <input type="hidden" runat="server" id="key" name="key" />
                                    <input type="hidden" runat="server" id="hash" name="hash" />
                                    <input type="hidden" runat="server" id="txnid" name="txnid" />
                                    <div class="form-group">
                                        <label for="FirstName">First Name: <span class="required">*</span></label>
                                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtfirstname" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group">
                                        <label for="LastName">Last Name: <span class="required">*</span></label>
                                        <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="txtlastname" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="form-group">
                                        <label for="Phone">Phone No: <span class="required">*</span></label>
                                        <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Phone No." ControlToValidate="txtphone" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="f1" runat="server" TargetControlID="txtphone" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphone" runat="server" ErrorMessage="Phone No must be of 10 digits" ValidationExpression="\d{10}" ForeColor="Red"></asp:RegularExpressionValidator>

                                    </div>
                                    <div class="form-group">
                                        <label for="Email">Email: <span class="required">*</span></label>
                                        <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email Address" ValidationGroup="a" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                   
                                            
                                            <div class="form-group">
                                                <label>State: <span class="required">*</span></label>
                                                <asp:DropDownList ID="dddlstate" runat="server" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dddlstate" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </div>
                                        
                                    <div class="form-group">
                                        <label>City:<span class="required">*</span></label>
                                        <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="City is required" ValidationGroup="a" ControlToValidate="txtcity" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Address 1:<span class="required">*</span></label>
                                        <asp:TextBox ID="txtaddress1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address 1 is required" ValidationGroup="a" ControlToValidate="txtaddress1" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label>Address 2:<span class="required"></span></label>
                                        <asp:TextBox ID="txtaddress2" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>Zip Code: <span class="required">*</span></label>
                                        <asp:TextBox ID="txtzipcode" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Zip Code is required" ValidationGroup="a" ControlToValidate="txtzipcode" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="fil2" runat="server" TargetControlID="txtzipcode" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtzipcode" runat="server" ErrorMessage="Zip Code must be of six digits" ValidationExpression="\d{6}" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="buttons">
                                    <asp:Button ID="btncontinue" runat="server" class="btn-details" OnClick="btncontinue_Click" Text="Continue" ValidationGroup="a" />
                                </div>
                            </asp:Panel>
                        </Content>
                    </cc1:AccordionPane>
                    <cc1:AccordionPane ID="acc2" runat="server">
                        <Header>
                            <span class="accordianspan">2</span>
                            <span class="accordiantitle">Payment Details</span>
                        </Header>
                        <Content>
                            <asp:Panel ID="pnlpay" runat="server" CssClass="pnlpay">
                                <div id="bindhiddenfieldsforsubmitpayment" runat="server">
                                </div>
                                <div class="form-group">
                                    <asp:RadioButton ID="rdpay" runat="server" GroupName="pay" Text="Payyoumoney" />
                                </div>
                                <div class="form-group">
                                    <asp:RadioButton ID="rdpaypal" runat="server" GroupName="pay"  Text="Paytm"  />
                                </div>
                                <div style="text-align: center;" class="buttons">
                                    <asp:Button ID="btnpayment" Text="Continue" Width="100px" CssClass="btn" runat="server" OnClick="btnpayment_Click" />
                                </div>
                            </asp:Panel>
                        </Content>
                    </cc1:AccordionPane>
                    <cc1:AccordionPane ID="acc3" runat="server" ContentCssClass="panel-body">
                        <Header>
                            <span class="accordianspan">3</span>
                            <span class="accordiantitle">Order Summary</span>
                        </Header>
                        <Content>
                            <asp:Panel ID="panel2" runat="server" Visible="false">
                                <div class="form-fields OrderAddress">
                                    <div class="title"><strong>Address</strong></div>
                                    <div class="info">
                                        <ul>
                                            <li>
                                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                            </li>

                                            <li>Email:<asp:Label ID="lblemail" runat="server"></asp:Label>

                                            </li>

                                            <li>Phone:
                                                    <asp:Label ID="lblphone" runat="server"></asp:Label>

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
                                <div class="cart-div">
                                    <br />
                                    <asp:GridView ID="grdviewcart" EmptyDataText="Cart is Empty" runat="server" AutoGenerateColumns="false" CssClass="shopping-cart-row first-shopping-div" Style="text-align: center; width: 100%;">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="col-md-2 col-lg-2">
                                                <ItemTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 hidden-xs">
                                                        <%#Eval("Product_Name") %>
                                                        <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("product_id") %>' />

                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price" HeaderStyle-CssClass="col-md-2 col-lg-2">
                                                <ItemTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-3">
                                                        <asp:Label ID="lblprice" runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="col-md-2 col-lg-2">
                                                <ItemTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-3">
                                                        <asp:Label ID="lblqty" runat="server" Text='<%#Eval("MaxQuantity") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubTotal" HeaderStyle-CssClass="col-md-2 col-lg-2" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-3">
                                                        <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            Shopping Cart Empty
                                        </EmptyDataTemplate>
                                        <HeaderStyle CssClass="shopping-cart-fixed-header hidden-xs hidden-sm" />
                                    </asp:GridView>
                                </div>
                                <div class="subtotal-div">
                                    
                                    <p>
                                        Sub-Total: &#8377;
                                        <asp:Label ID="lblsubtotal" runat="server"></asp:Label>
                                    </p>
                                    <p>
                                        Total: &#8377;
                                        <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <div class="login-bg">

                                    <h4 class="h4">Order Note:</h4>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtnote" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="buttons">
                                        <asp:Button ID="btnconfirm" runat="server" class="btn-details" OnClick="btnconfirm_Click" Text="Place Order" />
                                    </div>
                                </div>
                            </asp:Panel>
                        </Content>
                    </cc1:AccordionPane>
                </Panes>
            </cc1:Accordion>
            <div class="accordion" style="display: none;">
                <div class="panel-group" id="accordion1" runat="server">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href="#menuOne">
                                    <span class="glyphicon glyphicon-minus"></span>
                                    Your Personal Details
                                </a>
                            </h4>
                        </div>
                        <div id="menuOne" class="panel-collapse collapse in">
                            <div class="panel-body" id="address">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-group" id="accordion2">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#menuTwo">
                                    <span class="glyphicon glyphicon-minus"></span>
                                    Payment Method 
                                </a>
                            </h4>
                        </div>
                        <div id="menuTwo" class="panel-collapse collapse in">
                            <div class="panel-body" id="payment">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-group" id="accordion3" style="visibility: hidden;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" href="#menuthree">
                                    <span class="glyphicon glyphicon-minus"></span>
                                    Confirm Order
                                </a>
                            </h4>
                        </div>
                        <div id="menuthree" class="panel-collapse collapse in">
                            <div id="ordersummary" class="panel-body ">
                            </div>
                        </div>

                    </div>
                    <%-- <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6">
                        <h3><span id="ContentPlaceHolder1_pagename"></span></h3>


                        <div class="title">
                            <strong></strong>
                        </div>
                        
                        </>
                    </div>--%>
                </div>

            </div>


        </div>

    </div>



</asp:Content>

