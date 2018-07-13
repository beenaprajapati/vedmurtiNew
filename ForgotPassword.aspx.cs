using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using Model;
using System.Data;
public partial class ForgotPassword : System.Web.UI.Page
{
    Config config = new Config();
    DataHelper helper = new DataHelper();
    string username = "";
    string password = "";
    string Email = "";
    EncryptionDecryption enc = new EncryptionDecryption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = new DataSet();
            ds = config.GetEmailAlreadyExist(txtemail.Text);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    username = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    password = ds.Tables[0].Rows[0]["Password"].ToString();

                }
            }

        }
    }
    protected void btnfogot_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = config.GetEmailAlreadyExist(txtemail.Text);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    username = ds.Tables[0].Rows[0]["VACode"].ToString();
                    Email = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    password = ds.Tables[0].Rows[0]["Password"].ToString();
                    
                    var pwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
                    KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                    var Password = EncryptionDecryption.Encrypt(pwd);
                    // var Password1 = pwd.Replace("-", string.Empty).Substring(0, 10);
                    //var pwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                    var Password1 = EncryptionDecryption.Encrypt(password);
                    config.ForgotPassword(pwd, username, Email);
                    int x = helper.ExecuteNonQuery("update [DBO].[USER] set password='" + Password + "' where Userid='" + ds.Tables[0].Rows[0]["UserID"].ToString() + "'");
                    if (x > 0)
                    {
                        lblmessage.Text = "Password send you on your Email Address";
                    }
                    else
                    {

                    }
                }
                else
                {
                    lblmessage.Text = "Email Address Not Registered";
                }
            }
            else
            {
                lblmessage.Text = "Email Address Not Registered";
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}