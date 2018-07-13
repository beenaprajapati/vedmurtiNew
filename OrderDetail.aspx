<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="moments">
        <div class="container">
            <script src="js/jquery.chocolat.js"></script>
            <div class="row">
                <div class="">
                    <center>
                        <p>
                            <b><strong>
                                <h3>Thank You
                                </h3>
                            </strong></b>
                        </p>
                        <p>
                            <b><strong>
                                <h4>Your Order has been Successfully Processed!
                                </h4>
                            </strong></b>
                        </p>
                        <p><b>ORDER NUMBER:<asp:Label ID="lblorderno" runat="server"></asp:Label></b></p>
                    </center>
                </div>
                <div class="buttons" style="padding:16px;">
                    <asp:Button id="btncontinue" runat="server" Text="Continue" OnClick="btncontinue_Click" class="btn-details" style="margin-left:46%;"/>
                </div>
               
            </div>
        </div>
    </div>
</asp:Content>

