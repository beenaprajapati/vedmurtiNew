using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using Model;
using System.Data;
public partial class User_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
        if(!IsPostBack)
        {

        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            Config config = new Config();
            DataSet ds = new DataSet();
            ds = config.UserEmailExist(txtemail.Text);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["user_status"]) == 1)
                    {
                        string password = ds.Tables[0].Rows[0]["Password"].ToString();
                        string getpasswordfromkey = EncryptionDecryption.Decrypt(password);
                        string pwd = EncryptionDecryption.Decrypt(txtpassword.Text);
                        if (getpasswordfromkey == pwd)
                        {
                            Session["username"] = ds.Tables[0].Rows[0]["FirstName"].ToString();
                            Session["userID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                            Session["Role"] = ds.Tables[0].Rows[0]["Role"].ToString();
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            txtemail.BackColor = System.Drawing.ColorTranslator.FromHtml("#fff");
                            //txtemail.BackColor = System.Drawing.ColorTranslator.FromHtml("#8BE7FF");
                            lblmessage.Text = "Wrong Password,Please Enter right password.";
                            
                        }
                    }
                    else
                    {
                        lblmessage.Text = "User is inActive.";
                       
                    }
                }
                else
                {

                    //txtemail.Focus();
                                      //txtemail.Text.Length
                    txtemail.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFE0");
                    lblmessage.Text = "UserName does not exist";
                    //return;
                    //lblmessage.Text = "User Not Exist.";
                }
            }
            
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
    protected void btnforgot_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
}