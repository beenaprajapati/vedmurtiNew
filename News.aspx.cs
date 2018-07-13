using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;

public partial class News : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            GetBrochure();
        }
    }
    private void GetBrochure() 
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_brochure();
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
}