using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using Model;

using System.IO;
using System.Data;
public partial class Register : System.Web.UI.Page
{
    DataHelper helper = new DataHelper();
    EncryptionDecryption enc = new EncryptionDecryption();
    Config config = new Config();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userID"] != null)
            {
                // frmError.Visible = false; // 
                Session.Abandon();
                Session.Clear();
                //panel2.Visible = false;
            }
            else
            {

            }
            GetAllState();
        }
    }
    public void GetAllState()
    {
        try
        {
            DataSet ds = new DataSet();
            ds.Reset();
            ds = config.GetAllState();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlstate.DataSource = ds.Tables[0];
                    ddlstate.DataTextField = "StateName";
                    ddlstate.DataValueField = "StateID";
                    ddlstate.DataBind();
                    ddlstate.Items.Insert(0, new ListItem("--Select--", string.Empty));


                }
                else if (ds.Tables[0].Rows.Count == 0)
                {
                    ddlstate.DataSource = "";
                    ddlstate.DataBind();
                    ddlstate.Items.Insert(0, new ListItem("--Select--", string.Empty));
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }                                                                                                                                                             
    protected void btnregister_Click(object sender, EventArgs e)
    {
        string body = "";
        try
        {
            if (Request.QueryString["id"] != null)
            {
                ContentPlaceHolder1_pagename.InnerHtml = "Edit Profile";
                DataHelper helper = new DataHelper();
                string str = null;
                foreach (ListItem lst in chkgender.Items)
                {
                    if (lst.Selected)
                    {
                        str = lst.Text;
                    }
                }
                //var pwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                //KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                //var Password = EncryptionDecryption.Encrypt(pwd);
                int x = helper.ExecuteNonQuery("update [dbo].[user] set FirstName='" + txtfirstname.Text + "',LastName='" + txtlastname.Text + "',EmailAddress='" + txtemail.Text + "', Gender='" + str + "', MobileNo='" + txtphone.Text + "' where UserId=" + Request.QueryString["Id"].ToString());
                if (x > 0)
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your profile is updated')", true);
                }

            }
            else
            {

                System.Data.DataSet dt = new System.Data.DataSet();
                dt = config.GetEmailAlreadyExist(txtemail.Text);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('EmailAddress already Exist.')", true);
                    }
                }
                else
                {
                    string str = null;
                    foreach (ListItem lst in chkgender.Items)
                    {
                        if (lst.Selected)
                        {
                            str = lst.Text;
                        }
                    }
                    
                    //KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                     var Password = EncryptionDecryption.Encrypt(txtpassword.Text);
                    string contettype = adharfile.PostedFile.ContentType;
                    int x = helper.ExecuteNonQuery("insert into [dbo].[user] (FirstName,MiddleName,LastName,EmailAddress,Gender,MobileNo,User_status,StateID,Taluka,District,Village,PinCode,AadharFileName,PanDocumenFileName,DocumentContentType,CreatedDate,Password,Role) values ('" + txtfirstname.Text + "','" + txtmiddlename.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "','" + str + "','" + txtphone.Text + "','" + 1 + "','" + ddlstate.SelectedItem.Value + "','" + txtdistrict.Text + "','" + txttaluka.Text + "','" + txtvillage.Text + "','" + txtpincode.Text + "','" + adharfile.PostedFile.FileName + "','" + panfilename.PostedFile.FileName + "','" + contettype + "','" + DateTime.Now.ToString() + "','" + Password + "','"+ddlrole.SelectedValue+"')");
                    if (x > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Registration Completed')", true);
                        clear();
                        // Response.Redirect("User_Login.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
       
    }
    public void clear()
    {
        txtdistrict.Text = "";
        txtemail.Text = "";
        txtfirstname.Text = "";
        txtlastname.Text = "";
        txtmiddlename.Text = "";
        txtphone.Text = "";
        txtpincode.Text = "";
        txttaluka.Text = "";
        txtvillage.Text = "";
        ddlstate.SelectedValue = "";
        txtpassword.Text = "";

    }

    
}