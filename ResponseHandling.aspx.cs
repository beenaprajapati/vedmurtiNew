using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using Configurations;
using DataLayer;
using System.IO;

using System.Net.Mail;
using System.Globalization;
using System.Collections.Generic;

public partial class ResponseHandling : System.Web.UI.Page
{
    Config conf = new Config();
    DataHelper helper = new DataHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        Config con = new Config();
        try
        {
            string[] merc_hash_vars_seq;
            string[] merc_hash_vars_seq1;
            string merc_hash_string = string.Empty;
            string merc_hash_string1 = string.Empty;
            string merc_hash = string.Empty;
            string order_id = string.Empty;
            string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";
            string hash_seq1 = "mihpayid|mode|status|unmappedstatus|key|txnid|amount|cardCategory|discount|net_amount_debit|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10|payment_source|PG_TYPE|bank_ref_num|bankcode|error|error_Message|name_on_card|cardnum|issuing_bank|card_type";
            bool isTestAccount = Convert.ToBoolean(ConfigurationManager.AppSettings["isTestAccount"]);
            if (!string.IsNullOrEmpty(Request.QueryString["promo"]))
            {
                if (!string.IsNullOrEmpty(Session["userID"].ToString()))
                {

                    try
                    {
                        // MembershipplanOrdersFields objOrder = CommonFunctions.GetOrderData(Request.QueryString["id"]);
                        string promo = "Promo Code";
                        PaymentID.InnerHtml = "success";
                        tid.InnerHtml = promo;
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Something is wrong please try after some time.");
                    }

                }

            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AddressID"]))
                {

                    string addressid = Request.QueryString["AddressID"].ToString();

                    if (Request.Form["status"] == "success")
                    {
                        merc_hash_vars_seq = hash_seq.Split('|');
                        merc_hash_vars_seq1 = hash_seq1.Split('|');
                        Array.Reverse(merc_hash_vars_seq);
                        Array.Reverse(merc_hash_vars_seq1);
                        foreach (string merc_hash_var in merc_hash_vars_seq)
                        {
                            merc_hash_string += "|";
                            merc_hash_string = merc_hash_string + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");
                        }
                        foreach (string merc_hash_var in merc_hash_vars_seq1)
                        {
                            merc_hash_string1 += "|";
                            merc_hash_string1 = merc_hash_string1 + (Request.Form[merc_hash_var] != null ? Request.Form[merc_hash_var] : "");
                        }
                        string[] aParam = merc_hash_string1.Split('|');
                        aParam = merc_hash_string1.Split('|');
                        merc_hash = Generatehash512(merc_hash_string).ToLower();
                       
                        order_id = Request.Form["txnid"];
                        string PaymentDt = DateTime.Now.ToString();
                        string status = "";
                        if (aParam[31] == "success")
                        {
                             status = "success";
                            // objOrder.ActivePlan = 1;
                        }
                        else
                        {
                             status = "Failure";
                        }
                        
                        //string ResponseCode = aParam[34];
                        //MerchantRefNo.InnerHtml = aParam[34];
                        //int OrderNo = Convert.ToInt32(aParam[21]);
                        string cardnumber = (aParam[3].Length > 3) ? aParam[3].Substring(aParam[3].Length - 4, 4) : aParam[3];
                        string cardtype = aParam[1];
                        string cardname = aParam[4];
                        Amount.InnerHtml = aParam[24].ToString();
                        //decimal AmountPaid = Convert.ToDecimal(aParam[25]);
                        //string PaymentMode = aParam[33];
                        tid.InnerHtml = aParam[28];
                        string email = aParam[21];
                        string PaymentType = "PayUmoney";
                        string OrderNote = string.IsNullOrEmpty(Session["Note"].ToString()) ? " " : Session["Note"].ToString();
                        //string TransactionID = aParam[34];
                        PaymentID.InnerHtml = aParam[33];
                        if (order_id != null)
                        {

                            string ToEmail, Email;
                            Config config = new Config();
                            System.Data.DataSet dataset = new System.Data.DataSet();
                            dataset.Reset();
                            System.Data.DataSet dataset1 = new System.Data.DataSet();
                            dataset1.Reset();
                            MailMessage Msg = new MailMessage();
                            MailMessage adminMsg = new MailMessage();
                            string body = string.Empty;
                            dataset1 = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
                            {
                                if (dataset.Tables.Count > 0)
                                {
                                    if (dataset.Tables[0].Rows.Count > 0)
                                    {
                                        string orderid = dataset.Tables[0].Rows[0]["Orderid"].ToString();
                                    }
                                }
                                System.Data.DataSet dsorderno = new System.Data.DataSet();
                                dsorderno.Reset();
                                dsorderno = con.getorderorderno(Session["userID"].ToString());
                                string OrderNo = "";
                                if (dsorderno.Tables[0].Rows[0]["Orderid"].ToString() == "")
                                {
                                    OrderNo = "001";
                                }
                                else
                                {
                                    OrderNo = dsorderno.Tables[0].Rows[0]["Orderid"].ToString().PadLeft(3, '0');
                                }
                                int x = helper.ExecuteNonQuery("insert into [dbo].[order]  (OrderNo,CustomerID,AddressID,OrderDate,Order_Status,OrderTotalAmount) VALUES('"+OrderNo+"','" + Session["UserID"].ToString() + "','" + addressid + "','" + DateTime.Now + "','" + 0 + "','" + Amount.InnerHtml + "')");
                                if (x > 0)
                                {
                                 
                                    System.Data.DataSet ds = new System.Data.DataSet();
                                    ds.Reset();
                                    System.Data.DataSet ds1 = new System.Data.DataSet();
                                    ds1.Reset();
                                    ds1 = con.getordermaxid(Session["userID"].ToString());
                                    if (ds1.Tables.Count > 0)
                                    {
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            string orderid = ds1.Tables[0].Rows[0]["Orderid"].ToString();
                                            DataSet dtdate = new DataSet();
                                            dtdate = con.getOrderID(orderid);
                                            DateTime orderdate = Convert.ToDateTime(dtdate.Tables[0].Rows[0]["OrderDate"].ToString());
                                            string OrderDate = Convert.ToDateTime(orderdate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                                            ds = con.GetUserDetail(Session["userID"].ToString());
                                            string vacode = ds.Tables[0].Rows[0]["VACode"].ToString();
                                            System.Data.DataSet ds2 = new System.Data.DataSet();
                                            var templateString = "";
                                            List<ListItem> lst = new List<ListItem>();
                                            ds2.Reset();
                                            ds2 = con.getadmindetail();
                                            DataSet userdetail = new DataSet();
                                            userdetail = con.Getorder(orderid);
                                            if (ds2.Tables.Count > 0)
                                            {
                                                if (ds2.Tables[0].Rows.Count > 0)
                                                {
                                                    string adminmail = ds2.Tables[0].Rows[0]["admin_email"].ToString();
                                                    if (ds.Tables.Count > 0)
                                                    {
                                                        if (ds.Tables[0].Rows.Count > 0)
                                                        {
                                                            decimal total = 0;
                                                            System.Data.DataSet getdetail = new DataSet();
                                                            string userid = Session["userID"].ToString();
                                                            getdetail = config.get_Addtocart_detailwithuserid(userid);
                                                            if (getdetail.Tables.Count > 0)
                                                            {
                                                                if (getdetail.Tables[0].Rows.Count > 0)
                                                                {
                                                                    Repeater rptcart = (Repeater)Master.FindControl("rptcartlist");
                                                                    if (rptcart != null)
                                                                    {
                                                                        rptcart.DataSource = getdetail.Tables[0];
                                                                        rptcart.DataBind();
                                                                        foreach (RepeaterItem item in rptcart.Items)
                                                                        {
                                                                            HiddenField availstock = (HiddenField)item.FindControl("hdnstock");
                                                                            HiddenField productname = (HiddenField)item.FindControl("hdnproduct");
                                                                            HiddenField pid = (HiddenField)item.FindControl("lblproid");
                                                                            Label lblprice = (Label)item.FindControl("lblprice");
                                                                            Label lblTotal = (Label)rptcart.Controls[rptcart.Controls.Count - 1].FindControl("lblTotal");
                                                                            Label lblqty = (Label)item.FindControl("lblqty");
                                                                            decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToInt32(lblqty.Text);
                                                                            total += subtotal;
                                                                            lblTotal.Text = total.ToString("0.00");
                                                                            ViewState["PlaceAmount"] = lblTotal.Text;
                                                                            int y = helper.ExecuteNonQuery("update addtocart set OrderID='" + orderid + "' where CustomerID='" + Session["UserID"].ToString() + "' and productid='" + pid.Value + "' AND ADDTOCART.cart_status=0 and orderid=0");
                                                                            if (y > 0)
                                                                            {



                                                                            }
                                                                            int z = helper.ExecuteNonQuery("insert into orderdetail (OrderID,ProductID,Price,Quantity) values('" + orderid + "','" + pid.Value + "','" + lblprice.Text + "','" + lblqty.Text + "')");
                                                                            if (z > 0)
                                                                            {

                                                                            }
                                                                            if (availstock.Value != null)
                                                                            {
                                                                                decimal stock = Convert.ToDecimal(availstock.Value);
                                                                                int quantity = Convert.ToInt32(lblqty.Text);
                                                                                decimal availablestock = stock - quantity;
                                                                                int updatestock = helper.ExecuteNonQuery("update products set availablestock='" + availablestock + "'  where product_id='" + pid.Value + "' and product_status=1");
                                                                                if (updatestock > 0)
                                                                                {

                                                                                }
                                                                            }
                                                                            else
                                                                            {

                                                                            }

                                                                            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/OrderConfirmationTemplate.html")))
                                                                            {
                                                                                body = reader.ReadToEnd();
                                                                            }
                                                                            if (userdetail.Tables[0].Rows.Count > 0)
                                                                            {

                                                                                string Name = userdetail.Tables[0].Rows[0]["FirstName"].ToString() + " " + userdetail.Tables[0].Rows[0]["LastName"].ToString();
                                                                                body = body.Replace("[[vacode]]", vacode);
                                                                                body = body.Replace("[[Name]]", Name);
                                                                                body = body.Replace("[[OrderNo]]", OrderNo);
                                                                                body = body.Replace("[[OrderDate]]", OrderDate);
                                                                                if (userdetail.Tables[0].Rows[0]["Address1"].ToString() == "")
                                                                                {

                                                                                }
                                                                                else
                                                                                {
                                                                                    string Address = userdetail.Tables[0].Rows[0]["Address1"].ToString();
                                                                                    body = body.Replace("[[Address]]", Address);
                                                                                }
                                                                                body = body.Replace("[[Contact]]", userdetail.Tables[0].Rows[0]["PhoneNumber"].ToString());
                                                                            }


                                                                            body = body.Replace("[[total]]", lblTotal.Text);
                                                                            body = body.Replace("[[subtotal]]", lblTotal.Text);
                                                                            body = body.Replace("[[MailTemplateImageURL]]", ConfigurationManager.AppSettings["WebPath"]);
                                                                            //body = body.Replace("[[Items]]", productname.Value);
                                                                            StringBuilder sb = new StringBuilder();
                                                                            for (var i = 0; i < getdetail.Tables[0].Rows.Count; i++)
                                                                            {
                                                                                sb.Append("<tr style='height: 32px;'>");
                                                                                sb.Append("<td style='border-bottom: 1px dotted rgb(15, 15, 15); padding: 0pt 10px 0pt 0pt;'> " + getdetail.Tables[0].Rows[i]["product_name"].ToString() + "</td>");
                                                                                sb.Append("<td style='border-bottom: 1px dotted rgb(15, 15, 15); padding: 0pt 10px 0pt 0pt;'></td>");

                                                                                sb.Append("<td style='border-bottom: 1px dotted rgb(15, 15, 15); padding: 0pt 10px 0pt 0pt;'> " + getdetail.Tables[0].Rows[i]["MaxQuantity"].ToString() + "</td>");
                                                                                decimal amount = Convert.ToDecimal(getdetail.Tables[0].Rows[i]["Price"].ToString()) * Convert.ToDecimal(getdetail.Tables[0].Rows[i]["MaxQuantity"].ToString());
                                                                                string amt = amount.ToString("0.00");
                                                                                sb.Append("<td style='border-bottom: 1px dotted rgb(15, 15, 15); padding: 0pt 10px 0pt 0pt;'> " + getdetail.Tables[0].Rows[i]["Price"].ToString() + "</td>");

                                                                                sb.Append("<td style='text-align: right; text-transform: uppercase; border-bottom: 1px dotted rgb(15, 15, 15);'> " + amt + "</td>");
                                                                                sb.Append("</tr>");

                                                                            }
                                                                            body = body.Replace("##order.products##", sb.ToString());

                                                                        }
                                                                        Msg.From = new MailAddress(ConfigurationManager.AppSettings["ContactEmail"]);
                                                                        Msg.To.Add(email);
                                                                        Msg.Subject = ConfigurationManager.AppSettings["EmailSubject"];
                                                                        Msg.Body = body;
                                                                        Msg.IsBodyHtml = true;
                                                                        SmtpClient smtp = new SmtpClient();
                                                                        smtp.Send(Msg);
                                                                        adminMsg.From = new MailAddress(ConfigurationManager.AppSettings["ContactEmail"]);
                                                                        adminMsg.To.Add(adminmail);
                                                                        adminMsg.Subject = ConfigurationManager.AppSettings["EmailSubject"];
                                                                        adminMsg.Body = body;
                                                                        adminMsg.IsBodyHtml = true;
                                                                        SmtpClient adminsmtp = new SmtpClient();
                                                                        adminsmtp.Send(adminMsg);
                                                                        int oredernote = helper.ExecuteNonQuery("insert into ordernote(Note,OrderID,CreatedDate) values('" + OrderNote + "','" + orderid + "','" + DateTime.Now.ToString() + "')");
                                                                        if (oredernote > 0)
                                                                        {

                                                                        }
                                                                        int transaction = helper.ExecuteNonQuery("insert into ordertransaction (TransactionID,InvoiceNum,Amount,CardNumber,CardName,CardType,Status,PaymentDate,PaymentType) values('" + tid.InnerHtml + "','" + orderid + "','" + Amount.InnerHtml + "','" + cardnumber + "','" + cardname + "','" + cardtype + "','" + status + "','" + PaymentDt + "','" + PaymentType + "')");
                                                                        if (transaction > 0)
                                                                        {

                                                                        }
                                                                        Email = email;
                                                                        // con.SendMail(Email, orderid, adminmail);
                                                                        Response.Redirect("OrderDetail.aspx?Id=" + OrderNo);
                                                                    }
                                                                }
                                                            }

                                                            //int ordernote = helper.ExecuteNonQuery("insert into OrderNote(Note,OrderID,CreatedDate) values('" + txtnote.Text + "','" + orderid + "','" + DateTime.Now + "')");
                                                            //if (ordernote > 0)
                                                            //{

                                                            //}
                                                            //else
                                                            //{

                                                            //}

                                                        }
                                                    }

                                                }

                                            }
                                        }

                                    }
                                }
                            }


                        }

                        //string PaymentBy = aParam[10];
                        //string UserID = aParam[20];
                        ////objOrder.SiteId = Convert.ToInt32(aParam[20]);
                        //int PlanDetailID = Convert.ToInt32(aParam[21]);
                        //if (objOrder.ActivePlan != 1)
                        //{
                        //    objOrder.AmountPaid = 0;
                        //    objOrder.ActivePlan = 0;
                        //}
                        //EventLogFields objevent = new EventLogFields();
                        //if (aParam[1] == "success")
                        //{
                        //    objevent.EventDetail = "Your payment for subscription has successfully done";
                        //    objevent.EventName = "Payment Successful";
                        //}
                        //else
                        //{
                        //    objevent.EventDetail = "Your payment for subscription has failed";
                        //    objevent.EventName = "Payment Failed";
                        //}
                        //objevent.ModuleType = 4;
                        //objevent.ReferenceNo = objOrder.PlanDetailID.ToString();
                        //objevent.SiteId = 83;
                        //objevent.UpdatedDetails = "";
                        //objevent.userid = objOrder.UserID;
                        //objevent.UserType = 2;
                        //string serializedModel = JsonConvert.SerializeObject(objOrder);
                        //string serializedModel1 = JsonConvert.SerializeObject(objevent);
                        //CommonFunctions.SavePaymentDetail(serializedModel);
                        //CommonFunctions.EventLogEntry(serializedModel1);



                    }
                    else
                    {
                        Response.Redirect("ErrorHandling.aspx");
                        //  Response.Write("Payment Fails! Order Pending to save");
                    }

                }

            }
        }
        catch (Exception ex)
        {
             string filepath = HttpContext.Current.Server.MapPath("~/logfile");
            string Errormsg = ex.GetType().Name.ToString();  
             if (!Directory.Exists(filepath))
             {
                 Directory.CreateDirectory(filepath);

             }
             filepath = filepath + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
             if (!File.Exists(filepath))
             {


                 File.Create(filepath).Dispose();

             }  
             using (StreamWriter sw = File.AppendText(filepath))
             {
                string Exception =ex.ToString();
                string error = ex.StackTrace.ToString() + "Error Message:" + Errormsg + "InnerExpectation" + Exception;
                 
                 
                 
                 
                 sw.WriteLine(error);
             }
            //throw ex;
        }
    }

    public string Generatehash512(string text)
    {

        byte[] message = Encoding.UTF8.GetBytes(text);

        UnicodeEncoding UE = new UnicodeEncoding();
        byte[] hashValue;
        SHA512Managed hashString = new SHA512Managed();
        string hex = "";
        hashValue = hashString.ComputeHash(message);
        foreach (byte x in hashValue)
        {
            hex += String.Format("{0:x2}", x);
        }
        return hex;

    }

    private string Base64Decode(string sBase64String)
    {
        byte[] sBase64String_bytes =
        Convert.FromBase64String(sBase64String);
        return UnicodeEncoding.Default.GetString(sBase64String_bytes);
    }

    public string base64Decode(string data)
    {
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();

            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Decode" + e.Message);
        }
    }





}