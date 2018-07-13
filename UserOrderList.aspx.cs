using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;

public partial class UserOrderList : System.Web.UI.Page
{
    Config config = new Config();
    DataHelper helper = new DataHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetOrderUserWise();
        }
        GetOrderUserWise();
    }
    public void GetOrderUserWise()
    {
        try
        {
            if (Session["userID"] != null)
            {
                System.Data.DataTable ds = new System.Data.DataTable();
                ds.Reset();
                string customerID = Session["userID"].ToString();
                ds = config.GetAllOrderUserWise(customerID);
                if (ds.Rows.Count > 0)
                {
                    grdOrderlist.DataSource = ds;
                    grdOrderlist.DataBind();
                }
                else
                {
                    grdOrderlist.DataSource = null;
                    grdOrderlist.DataBind();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }

    }
    protected void grdOrderlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdOrderlist.PageIndex = e.NewPageIndex;
            GetOrderUserWise();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkview_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = ((LinkButton)sender).NamingContainer as GridViewRow;
            HiddenField lblID = (HiddenField)row.FindControl("hdnID");
            int orderid = Convert.ToInt32(lblID.Value);
            Response.Redirect("UserOrderDetail.aspx?OrderID=" + orderid + "&UserID=" + Session["userID"].ToString());
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}