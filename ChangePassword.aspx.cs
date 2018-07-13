using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using Model;
public partial class ChangePassword : System.Web.UI.Page
{
    Config conf = new Config();
    DataHelper helper = new DataHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserDetail();
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["userID"] != null)
            {
                var pwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                //KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                var Password = EncryptionDecryption.Encrypt(txtpassword.Text);
                int z = helper.ExecuteNonQuery("update [dbo].[user] set Password ='" + Password + "' where UserID='" + Session["userID"].ToString() + "'");
                if (z > 0)
                {
                    string message = "Password Change Successfully";
                    string url = "default.aspx";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
                else
                {
                    string message = "There is error";
                    string url = "default.aspx";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
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
    public void GetUserDetail()
    {
        try
        {
            if (Session["userID"] != null && Session["username"] != null)
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Reset();
                ds = conf.GetUserDetail(Session["userID"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtemail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();

                    }
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
}