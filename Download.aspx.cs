using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Configurations;

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getDownloads();
        }
        getDownloads();
    }

    private void getDownloads() 
    {
        try
        {
            Config config = new Config();
            System.Data.DataTable ds = new System.Data.DataTable();
            ds.Reset();
            ds = config.get_download();
            if (ds.Rows.Count > 0)
            {
                if (ds.Rows.Count > 0)
                {
                    PagedDataSource pageds = new PagedDataSource();
                    DataView dv = new DataView(ds);
                    pageds.DataSource = dv;
                    pageds.AllowPaging = true;
                    pageds.PageSize = 5;
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
                    rpt_Product.DataSource = pageds;
                    rpt_Product.DataBind();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        ViewState["PageNumber"] = Convert.ToInt32(e.CommandArgument) - 1;
        getDownloads();
    }
}