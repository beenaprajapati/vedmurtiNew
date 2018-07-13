using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DAL;
public partial class OrderDetail : System.Web.UI.Page
{
    Config conf = new Config();
    DataHelper helper = new DataHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                if (Request.Form.Count > 0)
                {
                    string status = "";
                    string paymentdate = "";
                    string tranid = Request.Form["TXNID"].ToString();
                    string orderid = Request.Form["ORDERID"].ToString();
                    string Amount = Request.Form["TXNAMOUNT"].ToString();
                    string Status = Request.Form["STATUS"].ToString();
                    string Paymenttype = "Paytm";
                    if (Status == "TXN_SUCCESS")
                    {
                        status = "success";
                        if (Request.Form["TXNDATE"].ToString() != "")
                        {
                            paymentdate = Request.Form["TXNDATE"].ToString();
                        }

                        int transaction = helper.ExecuteNonQuery("insert into ordertransaction (TransactionID,InvoiceNum,Amount,Status,PaymentDate,PaymentType) values('" + tranid + "','" + orderid + "','" + Amount + "','" + Status + "','" + paymentdate + "','" + Paymenttype + "')");
                        if (transaction > 0)
                        {

                        }
                       
                    }
                    else if (Status == "TXN_FAILURE")
                    {
                        status = "Failure";
                        int transaction = helper.ExecuteNonQuery("insert into ordertransaction (TransactionID,InvoiceNum,Amount,Status,PaymentType) values('" + tranid + "','" + orderid + "','" + Amount + "','" + Status + "','" + Paymenttype + "')");
                        if (transaction > 0)
                        {

                        }
                        Response.Redirect("ErrorHandling.aspx");
                    }

                    else
                    {
                        status = "Pending";
                        int transaction = helper.ExecuteNonQuery("insert into ordertransaction (TransactionID,InvoiceNum,Amount,Status,PaymentType) values('" + tranid + "','" + orderid + "','" + Amount + "','" + Status + "','" + Paymenttype + "')");
                        if (transaction > 0)
                        {

                        }
                    }
                    lblorderno.Text = Request.QueryString["Id"].ToString();
                   
                }
            }
        }

    }

    protected void btncontinue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}