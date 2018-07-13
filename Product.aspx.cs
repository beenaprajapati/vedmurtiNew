using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Collections;
using Configurations;
using System.Web.UI.HtmlControls;
public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            if (Request.QueryString["id"] != null) 
            {
                getproduct();
            }
        }
    }
    private void getproduct() 
    {
        try
        {
            Config config = new Config();
            System.Data.DataTable ds = new System.Data.DataTable();
            ds.Reset();
            ds = config.get_Product_Category(Request.QueryString["id"].ToString());
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows.Count > 0)
                {
                    PagedDataSource pageds = new PagedDataSource();
                    DataView dv = new DataView(ds);
                    pageds.DataSource = dv;
                    pageds.AllowPaging = true;
                    pageds.PageSize = 9;
                    if (ViewState["PageNumber"] != null)
                        pageds.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
                    else
                        pageds.CurrentPageIndex = 0;
                    if (pageds.PageCount > 1)
                    {
                        rptPaging.Visible = true;
                        ArrayList pages = new ArrayList();
                        for (int i = 0; i < pageds.PageCount; i++)
                            pages.Add((i + 1).ToString());
                        rptPaging.DataSource = pages;
                        rptPaging.DataBind();
                    }
                    else
                    {
                        rptPaging.Visible = false;
                    }
                    //rptUserData.DataSource = pageds;
                    //rptUserData.DataBind();
                    rpt_Product.DataSource = pageds;
                    rpt_Product.DataBind();
                }
            }
            else
            {
                rpt_Product.DataSource = ds;
                rpt_Product.DataBind();
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        //
    }
    public string LimitContent(object x) 
    {
        try
        {
            string retval = string.Empty;
            if (x != null)
            {
                retval = x.ToString();
                if (retval.Length > 200)
                {
                    retval = retval.Substring(0, 200);
                }
            }
            return retval;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
   
   
    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument) - 1;
        getproduct();
    }
    protected void rpt_Product_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (rpt_Product.Items.Count < 1)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                HtmlGenericControl dvNoRec = e.Item.FindControl("dvNoRecords") as HtmlGenericControl;
                if (dvNoRec != null)
                {
                    dvNoRec.Visible = true;
                }
            }
        }
    }
}