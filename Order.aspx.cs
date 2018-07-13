using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

using System.Net;
using System.IO;


using System.Net.Mail;
using System.Globalization;
using System.Collections.Generic;
using paytm;
using System.Collections.Specialized;
public partial class Order : System.Web.UI.Page
{
    Config config = new Config();
    DataHelper helper = new DataHelper();
    public string action1 = string.Empty;
    public string hash1 = string.Empty;
    public string txnid1 = string.Empty;
    bool isTestAccount = Convert.ToBoolean(ConfigurationManager.AppSettings["isTestAccount"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            key.Value = ConfigurationManager.AppSettings["MERCHANT_KEY"];
            if (Session["userID"] != null)
            {
                // frmError.Visible = false; // 
                GetAllState();
                GetallAddressDropdown();
                //panel1.Visible = false;
                //panel2.Visible = false;
            }
            else
            {
                Response.Redirect("User_Login.aspx");
            }
            if (string.IsNullOrEmpty(Request.Form["hash"]))
            {
                btnpayment.Visible = true;
            }
            else
            {
                btnpayment.Visible = false;
            }
        }
        Button1.Click += new EventHandler(Button1_Click);
        btncontinue.Click += new EventHandler(btncontinue_Click);
        btnpayment.Click += new EventHandler(btnpayment_Click);
        //   acc2.HeaderContainer.Enabled = false;

        acc2.HeaderContainer.Style.Add("pointer-events", "none");
        acc3.HeaderContainer.Style.Add("pointer-events", "none");
    }
    public void GetallAddressDropdown()
    {
        try
        {
            DataTable ds = new DataTable();
            ds.Reset();
            ds = config.GetAddressDetailwithcustomeriddropdown(Session["userID"].ToString());
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows.Count > 0)
                {
                    ddladdress.DataSource = ds;
                    ddladdress.DataTextField = "Name";
                    ddladdress.DataValueField = "AddressID";
                    ddladdress.DataBind();
                    ddladdress.Items.Add("New Address");
                    panel1.Visible = false;
                    pnlnew.Visible = true;
                    panel2.Visible = false;
                    pnlpay.Visible = false;


                }
            }
            else if (ds.Rows.Count == 0)
            {
                DataSet userdetail = new DataSet();
                userdetail.Reset();
                string userid = Session["userID"].ToString();
                userdetail = config.GetUserDetail(userid);
                if (userdetail.Tables[0].Rows.Count > 0)
                {
                    if (userdetail.Tables[0].Rows.Count > 0)
                    {
                        // txtfirstname.Text = userdetail.Tables[0].Rows[0]["FirstName"].ToString();
                        // txtlastname.Text = userdetail.Tables[0].Rows[0]["LastName"].ToString();
                        // txtemail.Text = userdetail.Tables[0].Rows[0]["EmailAddress"].ToString();
                        // txtphone.Text = userdetail.Tables[0].Rows[0]["MobileNo"].ToString();

                    }
                }
                else
                {

                }
                panel1.Visible = true;
                pnlnew.Visible = false;
                panel2.Visible = false;

                pnlpay.Visible = false;

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }




