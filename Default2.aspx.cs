using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using System.Data;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Script.Services.ScriptMethod()]
    [WebMethod]
    public static List<string> GetEmployeeName(string prefixText, int count)
    {
        List<string> empResult = new List<string>();
        DataTable dt = new DataTable();
        Config sn = new Config();
        dt = sn.GetsearchProduct(prefixText);
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                empResult.Add(dt.Rows[i]["product_name"].ToString());
            }
        }
        return empResult;
    }  
}