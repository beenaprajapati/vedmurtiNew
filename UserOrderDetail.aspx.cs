using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
public partial class UserOrderDetail : System.Web.UI.Page
{
    Config conf = new Config();
    DataHelper helper = new DataHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

           GetUserOrderDetail();
        }
        GetUserOrderDetail();
    }
    public void GetUserOrderDetail()
    {
        try
        {
            if (Request.QueryString["UserID"] != null && Request.QueryString["OrderID"] != null)
            {
                System.Data.DataTable ds = new System.Data.DataTable();
                ds.Reset();
                ds = conf.GetAllOrderUserOrderWise(Request.QueryString["UserID"].ToString(), Request.QueryString["OrderID"].ToString());
                if (ds.Rows.Count > 0)
                {
                    if (ds.Rows.Count > 0)
                    {
                        lblCustomername.Text = ds.Rows[0]["CustomerName"].ToString();
                        lblorderDate.Text = ds.Rows[0]["OrderDate"].ToString();
                        lblemail.Text = ds.Rows[0]["EmailAddress"].ToString();
                        lblphone.Text = ds.Rows[0]["phonenumber"].ToString();
                        lbladdress.Text = ds.Rows[0]["Address1"].ToString();
                       // lblcountry.Text = ds.Rows[0]["Countryname"].ToString();
                        lblstate.Text = ds.Rows[0]["state"].ToString();
                        DateTime dt = Convert.ToDateTime(ds.Rows[0]["OrderDate"]);
                        lblorderDate.Text = dt.ToString("dd/MM/yyyy");
                        lblorderno.Text = ds.Rows[0]["OrderNo"].ToString();
                        lblsubtotal.Text = ds.Rows[0]["OrderTotalAmount"].ToString();
                        lblTotal.Text = ds.Rows[0]["OrderTotalAmount"].ToString();
                        string ordernote = ds.Rows[0]["note"].ToString();
                        if (ordernote != "")
                        {
                            divnote.Visible = true;
                            string note = ordernote.Replace("br /", Environment.NewLine);
                            txtnote.Text = note;
                        }
                        else
                        {
                            divnote.Visible = false;
                        }

                        System.Data.DataTable ds1 = new System.Data.DataTable();
                        ds1 = conf.GetProductdetailwithorderid(Request.QueryString["OrderID"].ToString());
                        grduserorder.DataSource = ds1;
                        grduserorder.DataBind();
                        for (int i = 0; i < grduserorder.Rows.Count; i++)
                        {
                            Label lblprice = (Label)grduserorder.Rows[i].FindControl("lblprice");
                            Label lblprototal = (Label)grduserorder.Rows[i].FindControl("lbltotal");
                            Label lblqty = (Label)grduserorder.Rows[i].FindControl("lblqty");
                            int qty = Convert.ToInt32(lblqty.Text);
                            decimal subtotal = Convert.ToDecimal(lblprice.Text) * Convert.ToDecimal(lblqty.Text);
                            lblqty.Text = qty.ToString();
                            lblprototal.Text = subtotal.ToString("0.00");
                        }
                    }
                }
                System.Data.DataSet userdt = new System.Data.DataSet();
                userdt.Reset();
                userdt = conf.GetUserDetailByID(Request.QueryString["UserID"].ToString());
                if(userdt.Tables[0].Rows.Count>0)
                {
                    lblvacode.Text = userdt.Tables[0].Rows[0]["VACode"].ToString();
                    lblvaname.Text = userdt.Tables[0].Rows[0]["Name"].ToString();
                    lblvaemail.Text = userdt.Tables[0].Rows[0]["EmailAddress"].ToString();
                    lblvaphone.Text = userdt.Tables[0].Rows[0]["MobileNo"].ToString();
                    lblvaaddress.Text = userdt.Tables[0].Rows[0]["Address1"].ToString();
                   
                }

            }
            else
            {
                Response.Redirect("User_Login.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grduserorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grduserorder.PageIndex = e.NewPageIndex;
          //  GetUserOrderDetail();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
   
}