<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="User_Login.aspx.cs" Inherits="User_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="moments">
        <div class="container">
            <div class="row">
                <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6">
                    <h3><span id="ContentPlaceHolder1_pagename">Welcome, Please Sign In!</span></h3>
                    <div class="form-fields login-bg">
                        <div class="form-group">
                            <label for="Email">VACode:</label>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="email form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email Address" ValidationGroup="a" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                           <%-- <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" style="float:left;" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                            <%--   <input class="email form-control" id="Email"  type="text" runat="server" />--%>
                        </div>
                        <div class="form-group">
                            <label for="Password">Password:</label>
                          <asp:TextBox ID="txtpassword" runat="server" CssClass="password form-control" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Password" ValidationGroup="a" ControlToValidate="txtpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                            
                        </div>
                        <div class="form-group">
                           <%-- <input id="RememberMe" name="RememberMe" value="true" type="checkbox" />
                            <input name="RememberMe" value="false" type="hidden" />
                            <label for="RememberMe">Remember me?</label>--%>
                           <%-- <span class="forgot-password">
                                <a href="passwordrecovery">Forgot password?</a>
                            </span>--%>
                            
                            <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:LinkButton ID="btnforgot" runat="server" Text="Forgot Password ?" OnClick="btnforgot_Click" style="margin-left:200px;"></asp:LinkButton>
                        </div>
                    </div>
                    <div class="buttons" style="margin-left: 40px">
                        <asp:Button class="btn-details" ID="btn_Submit"
                            runat="server" Text="Log In" OnClick="btn_Submit_Click" ValidationGroup="a" />
                         <asp:Button CssClass="btn-details" ID="Button1"
                            runat="server" Text="Register"  style="margin-left: 20px;display:none;" />
                        <%--<asp:Button CssClass="btn-details" ID="btnRegister"
                            runat="server" Text="Register" OnClick="btnRegister_Click" style="margin-left: 20px;" />--%>
                       <%-- <input class="btn-details" style="margin-left: 20px;" value="Register" type="button"  />--%>
                    </div>


                </div>

            </div>



        </div>
    </div>
</asp:Content>

