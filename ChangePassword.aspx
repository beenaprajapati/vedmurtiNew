<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

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
                        <h3><span id="ContentPlaceHolder1_pagename">Change Password</span></h3>
                            <div class="form-fields login-bg">
                                <div class="form-group">
                                    <label for="Email">Email:</label>
                                                                        <asp:TextBox ID="txtemail" runat="server" CssClass="email form-control" Enabled="false"></asp:TextBox>
                                  
                                 <%--   <input class="email form-control" id="Email"  type="text" runat="server" />--%>
                                </div>
                                <div class="form-group">
                                    <label for="Password">New Password:</label>
                                  
                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="password form-control"></asp:TextBox>   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Password is required"  ValidationGroup="a" ControlToValidate="txtpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                     <%--<asp:RegularExpressionValidator ID="RegExp1" runat="server"
                                    ErrorMessage="Password length must be 6  characters"
                                    ControlToValidate="txtpassword"
                                    ValidationExpression="^[a-zA-Z0-9'@&#.\s]{6}$" />
                                    --%>
                                </div>
                                <div class="form-group">
                                    <label for="Password">Confirmed Password:</label>
                                
                                       <asp:TextBox ID="txtconfpassword" runat="server" TextMode="Password" CssClass="password form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Confirmed Password is required"  ValidationGroup="a" ControlToValidate="txtconfpassword" ForeColor="Red"></asp:RequiredFieldValidator>
                                     <asp:CompareValidator ID="cmppassword" runat="server" ControlToValidate="txtconfpassword" ControlToCompare="txtpassword" ErrorMessage="Password not match" ForeColor="Red"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="buttons" style="margin-left: 40px">
                                <asp:Button class="btn-details" ID="btn_Submit"
                                    runat="server" Text="Submit" OnClick="btn_Submit_Click" ValidationGroup="a"/>
                                
                            </div>
                          
                      
                    </div>

                </div>



            </div>
        </div>
</asp:Content>

