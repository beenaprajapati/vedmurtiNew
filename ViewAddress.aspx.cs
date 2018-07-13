using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using System.Data;
public partial class ViewAddress : System.Web.UI.Page
{
    DataHelper helper = new DataHelper();
    Config config = new Config();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Session["userID"]!=null)
            {
               
                GetAddress();
            }
            else
            {
                Response.Redirect("User_Login.aspx");
            }
        }
        GetAddress();
    }

    public void GetAddress()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Reset();
            string customerID = Session["userID"].ToString();
            ds = config.GetAddressDetail(customerID);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridaddress.DataSource = ds.Tables[0];
                    gridaddress.DataBind();
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    gridaddress.DataSource = null;
                    gridaddress.DataBind();
                }

            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void gridaddress_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridaddress.PageIndex = e.NewPageIndex; GetAddress();
        GetAddress();
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkButton = sender as LinkButton;
            GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
            HiddenField id = (HiddenField)row.FindControl("hdnid");
            

            DataSet Editset = new DataSet();
            Editset.Reset();
            Editset = config.get_Addtocart_detailwithproductuserid(id.Value,Session["userID"].ToString());
            if (Editset.Tables.Count > 0)
            {
                if (Editset.Tables[0].Rows.Count > 0)
                {

                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
}