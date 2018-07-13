using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;

public partial class Main_Master : System.Web.UI.MasterPage
{
    //private string home, about, gallery, news, contact, career, inquiry,download,product;
    public string home { get; set; }
    public string about { get; set; }
    public string gallery { get; set; }
    public string news { get; set; }
    public string contact { get; set; }
    public string career { get; set; }
    public string inquiry { get; set; }
    public string download { get; set; }
    public string product { get; set; }
    public string register { get; set; }
    //public string {get;set;}
    protected void Page_Load(object sender, EventArgs e)
    {
        string ab = string.Empty;
        if (!IsPostBack)
        {

            if (Session["userID"] != null && Session["username"] != null && Session["Role"]=="")
            {
                
                    //Server.Transfer("");
                    Label1.Text = Session["userName"].ToString();
                    lnklogin.Visible = false;
                    lkdownload.Visible = true;
                    lnkdownload.Visible = true;
                    lnkregister.Visible = false;
                    Fillcart();
                
            }
            else if(Session["userID"] != null && Session["username"] != null && Session["Role"]!="")
            {
                Label1.Text = Session["userName"].ToString();
                lnklogin.Visible = false;
                lkdownload.Visible = false;
                lnkdownload.Visible = false;
                lnkregister.Visible = false;
                cart.Visible = false;
            }
            else
            {
                lnkregister.Visible = true;
                lnkdownload.Visible = false;
                lnklogin.Visible = true;
                lkdownload.Visible = false;
                lblMessage.Visible = true;
                lblMessage.Text = "There is no Record in Your Shopping Cart.";

            }
            fillCat();
            Fillcart();
        }
        

     
        //for (int i = 0; i < Request.Url.Segments.Length; i++)
        //{
        //    if (Request.Url.Segments[i].ToString().ToLower().Contains(".aspx"))
        //    {
        //        ab = Request.Url.Segments[i].ToString().ToLower();
        //    }

        //}
        //active(ab);
    }
    private void active(string url)
    {
        string a = url;
        switch (url)
        {
            case "default.aspx":
                home = "active";
                break;
            case "aboutus.aspx":
                about = "active";
                break;
            case "contact-us.aspx":
                contact = "active";
                break;
            case "career.aspx":
                career = "active";
                break;
            case "gallery.aspx":
                gallery = "active";
                break;
            case "download.aspx":
                download = "active";
                break;
            case "inquiry.aspx":
                inquiry = "active";
                break;
            case "news.aspx":
                news = "active";
                break;
            case "product.aspx":
                product = "active";
                break;
            case "registration.aspx":
                register = "active";
                break;
            default:
                break;
        }

    }
    public void fillCat()
    {
        Config config = new Config();
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.Reset();
        ds = config.get_categories();
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptCat.DataSource = ds.Tables[0];
                rptCat.DataBind();
            }
        }

    }
    public void Fillcart()
    {
        if (Session["userID"] != null && Session["username"] != null)
        {
            //Server.Transfer("");
            decimal total = 0;
            Label1.Text = Session["userName"].ToString();
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    //txtqty.Text = ds.Tables[0].Rows[0]["StockQuantity"].ToString();
                    //h1.Value = ds.Tables[0].Rows[0]["Product_id"].ToString();
                    ////txtqty.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                    ////productdesc.Text = ds.Tables[0].Rows[0]["Product_description"].ToString();
                    ////productName.Text = ds.Tables[0].Rows[0]["Product_Name"].ToString();
                    ////Prd_Img.ImageUrl = "product/"+ds.Tables[0].Rows[0]["Product_Image"].ToString();
                    rptcartlist.DataSource = ds.Tables[0];
                    rptcartlist.DataBind();
                    btnGotoCart.Visible = true;

                    Countproduct.Text = ds.Tables[0].Rows.Count.ToString();
                    foreach (RepeaterItem item in rptcartlist.Items)
                    {
                        Label lblprice = (Label)item.FindControl("lblprice");
                        Label lblTotal = (Label)rptcartlist.Controls[rptcartlist.Controls.Count - 1].FindControl("lblTotal");
                        Label lblqty = (Label)item.FindControl("lblqty");
                        // Label lbltotal = (Label)item.FindControl("lbltotal");
                        decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToInt32(lblqty.Text);
                        total += subtotal;
                        //string qty = lblqty.Text;
                        //lblqty.Text = qty.ToString("0.##");
                        lblTotal.Text = total.ToString("0.00");
                    }
                    lnklogin.Visible = false;
                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    rptcartlist.DataSource = null;
                    rptcartlist.DataBind();
                    lblMessage.Visible = true;
                    countdiv.Visible = false;
                    lblMessage.Text = "You have no items in your shopping cart.";
                    btnGotoCart.Visible = false;
                                      
                }
            }
        }
        else
        {
            //Response.Redirect("User_Login.aspx");
            lblMessage.Visible = true;
            lblMessage.Text = "You have no items in your shopping cart.";
            btnGotoCart.Visible = false;
        }

    }
    protected void btnGotoCart_Click(object sender, EventArgs e)
    {
        if (Session["userID"] != null && Session["username"] != null)
        {
            //Server.Transfer("");
            Label1.Text = Session["userName"].ToString();
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect("ViewCart.aspx");
                }
            }
        }
        else
        {

            lblMessage.Visible = true;
            lblMessage.Text = "There is no Record in Your Shopping Cart.";
        }
    }
    protected void lnkprofile_Click(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            string id = Session["userID"].ToString();
            Response.Redirect("EditProfile.aspx?Id=" + id);
        }
        else
        {
            Response.Redirect("User_Login.aspx");
        }

    }
    protected void lnklogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("User_Login.aspx");
        Label1.Visible = true;
    }
    protected void lnklout_Click(object sender, EventArgs e)
    {
        lnkprofile.Visible = false;
        lnklogin.Visible = true;
        Label1.Visible = false;
        Session.Abandon();
        Session.Clear();
        Response.Redirect("User_Login.aspx");

    }
}
