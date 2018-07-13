<%@ Page Title="Inquiry" Language="C#" MasterPageFile="./Main_Master.master" AutoEventWireup="true" CodeFile="Inquiry.aspx.cs" Inherits="Inquiry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="toolkitmngr" runat="server"></cc1:ToolkitScriptManager>
    <asp:PlaceHolder runat="server">
        <script type="text/javascript">
            var widgetId1;
            var onloadCallback = function () {
                widgetId1 = grecaptcha.render('reCaptch',
                    {
                        sitekey: System.Configuration.ConfigurationManager.AppSettings["sitekey"]

                    });
            };
        </script>
        <script src='https://www.google.com/recaptcha/api.js' type="text/javascript"></script>
    </asp:PlaceHolder>
    <!-- banner -->

    <!-- contact -->
    <div class="contact">
        <div class="container">
            <div class="contact-info">
                <h3>Inquiry</h3>
            </div>


            <div class="row">
                <div class="col-sm-offset-2 col-sm-8 col-md-offset-3 col-md-6 col-lg-offset-3 col-lg-6 no-padding">

                    <div class="contact-form">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ForeColor="Red" ValidationGroup="a" Font-Size="Medium" />


                        <asp:TextBox ID="txtname" runat="server" Placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Enter Name" ControlToValidate="txtname" ForeColor="Red"
                            ValidationGroup="a">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtname" ForeColor="Red"
                            ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Only Characters" />




                        <asp:TextBox ID="emailname" runat="server" Placeholder="Email Address"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="Enter Email Address" ControlToValidate="emailname" ForeColor="Red"
                            ValidationGroup="a">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RequiredFieldValidatoras" ControlToValidate="emailname"
                            ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="a"
                            runat="server"></asp:RegularExpressionValidator>

                        <asp:TextBox ID="contact" runat="server" Placeholder="Contact Number"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="fil1" runat="server" FilterType="Numbers" TargetControlID="contact"></cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Enter Contact Number" ControlToValidate="contact" ForeColor="Red"
                            ValidationGroup="a">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="contact" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="msg" runat="server" TextMode="MultiLine" Placeholder="Message"></asp:TextBox>




                        <div class="g-recaptcha" data-sitekey='<%=System.Configuration.ConfigurationManager.AppSettings["sitekey"] %>'></div>
                        <asp:Label ID="captchaid" runat="server" Style="color: red"></asp:Label>



                        <asp:Button ID="submit" runat="server" CssClass="btn1" Text="Submit"
                            OnClick="submit_Click" ValidationGroup="a" />

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- //contact -->


    <script src="Scripts/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.unobtrusive-ajax.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.unobtrusive.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_submit").on("click", function () {
                var ReCaptch = grecaptcha.getResponse(widgetId1);
                if (ReCaptch != "") {

                    return true;
                }
                $('#<%=captchaid.ClientID %>').html('Please Enter Valid Captcha');
                return false;
            });
        });
    </script>
</asp:Content>