    public void GetAllState()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Reset();
            ds = config.GetAllState();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dddlstate.DataSource = ds.Tables[0];
                    dddlstate.DataTextField = "StateName";
                    dddlstate.DataValueField = "StateID";
                    dddlstate.DataBind();
                    dddlstate.Items.Insert(0, new ListItem("--Select--", string.Empty));

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btncontinue_Click(object sender, EventArgs e)
    {
        try
        {
            if (ViewState["AddressId"] != null)
            {
                int Addressid = Convert.ToInt32(ViewState["AddressId"]);
                int y = helper.ExecuteNonQuery("update address set FirstName='" + txtfirstname.Text + "',LastName='" + txtlastname.Text + "',EmailAddress='" + txtemail.Text + "',StateID='" + dddlstate.SelectedItem.Value + "',City='" + txtcity.Text + "',Address1='" + txtaddress1.Text + "',Address2='" + txtaddress2.Text + "',Zipcode='" + txtzipcode.Text + "',PhoneNumber='" + txtphone.Text + "',CustomerID='" + Session["userID"].ToString() + "' where AddressID='" + Addressid + "'");
                if (y > 0)
                {
                    decimal total = 0;
                    AccordionCtrl.SelectedIndex = 1;
                    Accorrdion0.TabIndex = -1;
                    acc2.TabIndex = 1;
                    acc2.HeaderContainer.CssClass = "active panel-heading";
                    pnlpay.Visible = true;
                    //panel1.Visible = false;
                    //panel2.Visible = false;
                    //pnlpay.Visible = true;
                    DataSet ds = new DataSet();
                    ds.Reset();
                    ds = config.GetAddressDetailwithaddressid(Session["userID"].ToString(), ViewState["AddressId"].ToString());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblname.Text = txtfirstname.Text + ' ' + txtlastname.Text;
                            lblemail.Text = txtemail.Text;
                            lblphone.Text = txtphone.Text;

                            lblstate.Text = txtcity.Text + ',' + dddlstate.SelectedItem.Text + ' ' + txtzipcode.Text;
                            lbladdress.Text = txtaddress1.Text;

                        }

                    }
                    DataSet dscart = new DataSet();
                    dscart = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
                    if (dscart.Tables.Count > 0)
                    {
                        if (dscart.Tables[0].Rows.Count > 0)
                        {
                            grdviewcart.DataSource = dscart.Tables[0];
                            grdviewcart.DataBind();
                            for (int i = 0; i < grdviewcart.Rows.Count; i++)
                            {
                                Label lblprice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                                Label lblotal = (Label)grdviewcart.Rows[i].FindControl("lblTotal");
                                Label lblqty = (Label)grdviewcart.Rows[i].FindControl("lblqty");
                                // Label lbltotal = (Label)item.FindControl("lbltotal");
                                decimal qty = Convert.ToDecimal(lblqty.Text);
                                lblqty.Text = qty.ToString("0.##");
                                decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                                lblotal.Text = subtotal.ToString("0.00");
                                total += subtotal;
                                lblsubtotal.Text = total.ToString();
                                lblTotal.Text = total.ToString();
                            }
                        }
                        else
                        {
                            grdviewcart.DataSource = null;
                            grdviewcart.DataBind();
                        }
                    }
                    Accorrdion0.TabIndex = -1;
                    acc2.TabIndex = 1;
                    ////Server.Transfer("ViewAddress.aspx");
                }
            }
            else
            {
                int query = helper.ExecuteNonQuery("insert into Address(FirstName,LastName,EmailAddress,StateID,City,Address1,Address2,ZipCode,PhoneNumber,CustomerID,CreatedDate) values('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "','" + dddlstate.SelectedItem.Value + "','" + txtcity.Text + "','" + txtaddress1.Text + "','" + txtaddress2.Text + "','" + txtzipcode.Text + "','" + txtphone.Text + "','" + Session["userID"].ToString() + "','" + DateTime.Now + "')");
                if (query > 0)
                {
                    decimal total = 0;
                    //panel1.Visible = true;
                    //panel2.Visible = false;
                    //pnlpay.Visible = true;
                    DataSet ds = new DataSet();
                    ds.Reset();
                    ds = config.GetAddressDetail(Session["userID"].ToString());
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lblname.Text = txtfirstname.Text + ' ' + txtlastname.Text;
                            lblemail.Text = txtemail.Text;
                            lblphone.Text = txtphone.Text;

                            lblstate.Text = txtcity.Text + ',' + dddlstate.SelectedItem.Text + ' ' + txtzipcode.Text;
                            lbladdress.Text = txtaddress1.Text;

                        }
                        System.Data.DataSet ds1 = new System.Data.DataSet();
                        ds1.Reset();
                        ds1 = config.getAddressmaxid(Session["userID"].ToString());
                        if (ds1.Tables.Count > 0)
                        {
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string addressid = ds1.Tables[0].Rows[0]["AddressID"].ToString();
                                ViewState["AddressId"] = addressid;
                            }
                        }
                    }
                    DataSet dscart = new DataSet();
                    dscart = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
                    if (dscart.Tables.Count > 0)
                    {
                        if (dscart.Tables[0].Rows.Count > 0)
                        {
                            grdviewcart.DataSource = dscart.Tables[0];
                            grdviewcart.DataBind();
                            for (int i = 0; i < grdviewcart.Rows.Count; i++)
                            {
                                Label lblprice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                                Label lblotal = (Label)grdviewcart.Rows[i].FindControl("lblTotal");
                                Label lblqty = (Label)grdviewcart.Rows[i].FindControl("lblqty");
                                // Label lbltotal = (Label)item.FindControl("lbltotal");
                                decimal qty = Convert.ToDecimal(lblqty.Text);
                                lblqty.Text = qty.ToString("0.##");
                                decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                                lblotal.Text = subtotal.ToString("0.00");
                                total += subtotal;
                                lblsubtotal.Text = total.ToString();
                                lblTotal.Text = total.ToString();
                            }
                        }
                        else
                        {
                            grdviewcart.DataSource = null;
                            grdviewcart.DataBind();
                        }
                    }
                    AccordionCtrl.SelectedIndex = 1;
                    Accorrdion0.TabIndex = -1;
                    acc2.TabIndex = 1;
                    pnlpay.Visible = true;
                    //pnlneaccw.Visible = false;
                    //panel1.Visible = false;
                    //panel2.Visible = false;
                    //pnlpay.Visible = true;


                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnconfirm_Click(object sender, EventArgs e)
    {
        AccordionCtrl.SelectedIndex = 2;
        Accorrdion0.TabIndex = -1;
        acc2.TabIndex = -1;
        acc3.TabIndex = 1;
        panel2.Visible = true;
        decimal total = 0;
        System.Data.DataSet ds = new DataSet();
        string userid = Session["userID"].ToString();
        ds = config.get_Addtocart_detailwithuserid(userid);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                Repeater rptcart = (Repeater)Master.FindControl("rptcartlist");
                if (rptcart != null)
                {
                    rptcart.DataSource = ds.Tables[0];
                    rptcart.DataBind();
                    foreach (RepeaterItem item in rptcart.Items)
                    {
                        Label lblprice = (Label)item.FindControl("lblprice");
                        //Label lblcountproduct = (Label)item.FindControl("Countproduct");
                        //lblcountproduct.Text = ds.Tables[0].Rows.Count.ToString();
                        Label lblTotal = (Label)rptcart.Controls[rptcart.Controls.Count - 1].FindControl("lblTotal");
                        Label lblqty = (Label)item.FindControl("lblqty");
                        // Label lbltotal = (Label)item.FindControl("lbltotal");
                        decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                        total += subtotal;
                        //string qty = lblqty.Text;
                        //lblqty.Text = qty.ToString("0.##");
                        lblTotal.Text = total.ToString("0.00");
                        ViewState["PlaceAmount"] = lblTotal.Text;
                    }
                }
            }
        }
        try
        {
            if (rdpay.Checked == true)
            {
                if (ViewState["AddressId"] != null)
                {

                    string[] hashVarsSeq;
                    string hash_string = string.Empty;
                    string pinfo = GetJson();
                    string note = string.IsNullOrEmpty(txtnote.Text) ? " " : txtnote.Text;
                    Session["Note"] = note;
                    string ret_url = ConfigurationManager.AppSettings["SiteUrl"] + "ResponseHandling.aspx?AddressID=" + ViewState["AddressId"];
                    if (string.IsNullOrEmpty(Request.Form["txnid"])) // generating txnid
                    {
                        Random rnd = new Random();
                        string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                        txnid1 = strHash.ToString().Substring(0, 20);
                    }
                    else
                    {
                        txnid1 = Request.Form["txnid"];
                    }
                    int Addressid = Convert.ToInt32(ViewState["AddressId"]);

                    panel1.Visible = false;
                    panel2.Visible = false;
                    DataSet getaddress = new DataSet();
                    getaddress.Reset();
                    getaddress = config.GetAddressDetailwithaddressid(Session["userID"].ToString(), ViewState["AddressId"].ToString());
                    if (getaddress.Tables.Count > 0)
                    {
                        if (getaddress.Tables[0].Rows.Count > 0)
                        {
                            ViewState["Firstname"] = getaddress.Tables[0].Rows[0]["firstname"].ToString();
                            ViewState["LastName"] = getaddress.Tables[0].Rows[0]["LastName"].ToString();
                            ViewState["Email"] = getaddress.Tables[0].Rows[0]["EmailAddress"].ToString();
                            ViewState["Phonenumber"] = getaddress.Tables[0].Rows[0]["PhoneNumber"].ToString();

                            ViewState["State"] = getaddress.Tables[0].Rows[0]["state"].ToString();
                            ViewState["address1"] = getaddress.Tables[0].Rows[0]["Address1"].ToString();
                            ViewState["City"] = getaddress.Tables[0].Rows[0]["City"].ToString();
                            ViewState["address2"] = getaddress.Tables[0].Rows[0]["Address2"].ToString();
                            ViewState["ZipCode"] = getaddress.Tables[0].Rows[0]["ZipCode"].ToString();
                            ViewState["productinfo"] = ViewState["AddressId"];

                        }

                    }
                    if (string.IsNullOrEmpty(Request.Form["hash"])) // generating hash value
                    {
                        if (
                            string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]) ||
                            string.IsNullOrEmpty(txnid1) ||
                            string.IsNullOrEmpty(ViewState["PlaceAmount"].ToString()) ||
                            string.IsNullOrEmpty(ViewState["Firstname"].ToString()) ||
                                string.IsNullOrEmpty(ViewState["Email"].ToString()) ||
                                string.IsNullOrEmpty(ViewState["Phonenumber"].ToString()) ||
                                string.IsNullOrEmpty(ViewState["productinfo"].ToString()) ||
                              string.IsNullOrEmpty(ret_url))
                        {
                            //frmError.Visible = true;
                            return;
                        }
                        else
                        {
                            //frmError.Visible = false;
                            hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                            hash_string = "";
                            foreach (string hash_var in hashVarsSeq)
                            {
                                if (hash_var == "key")
                                {
                                    hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "txnid")
                                {
                                    hash_string = hash_string + txnid1;
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "amount")
                                {
                                    hash_string = hash_string + Convert.ToDecimal(ViewState["PlaceAmount"]).ToString("g29");
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "productinfo")
                                {
                                    hash_string = hash_string + ViewState["productinfo"].ToString();
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "firstname")
                                {
                                    hash_string = hash_string + ViewState["Firstname"].ToString();
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "email")
                                {
                                    hash_string = hash_string + ViewState["Email"].ToString();
                                    hash_string = hash_string + '|';
                                }

                                else
                                {
                                    hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                                    hash_string = hash_string + '|';
                                }
                            }
                            hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT
                            hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                            action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL
                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.Form["hash"]))
                    {
                        hash1 = Request.Form["hash"];
                        action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";
                    }
                    if (!string.IsNullOrEmpty(hash1))
                    {
                        hash.Value = hash1;
                        txnid.Value = txnid1;

                        System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                        data.Add("hash", hash.Value);
                        data.Add("txnid", txnid.Value);
                        data.Add("key", key.Value);
                        string AmountForm = Convert.ToDecimal(ViewState["PlaceAmount"]).ToString("g29");// eliminating trailing zeros

                        data.Add("amount", AmountForm);
                        data.Add("firstname", ViewState["Firstname"].ToString());
                        data.Add("email", ViewState["Email"].ToString());
                        data.Add("phone", ViewState["Phonenumber"].ToString());
                        data.Add("productinfo", ViewState["productinfo"].ToString());
                        data.Add("surl", ret_url.Trim());
                        data.Add("furl", ret_url.Trim());
                        data.Add("lastname", ViewState["LastName"].ToString());
                        data.Add("curl", "");
                        data.Add("address1", ViewState["address1"].ToString());
                        data.Add("address2", ViewState["address2"].ToString());
                        data.Add("city", ViewState["City"].ToString());

                        data.Add("state", ViewState["State"].ToString());
                        data.Add("zipcode", ViewState["ZipCode"].ToString());
                        data.Add("udf1", "");
                        data.Add("udf2", "");
                        data.Add("udf3", "");
                        data.Add("udf4", "");
                        data.Add("udf5", "");
                        data.Add("pg", "");


                        string strForm = PreparePOSTForm(action1, data);
                        Page.Controls.Add(new LiteralControl(strForm));

                    }

                    else
                    {
                        //no hash

                    }
                }
                else
                {
                    string[] hashVarsSeq;
                    string hash_string = string.Empty;
                    string pinfo = GetJson();
                    string ret_url = ConfigurationManager.AppSettings["SiteUrl"] + "ResponseHandling.aspx?AddressID=" + ViewState["AddressId"] + "&Note=" + string.IsNullOrEmpty(txtnote.Text);
                    if (string.IsNullOrEmpty(Request.Form["txnid"])) // generating txnid
                    {
                        Random rnd = new Random();
                        string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
                        txnid1 = strHash.ToString().Substring(0, 20);
                    }
                    else
                    {
                        txnid1 = Request.Form["txnid"];
                    }
                    if (string.IsNullOrEmpty(Request.Form["hash"])) // generating hash value
                    {
                        if (
                            string.IsNullOrEmpty(ConfigurationManager.AppSettings["MERCHANT_KEY"]) ||
                            string.IsNullOrEmpty(txnid1) ||
                            string.IsNullOrEmpty(ViewState["PlaceAmount"].ToString()) ||
                            string.IsNullOrEmpty(txtfirstname.Text) ||
                                string.IsNullOrEmpty(txtemail.Text) ||
                                string.IsNullOrEmpty(txtphone.Text) ||
                                string.IsNullOrEmpty(ViewState["productinfo"].ToString()) ||
                              string.IsNullOrEmpty(ret_url))
                        {
                            //frmError.Visible = true;
                            return;
                        }
                        else
                        {
                            //frmError.Visible = false;
                            hashVarsSeq = ConfigurationManager.AppSettings["hashSequence"].Split('|'); // spliting hash sequence from config
                            hash_string = "";
                            foreach (string hash_var in hashVarsSeq)
                            {
                                if (hash_var == "key")
                                {
                                    hash_string = hash_string + ConfigurationManager.AppSettings["MERCHANT_KEY"];
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "txnid")
                                {
                                    hash_string = hash_string + txnid1;
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "amount")
                                {
                                    hash_string = hash_string + Convert.ToDecimal(ViewState["PlaceAmount"]).ToString("g29");
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "productinfo")
                                {
                                    hash_string = hash_string + ViewState["productinfo"].ToString();
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "firstname")
                                {
                                    hash_string = hash_string + txtfirstname.Text;
                                    hash_string = hash_string + '|';
                                }
                                else if (hash_var == "email")
                                {
                                    hash_string = hash_string + txtemail.Text;
                                    hash_string = hash_string + '|';
                                }

                                else
                                {
                                    hash_string = hash_string + (Request.Form[hash_var] != null ? Request.Form[hash_var] : "");// isset if else
                                    hash_string = hash_string + '|';
                                }
                            }
                            hash_string += ConfigurationManager.AppSettings["SALT"];// appending SALT
                            hash1 = Generatehash512(hash_string).ToLower();         //generating hash
                            action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";// setting URL
                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.Form["hash"]))
                    {
                        hash1 = Request.Form["hash"];
                        action1 = ConfigurationManager.AppSettings["PAYU_BASE_URL"] + "/_payment";
                    }
                    if (!string.IsNullOrEmpty(hash1))
                    {
                        hash.Value = hash1;
                        txnid.Value = txnid1;

                        System.Collections.Hashtable data = new System.Collections.Hashtable(); // adding values in gash table for data post
                        data.Add("hash", hash.Value);
                        data.Add("txnid", txnid.Value);
                        data.Add("key", key.Value);
                        string AmountForm = Convert.ToDecimal(ViewState["PlaceAmount"]).ToString("g29");// eliminating trailing zeros

                        data.Add("amount", AmountForm);
                        data.Add("firstname", txtfirstname.Text.Trim());
                        data.Add("email", txtemail.Text.Trim());
                        data.Add("phone", txtphone.Text.Trim());
                        data.Add("productinfo", ViewState["productinfo"].ToString());
                        data.Add("surl", ret_url.Trim());
                        data.Add("furl", ret_url.Trim());
                        data.Add("lastname", txtlastname.Text.Trim());
                        data.Add("curl", "");
                        data.Add("address1", txtaddress1.Text.Trim());
                        data.Add("address2", txtaddress2.Text.Trim());
                        data.Add("city", txtcity.Text.Trim());
                        data.Add("state", dddlstate.SelectedItem.Text.Trim());

                        data.Add("zipcode", txtzipcode.Text.Trim());
                        data.Add("udf1", "");
                        data.Add("udf2", "");
                        data.Add("udf3", "");
                        data.Add("udf4", "");
                        data.Add("udf5", "");
                        data.Add("pg", "");


                        string strForm = PreparePOSTForm(action1, data);
                        Page.Controls.Add(new LiteralControl(strForm));

                    }

                    else
                    {
                        //no hash

                    }
                }
            }
            else if (rdpaypal.Checked == true)
            {

                string ToEmail, Email;
                string addressid = ViewState["AddressId"].ToString();
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
                    dsorderno = config.getorderorderno(Session["userID"].ToString());
                    string OrderNo = "";
                    if (dsorderno.Tables[0].Rows[0]["Orderid"].ToString() == "")
                    {
                        OrderNo = "001";
                    }
                    else
                    {
                        OrderNo =  dsorderno.Tables[0].Rows[0]["Orderid"].ToString().PadLeft(3, '0');
                    }
                    int x = helper.ExecuteNonQuery("insert into [dbo].[order]  (OrderNo,CustomerID,AddressID,OrderDate,Order_Status,OrderTotalAmount) VALUES('" + OrderNo + "','" + Session["UserID"].ToString() + "','" + addressid + "','" + DateTime.Now + "','" + 0 + "','" + ViewState["PlaceAmount"].ToString() + "')");
                    if (x > 0)
                    {

                        System.Data.DataSet dsCode = new System.Data.DataSet();
                        ds.Reset();
                        System.Data.DataSet ds1 = new System.Data.DataSet();
                        ds1.Reset();
                        ds1 = config.getordermaxid(Session["userID"].ToString());
                        if (ds1.Tables.Count > 0)
                        {
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string orderid = ds1.Tables[0].Rows[0]["Orderid"].ToString();
                                DataSet dtdate = new DataSet();
                                dtdate = config.getOrderID(orderid);
                                DateTime orderdate = Convert.ToDateTime(dtdate.Tables[0].Rows[0]["OrderDate"].ToString());
                                string OrderDate = Convert.ToDateTime(orderdate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
                                dsCode = config.GetUserDetail(Session["userID"].ToString());
                                string vacode = dsCode.Tables[0].Rows[0]["VACode"].ToString();
                                System.Data.DataSet ds2 = new System.Data.DataSet();
                                var templateString = "";
                                List<ListItem> lst = new List<ListItem>();
                                ds2.Reset();
                                ds2 = config.getadmindetail();
                                DataSet userdetail = new DataSet();
                                userdetail = config.Getorder(orderid);
                                if (ds2.Tables.Count > 0)
                                {
                                    if (ds2.Tables[0].Rows.Count > 0)
                                    {
                                        string adminmail = ds2.Tables[0].Rows[0]["admin_email"].ToString();
                                        if (dsCode.Tables.Count > 0)
                                        {
                                            if (dsCode.Tables[0].Rows.Count > 0)
                                            {
                                                decimal Total = 0;
                                                System.Data.DataSet getdetail = new DataSet();
                                                string Userid = Session["userID"].ToString();
                                                getdetail = config.get_Addtocart_detailwithuserid(Userid);
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
                                                                Total += subtotal;
                                                                lblTotal.Text = Total.ToString("0.00");
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
                                                            Msg.To.Add(lblemail.Text);
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
                                                            int oredernote = helper.ExecuteNonQuery("insert into ordernote(Note,OrderID,CreatedDate) values('" + txtnote.Text + "','" + orderid + "','" + DateTime.Now.ToString() + "')");
                                                            if (oredernote > 0)
                                                            {

                                                            }
                                                            //int transaction = helper.ExecuteNonQuery("insert into ordertransaction (TransactionID,InvoiceNum,Amount,CardNumber,CardName,CardType,Status,PaymentDate,PaymentType) values('" + tid.InnerHtml + "','" + orderid + "','" + Amount.InnerHtml + "','" + cardnumber + "','" + cardname + "','" + cardtype + "','" + status + "','" + PaymentDt + "','" + PaymentType + "')");
                                                            //if (transaction > 0)
                                                            //{

                                                            //}
                                                            Email = lblemail.Text;

                                                            //config.SendMail(Email, orderid, adminmail);
                                                            String merchantKey = ConfigurationManager.AppSettings["merchantKey"].ToString();
                                                            Dictionary<string, string> parameters = new Dictionary<string, string>();
                                                            parameters.Add("MID", ConfigurationManager.AppSettings["merchantId"].ToString());
                                                            parameters.Add("CHANNEL_ID", 
                                                                "WEB");
                                                            parameters.Add("INDUSTRY_TYPE_ID", ConfigurationManager.AppSettings["INDUSTRY_TYPE_ID"].ToString());
                                                            parameters.Add("WEBSITE", ConfigurationManager.AppSettings["WEBSITE"].ToString());
                                                            parameters.Add("EMAIL", lblemail.Text);
                                                            parameters.Add("MOBILE_NO", lblphone.Text);
                                                            parameters.Add("CUST_ID", Session["UserID"].ToString());
                                                            parameters.Add("ORDER_ID", OrderNo);
                                                            parameters.Add("TXN_AMOUNT", ViewState["PlaceAmount"].ToString());
                                                            parameters.Add("CALLBACK_URL", ConfigurationManager.AppSettings["SiteUrl"].ToString() + "OrderDetail.aspx?Id=" + OrderNo); //This parameter is not mandatory. Use this to pass the callback url dynamically.

                                                            string checksum = paytm.CheckSum.generateCheckSum(merchantKey, parameters);
                                                            Boolean success = paytm.CheckSum.verifyCheckSum(merchantKey, parameters, checksum);
                                                            string paytmURL = ConfigurationManager.AppSettings["paytmURL"].ToString() + parameters.FirstOrDefault(x1 => x1.Key == "ORDER_ID").Value;

                                                            string outputHTML = "<html>";
                                                            outputHTML += "<head>";
                                                            outputHTML += "<title>Merchant Check Out Page</title>";
                                                            outputHTML += "</head>";
                                                            outputHTML += "<body>";
                                                            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
                                                            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
                                                            outputHTML += "<table border='1'>";
                                                            outputHTML += "<tbody>";
                                                            foreach (string key in parameters.Keys)
                                                            {
                                                                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
                                                            }
                                                            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
                                                            outputHTML += "</tbody>";
                                                            outputHTML += "</table>";
                                                            outputHTML += "<script type='text/javascript'>";
                                                            outputHTML += "document.f1.submit();";
                                                            outputHTML += "</script>";
                                                            outputHTML += "</form>";
                                                            outputHTML += "</body>";
                                                            outputHTML += "</html>";
                                                            string htmldate = outputHTML;
                                                            Response.Write(htmldate);
                                                            
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

                //Success return page url

            }
        }
        catch (Exception ex)
        {
            Response.Write("<span style='color:red'>" + ex.Message + "</span>");

        }

    }


    protected void lnkdeliver_Click(object sender, EventArgs e)
    {
        try
        {
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            HiddenField hdaddressid = (HiddenField)item.FindControl("hdnid");
            string customerid = Convert.ToString(Session["userID"]);
            string Addressid = Convert.ToString(hdaddressid.Value);
            decimal total = 0;
            pnlnew.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            DataSet ds = new DataSet();
            ds.Reset();
            ds = config.GetAddressDetailwithaddressid(customerid, Addressid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblemail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();

                    lblstate.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                    lbladdress.Text = ds.Tables[0].Rows[0]["Address1"].ToString();

                }

            }
            DataSet dscart = new DataSet();
            dscart = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
            if (dscart.Tables.Count > 0)
            {
                if (dscart.Tables[0].Rows.Count > 0)
                {
                    grdviewcart.DataSource = dscart.Tables[0];
                    grdviewcart.DataBind();
                    for (int i = 0; i < grdviewcart.Rows.Count; i++)
                    {
                        Label lblprice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                        Label lblotal = (Label)grdviewcart.Rows[i].FindControl("lblTotal");
                        Label lblqty = (Label)grdviewcart.Rows[i].FindControl("lblqty");
                        // Label lbltotal = (Label)item.FindControl("lbltotal");
                        decimal qty = Convert.ToDecimal(lblqty.Text);
                        lblqty.Text = qty.ToString("0.##");
                        decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                        lblotal.Text = subtotal.ToString("0.00");
                        total += subtotal;
                        lblsubtotal.Text = total.ToString();
                        lblTotal.Text = total.ToString();
                    }
                }
                else
                {
                    grdviewcart.DataSource = null;
                    grdviewcart.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    //protected void lnkedit_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Config config = new Config();
    //        DataHelper helper = new DataHelper();
    //        if (Session["userID"] != null && Session["username"] != null)
    //        {
    //            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
    //            HiddenField hdaddressid = (HiddenField)item.FindControl("hdnid");
    //            string customerid = Convert.ToString(Session["userID"]);
    //            string Addressid = Convert.ToString(hdaddressid.Value);
    //                DataSet edit = new DataSet();
    //                edit = config.EditAddresswithcustomerid(Addressid, customerid);
    //                if (edit.Tables.Count > 0)
    //                {
    //                    if (edit.Tables[0].Rows.Count > 0)
    //                    {
    //                        pnlnew.Visible = false;
    //                        panel1.Visible = true;
    //                        txtfirstname.Text = edit.Tables[0].Rows[0]["FirstName"].ToString();
    //                        txtlastname.Text = edit.Tables[0].Rows[0]["LastName"].ToString();
    //                        txtemail.Text = edit.Tables[0].Rows[0]["EmailAddress"].ToString();
    //                        txtphone.Text = edit.Tables[0].Rows[0]["PhoneNumber"].ToString();
    //                        txtzipcode.Text = edit.Tables[0].Rows[0]["ZipCode"].ToString();
    //                        txtcity.Text = edit.Tables[0].Rows[0]["City"].ToString();
    //                        txtaddress1.Text = edit.Tables[0].Rows[0]["Address1"].ToString();
    //                        txtaddress2.Text = edit.Tables[0].Rows[0]["Address2"].ToString();
    //                        GetAllCountry();
    //                        if (edit.Tables[0].Rows[0]["CountryID"].ToString() == "")
    //                        {

    //                        }
    //                        else
    //                        {
    //                            ddlcountry.SelectedValue = edit.Tables[0].Rows[0]["CountryID"].ToString();
    //                        }
    //                        GetAllState();
    //                        if (edit.Tables[0].Rows[0]["StateID"].ToString() == "")
    //                        {

    //                        }
    //                        else
    //                        {
    //                            dddlstate.SelectedValue = edit.Tables[0].Rows[0]["StateID"].ToString();
    //                        }
    //                    }
    //                }
    //                ViewState["AddressId"] = Addressid;


    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //protected void lnkdelete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {


    //        Config config = new Config();
    //        DataHelper helper = new DataHelper();
    //        if (Session["userID"] != null && Session["username"] != null)
    //        {
    //            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
    //            HiddenField hdaddressid = (HiddenField)item.FindControl("hdnid");
    //            string customerid = Convert.ToString(Session["userID"]);
    //            string Addressid = Convert.ToString(hdaddressid.Value);
    //            DataSet edit = new DataSet();
    //            edit = config.EditAddresswithcustomerid(Addressid, customerid);
    //            if (edit.Tables.Count > 0)
    //            {
    //                if (edit.Tables[0].Rows.Count > 0)
    //                {
    //                    int x = helper.ExecuteNonQuery("delete from address where AddressID='" + Addressid + "' And CustomerID='" + customerid + "'");
    //                    if (x > 0)
    //                    {
    //                        pnlnew.Visible = true;
    //                        panel1.Visible = false;
    //                        panel2.Visible = false;
    //                        GetAllAddress();
    //                    }
    //                    else
    //                    {

    //                    }

    //                }
    //            }
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        throw ex;
    //    }

    //}
    //protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    //{
    //    try
    //    {
    //        ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument) - 1;
    //        GetAllAddress();
    //    }
    //    catch(Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void ddladdress_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddladdress.SelectedItem.Text == "New Address")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                pnlnew.Visible = true;
                Button1.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = false;
                pnlnew.Visible = true;
                Button1.Visible = true;
                //int Addressid = Convert.ToInt32(ddladdress.SelectedItem.Value);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public string GetJson()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;

        DataTable dtEmployee = new DataTable();
        dtEmployee.Columns.Add("name", typeof(string));
        dtEmployee.Columns.Add("description", typeof(string));
        dtEmployee.Columns.Add("value", typeof(string));
        dtEmployee.Columns.Add("merchantId", typeof(string));
        dtEmployee.Columns.Add("commission", typeof(string));
        dtEmployee.Rows.Add("EMAAR20147f606866-5754-4a80-afa5-d44c0c9c3abe", "EMAAR Test DescriptionInstallment*1Installmen", "8", "396446", "2");
        foreach (DataRow dr in dtEmployee.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dtEmployee.Columns)
            {
                row.Add(col.ColumnName, dr[col]);
            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            string addressid = Convert.ToString(ddladdress.SelectedItem.Value);
            ViewState["AddressId"] = addressid;
            //pnlnew.Visible = false;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //pnlpay.Visible = true;
            //acr1.FindControl("acc2").Visible = true;
            AccordionCtrl.SelectedIndex = 1;
            Accorrdion0.TabIndex = -1;
            acc2.TabIndex = 1;

            pnlpay.Visible = true;
            decimal total = 0;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //pnlpay.Visible = true;
            // acc1.TabIndex = -1;
            DataSet ds = new DataSet();
            ds.Reset();
            ds = config.GetAddressDetailwithaddressid(Session["userID"].ToString(), addressid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblemail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();

                    lblstate.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                    lbladdress.Text = ds.Tables[0].Rows[0]["Address1"].ToString();

                }

            }
            DataSet dscart = new DataSet();
            dscart = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
            if (dscart.Tables.Count > 0)
            {
                if (dscart.Tables[0].Rows.Count > 0)
                {
                    grdviewcart.DataSource = dscart.Tables[0];
                    grdviewcart.DataBind();
                    for (int i = 0; i < grdviewcart.Rows.Count; i++)
                    {
                        Label lblprice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                        Label lblotal = (Label)grdviewcart.Rows[i].FindControl("lblTotal");
                        Label lblqty = (Label)grdviewcart.Rows[i].FindControl("lblqty");
                        // Label lbltotal = (Label)item.FindControl("lbltotal");
                        decimal qty = Convert.ToDecimal(lblqty.Text);
                        lblqty.Text = qty.ToString("0.##");
                        decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                        lblotal.Text = subtotal.ToString("0.00");
                        total += subtotal;
                        lblsubtotal.Text = total.ToString();
                        lblTotal.Text = total.ToString();
                    }
                }
                else
                {
                    grdviewcart.DataSource = null;
                    grdviewcart.DataBind();
                }
            }

            ////Server.Transfer("ViewAddress.aspx");


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
    {
        //Set a name for the form
        string formID = "PostForm";
        //Build the form using the specified data to be posted.
        StringBuilder strForm = new StringBuilder();
        strForm.Append("<form id=\"" + formID + "\" name=\"" +
                       formID + "\" action=\"" + url +
                       "\" method=\"POST\">");

        foreach (System.Collections.DictionaryEntry key in data)
        {

            strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                           "\" value=\"" + key.Value + "\">");
        }


        strForm.Append("</form>");
        //Build the JavaScript which will do the Posting operation.
        StringBuilder strScript = new StringBuilder();
        strScript.Append("<script language='javascript'>");
        strScript.Append("var v" + formID + " = document." +
                         formID + ";");
        strScript.Append("v" + formID + ".submit();");
        strScript.Append("</script>");
        //Return the form and the script concatenated.
        //(The order is important, Form then JavaScript)
        return strForm.ToString() + strScript.ToString();
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
    protected void btnpayment_Click(object sender, EventArgs e)
    {
        try
        {

            acc2.HeaderContainer.Style.Add("pointer-events", "auto");
            string addressid = ViewState["AddressId"].ToString();
            //  ViewState["AddressId"] = addressid;
            //pnlnew.Visible = false;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //pnlpay.Visible = true;
            //acr1.FindControl("acc2").Visible = true;
            AccordionCtrl.SelectedIndex = 2;
            Accorrdion0.TabIndex = -1;
            acc2.TabIndex = -1;
            acc3.TabIndex = 1;

            panel2.Visible = true;
            decimal total = 0;
            //panel1.Visible = false;
            //panel2.Visible = false;
            //pnlpay.Visible = true;
            // acc1.TabIndex = -1;
            DataSet ds = new DataSet();
            ds.Reset();
            ds = config.GetAddressDetailwithaddressid(Session["userID"].ToString(), addressid);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    lblemail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblphone.Text = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();

                    lblstate.Text = ds.Tables[0].Rows[0]["StateName"].ToString();
                    lbladdress.Text = ds.Tables[0].Rows[0]["Address1"].ToString();

                }

            }
            DataSet dscart = new DataSet();
            dscart = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
            if (dscart.Tables.Count > 0)
            {
                if (dscart.Tables[0].Rows.Count > 0)
                {
                    grdviewcart.DataSource = dscart.Tables[0];
                    grdviewcart.DataBind();
                    for (int i = 0; i < grdviewcart.Rows.Count; i++)
                    {
                        Label lblprice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                        Label lblotal = (Label)grdviewcart.Rows[i].FindControl("lblTotal");
                        Label lblqty = (Label)grdviewcart.Rows[i].FindControl("lblqty");
                        // Label lbltotal = (Label)item.FindControl("lbltotal");
                        decimal qty = Convert.ToDecimal(lblqty.Text);
                        lblqty.Text = qty.ToString("0.##");
                        decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                        lblotal.Text = subtotal.ToString("0.00");
                        total += subtotal;
                        lblsubtotal.Text = total.ToString();
                        lblTotal.Text = total.ToString();
                    }
                }
                else
                {
                    grdviewcart.DataSource = null;
                    grdviewcart.DataBind();
                }
            }

            ////Server.Transfer("ViewAddress.aspx");


        }
        catch (Exception ex)
        {
            throw ex;
        }


    }






}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         