<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ResponseHandling.aspx.cs" Inherits="ResponseHandling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <input id="hduserid" type="hidden" runat="server" />
    <input id="hdplandetailid" type="hidden" runat="server" />
    <input id="hdnooforder" type="hidden" runat="server" />
    <div class="page-container ">
        <div class="page-content">
            <div class="container">
                <div class="col-md-12">
                    <div class="portlet light" style="border:1px solid #ccc;">
                        <div class="caption text-center">
                            <h4 class="text-danger">
                               <%-- <span class="bold">School of Diabetes Payment Completion Detail
                                </span>
                                <br />
                                <span class="bold">Response
                                </span>--%>
                            </h4>

                        </div>
                        <div class="portlet-body">
                            <form runat="server" name="frmResponse" id="frmResponse">
                                <div class="table-scrollable">
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background:#6C8BC7;color:#fff;">Transaction Details</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td class="font12">Order No</td>
                                                <td>
                                                    <label id="MerchantRefNo" name="MerchantRefNo" runat="server">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="font12">Amount</td>
                                                <td>
                                                    <label id="Amount" name="Amount" runat="server">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="font12">Transaction Id</td>
                                                <td>
                                                    <label id="tid" name="tid" runat="server">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="font12 width240">PaymentID</td>
                                                <td>
                                                    <label id="PaymentID" name="PaymentID" runat="server">
                                                    </label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: right;">
                                                    <a href="#" onclick="gotoback()" class="btn btn-sm green">Back
                                                    </a>

                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

