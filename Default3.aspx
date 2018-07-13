<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
       
        <html>
        <head><title>Merchant Check Out Page</title></head>
        <body>
            <center>
                <h1>Please do not refresh this page...</h1>
            </center>
            <form method='post' action='https://pguat.paytm.com/oltp-web/processTransaction?orderid=12345gdfsddsdffgddddfgfddsadsadgdfg' name='f1'>
                <table border='1'>
                    <tbody>
                        <input type='hidden' name='MID' value='xyzSta29798030653250'/>
                        <input type='hidden' name='CHANNEL_ID' value='WEB'/>
                        <input type='hidden' name='INDUSTRY_TYPE_ID' value='Retail'/>
                        <input type='hidden' name='WEBSITE' value='WEB_STAGING'/>
                        <input type='hidden' name='EMAIL' value='bpithiya211@gmail.com'/>
                        <input type='hidden' name='MOBILE_NO' value='8000050934'/>
                        <input type='hidden' name='CUST_ID' value='1'/>
                        <input type='hidden' name='ORDER_ID' value='12345gdfsddsdffgddddfgfddsadsadgdfg'/>
                        <input type='hidden' name='TXN_AMOUNT' value='1'/>
                        <input type='hidden' name='CALLBACK_URL' value='https://localhost:60895/Home/Paytest'/>
                        <input type='hidden' name='CHECKSUMHASH' value='mn4cJZrF+1npJz0Qea9ZQW3ut88j3j4yni7oqg/2vX8UV6y1YDqBpP1HcaV8kJ+aVG++ZfZDacZP6gtTDsbB3SnVdy3nvcWrLF+uN0kai+0='/>

                    </tbody>
                </table>
                <script type='text/javascript'>document.f1.submit();</script>
            </form>
        </body>
        </html>
   

</asp:Content>

