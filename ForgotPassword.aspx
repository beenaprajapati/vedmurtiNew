<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
        .login-bg {
            background: #f8f8f8 none repeat scroll 0 0;
            margin-bottom: 15px;
            padding: 15px;
        }

            .login-bg .form-group {
                margin-bottom: 8px;
                width: auto;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="moments">
        <div class="container">
            <div class="row">
                <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6">
                    <h3><span id="ContentPlaceHolder1_pagename">Password Recovery</span></h3>
                    <div class="form-fields login-bg">
                        <div class="form-group">
                            <label for="Email">Email Address:</label>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="email form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email Address" ValidationGroup="a" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator style="float:left;" ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                            <br />
                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                      
                    </div>
                    <div class="buttons" style="margin-left: 40px">
                        <asp:Button class="btn-details" ID="btnfogot"
                            runat="server" Text="Forgot Password" OnClick="btnfogot_Click" ValidationGroup="a" />

                    </div>


                </div>

            </div>



        </div>
    </div>
</asp:Content>

