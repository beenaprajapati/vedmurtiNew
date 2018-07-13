using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;

public partial class Contact_Us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            getPage();
        }
    }
    private void getPage()
    {
        try
        {
            Config config = new Config();
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Reset();
            ds = config.get_page_detail("10");
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
}