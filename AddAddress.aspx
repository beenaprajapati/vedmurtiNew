<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="AddAddress.aspx.cs" Inherits="AddAddress" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .login-bg {
            background: #f8f8f8 none repeat scroll 0 0;
            margin-bottom: 15px;
            padding: 15px;
        }

            .login-bg .form-group {
                margin-bottom: 8px;
                width: auto;
            }

        .messagealert {
            width: 100%;
            position: fixed;
            top: 0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('.buttons').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="toolkitmngr" runat="server"></cc1:ToolkitScriptManager>
    <div class="moments">
        <div class="container">
            <div class="row">

                <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6">
                    <h3><span id="ContentPlaceHolder1_pagename" runat="server">Add Address
                    </span></h3>
                    <div class="form-fields login-bg">
                        <div class="form-group">
                            <label for="FirstName">First Name: <span class="required">*</span></label>
                            <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ErrorMessage="Enter First Name" ValidationGroup="a" ControlToValidate="txtfirstname" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="LastName">Last Name: <span class="required">*</span></label>
                            <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="a" ErrorMessage="Enter Last Name" ControlToValidate="txtlastname" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="Email">Email: <span class="required">*</span></label>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="a" ErrorMessage="Enter Email Address" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        
                        <div class="form-group">
                            <label>State: <span class="required">*</span></label>
                            <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlstate" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>City: <span class="required">*</span></label>
                            <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Address 1:<span class="required"></span></label>
                            <asp:TextBox ID="txtaddress1" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Address 2:<span class="required"></span></label>
                            <asp:TextBox ID="txtaddress2" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="phone">Phone: <span class="required">*</span></label>
                            <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="a" ErrorMessage="Enter Phone No." ControlToValidate="txtphone" ForeColor="Red"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="f1" runat="server" TargetControlID="txtphone" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphone" runat="server" ErrorMessage="Phone No must be of 10 digits" ValidationExpression="\d{10}" ForeColor="Red"></asp:RegularExpressionValidator>

                        </div>
                        <div class="form-group">
                            <label>ZipCode: <span class="required">*</span></label>
                            <asp:TextBox ID="txtzipcode" runat="server" CssClass="form-control" MaxLength="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="a" ErrorMessage="Enter Zip Code" ControlToValidate="txtzipcode" ForeColor="Red"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtzipcode" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtzipcode" runat="server" ErrorMessage="Zip code must be of six digit" ValidationExpression="\d{6}" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="buttons">
                        <asp:Button ID="btnsave" runat="server" class="btn-details" OnClick="btnsave_Click" Text="Save" ValidationGroup="a" />
                        <asp:Button ID="btncancel" runat="server" class="btn-details" OnClick="btncancel_Click" Text="Cancel" Style="margin-left: 10px;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function TriggerButtonClick() {

            $("#hdnCountryID").val($("#ddlcountry").val());
            $("#btnShow").click();
        }
    </script>
</asp:Content>

