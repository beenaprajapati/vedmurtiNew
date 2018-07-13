using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
    
    {
        if (!IsPostBack)
        {
            getPage();
            GetCategorylimit();
            GetNewslimit();
            GetBanner();
        }
    }
    private void getPage()
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_page_detail("8");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    pagecontent.Text = ds.Tables[0].Rows[0]["P_Content"].ToString();
                    pagename.Text = ds.Tables[0].Rows[0]["P_Name"].ToString();

                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    private void GetBanner()
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.Get_Banner();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    bannerID.DataSource = ds.Tables[0];
                    bannerID.DataBind();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    private void GetCategorylimit()
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_products();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rpt_Product.DataSource = ds.Tables[0];
                    rpt_Product.DataBind();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    private void GetNewslimit()
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_brochure_options(4);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Repeater1.DataSource = ds.Tables[0];
                    Repeater1.DataBind();
                }
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
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
}