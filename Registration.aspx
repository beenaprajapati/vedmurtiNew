<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            var checkBoxList = document.getElementById("<%=chkgender.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <style>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="toolkitmngr" runat="server"></cc1:ToolkitScriptManager>
    <div class="moments">
        <div class="container">

            <div class="row">

                <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6">
                    <h3><span id="ContentPlaceHolder1_pagename" runat="server">Registration</span></h3>
                    <div class="title">
                        <strong>Your Personal Details</strong>
                    </div>
                    <div class="form-fields login-bg">
                        <div class="form-group">
                            <label for="FirstName">First Name: <span class="required">*</span></label>
                            <asp:TextBox ID="txtfirstname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqfirstname" runat="server" ErrorMessage="Enter First Name" ControlToValidate="txtfirstname" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label>Middle Name: <span class="required">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="txtmiddlename" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                ErrorMessage="Enter Middle Name" ControlToValidate="txtmiddlename"
                                ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label for="LastName">Last Name: <span class="required">*</span></label>
                            <asp:TextBox ID="txtlastname" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Last Name" ControlToValidate="txtlastname" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label for="Email">Phone No: <span class="required">*</span></label>
                            <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Phone No." ControlToValidate="txtphone" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="fil1" runat="server" TargetControlID="txtphone" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtphone" runat="server" ErrorMessage="Phone No must be of 10 digits" ValidationExpression="\d{10}" ForeColor="Red"></asp:RegularExpressionValidator>

                        </div>
                        <div class="form-group">
                            <label for="Email">Email: <span class="required">*</span></label>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Email Address" ControlToValidate="txtemail" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <div class="gender">
                                <label for="ConfirmPassword">Gender: <span class="required">*</span></label>
                                <asp:RadioButtonList ID="chkgender" runat="server">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                    ControlToValidate="chkgender" ErrorMessage="Select any one Gender" ValidationGroup="a" ForeColor="Red">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label>State: <span class="required">*</span></label>
                            <asp:DropDownList ID="ddlstate" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlstate" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>

                        </div>
                        <div class="form-group">
                            <label>District: <span class="required">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="txtdistrict" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                ErrorMessage="Enter District" ControlToValidate="txtdistrict"
                                ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Taluka: <span class="required">*</span></label>

                            <asp:TextBox CssClass="form-control" ID="txttaluka" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                ErrorMessage="Enter Taluka" ControlToValidate="txttaluka"
                                ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>Village: <span class="required">*</span></label>

                            <asp:TextBox CssClass="form-control" ID="txtvillage" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ErrorMessage="Enter Village" ControlToValidate="txtvillage"
                                ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label>PinCode: <span class="required">*</span></label>

                            <asp:TextBox CssClass="form-control" ID="txtpincode" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                ErrorMessage="Enter PinCode" ControlToValidate="txtpincode"
                                ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="rexNumber" ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6}$" ErrorMessage="Please enter a 6 digit number!" ForeColor="Red" />
                        </div>
                        <div class="form-group">
                            <label for="ConfirmPassword">AdharCard: <span class="required">*</span></label>
                            <asp:FileUpload ID="adharfile" runat="server" ValidationGroup="a" CssClass="form-control" onchange="UploadFile(this);" />
                            <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator5" runat="server" Style="float: left;"
                                ErrorMessage="Please upload AadharCard" ValidationGroup="a"
                                ControlToValidate="adharfile" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2" runat="server"
                                ErrorMessage="Only jpeg/jpg files are allowed!" Style="float: left;"
                                ValidationExpression="^.+\.(?:(?:[jJ][pP][eE][gG])|(?:[jJ][pP][gG]))$"
                                ControlToValidate="adharfile" ValidationGroup="a" ForeColor="Red"></asp:RegularExpressionValidator>



                        </div>
                        <div class="form-group">
                            <label for="ConfirmPassword">PanCard: <span class="required">*</span></label>
                            <div class="file">
                                <asp:FileUpload ID="panfilename" runat="server" CssClass="form-control" onchange="UploadPan(this);" />
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator7" runat="server" Style="float: left;"
                                    ErrorMessage="Please upload PanCard" ValidationGroup="a"
                                    ControlToValidate="panfilename" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator3" runat="server"
                                    ErrorMessage="Only jpeg/jpg files are allowed!"
                                    ValidationExpression="^.+\.(?:(?:[jJ][pP][eE][gG])|(?:[jJ][pP][gG]))$"
                                    ControlToValidate="panfilename" ValidationGroup="a" ForeColor="Red"></asp:RegularExpressionValidator>


                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ConfirmPassword">Reference By: <span class="required">*</span></label>
                            <div class="file">
                                <asp:TextBox CssClass="form-control" ID="txtreference" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                    ErrorMessage="Enter Reference Name" ControlToValidate="txtreference"
                                    ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>


                            </div>
                        </div>
                       
                    </div>
                    <div class="buttons">
                        <asp:Button ID="btnregister" runat="server" class="btn-details" OnClick="btnregister_Click" Text="Register" ValidationGroup="a" />
                    </div>

                </div>

            </div>



        </div>
    </div>
    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                var ext = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
                if (fileUpload.value && (ext == "jpeg" || ext == "jpg")) {
                    var files = document.getElementById('<%=adharfile.ClientID %>').files;
                    var fileData = new FormData();

                    for (var i = 0; i < files.length; i++) {
                        fileData.append("fileInput", files[i]);
                    }

                    $.ajax({
                        type: "POST",
                        url: "FileUploadHandler.ashx",
                        dataType: "json",
                        contentType: false, // Not to set any content header
                        processData: false, // Not to process data
                        data: fileData,
                        success: function (result, status, xhr) {

                        },
                        error: function (xhr, status, error) {
                            // alert(status);
                        }
                    });


                }
                else {

                }

            }
        }
        function UploadPan(fileUpload) {
            if (fileUpload.value != '') {
                var ext = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
                if (fileUpload.value && (ext == "jpeg" || ext == "jpg")) {
                    var files = document.getElementById('<%=panfilename.ClientID %>').files;
                    var fileData = new FormData();

                    for (var i = 0; i < files.length; i++) {
                        fileData.append("fileInput", files[i]);
                    }

                    $.ajax({
                        type: "POST",
                        url: "FileUploadHandler.ashx",
                        dataType: "json",
                        contentType: false, // Not to set any content header
                        processData: false, // Not to process data
                        data: fileData,
                        success: function (result, status, xhr) {

                            if (typeof (dataresulterror) != 'undefined') {

                                if (result.error != '') {
                                    //alert(data.error);
                                } else {
                                    //$('#fileUploadBox').val(result.msg);
                                    //$("#hdnFilePath").val(result.path + "?" + result.msg);
                                }
                            }
                        },
                        error: function (xhr, status, error) {
                            //alert(status);
                        }
                    });

                }
                else {

                }

            }
        }
    </script>
</asp:Content>

