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
public partial class EditProfile : System.Web.UI.Page
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
                
            }
            else
            {
                Response.Redirect("User_Login.aspx");
            }
            if (Request.QueryString["id"] != null)
            {
                fetch(Convert.ToInt32(Request.QueryString["id"].ToString()));
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
    private void fetch(int id)
    {
        try
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            ds = config.GetUserDetail(id.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    txtfirstname.Text = ds.Tables[0].Rows[0]["firstName"].ToString();
                    txtlastname.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtemail.Text = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
                    txtphone.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtdistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txttaluka.Text = ds.Tables[0].Rows[0]["Taluka"].ToString();
                    txtvillage.Text = ds.Tables[0].Rows[0]["Village"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    txtmiddlename.Text = ds.Tables[0].Rows[0]["MiddleName"].ToString();
                    txtreference.Text = ds.Tables[0].Rows[0]["ReferenceBy"].ToString();
                    if (ds.Tables[0].Rows[0]["StateID"].ToString() != "")
                    {
                        ddlstate.SelectedValue = ds.Tables[0].Rows[0]["StateID"].ToString();
                    }
                    else
                    {
                     
                    }
                    string gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                    lbladhar.Text = ds.Tables[0].Rows[0]["AadharFileName"].ToString();
                    lblpan.Text = ds.Tables[0].Rows[0]["PanDocumenFileName"].ToString();
                    hd1.Value = ds.Tables[0].Rows[0]["PanDocumenFileName"].ToString();
                    hdpan.Value = ds.Tables[0].Rows[0]["AadharFileName"].ToString();

                    for (int i = 0; i < chkgender.Items.Count; i++)
                    {
                        if (chkgender.Items[i].Text == gender)
                        {
                            chkgender.Items[i].Selected = true;
                            break;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
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
                
                
                //KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                //var Password = EncryptionDecryption.Encrypt(txtpassword.Text);
                int x = helper.ExecuteNonQuery("update [dbo].[user] set FirstName='" + txtfirstname.Text + "',MiddleName='" + txtmiddlename.Text + "',LastName='" + txtlastname.Text + "',EmailAddress='" + txtemail.Text + "', Gender='" + str + "', MobileNo='" + txtphone.Text + "',StateID='" + ddlstate.SelectedItem.Value + "',District='" + txtdistrict.Text + "',Taluka='" + txttaluka.Text + "',Village='" + txtvillage.Text + "',PinCode='" + txtpincode.Text + "',AadharFileName='" + hdpan.Value + "',PanDocumenFileName='" + hd1.Value + "',ReferenceBy='"+txtreference.Text+"' where UserId=" + Request.QueryString["Id"].ToString());
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
                    var pwd = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
                    //KeyValuePair<string, string> KeyValuePairPWD = enc.GetSaltKeyAndData(pwd);
                    var Password = EncryptionDecryption.Encrypt(pwd);
                    string contettype = adharfile.PostedFile.ContentType;
                    int x = helper.ExecuteNonQuery("insert into [dbo].[user] (FirstName,LastName,EmailAddress,Gender,MobileNo,User_status,Password,AadharFileName,PanDocumenFileName,DocumentContentType) values ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "','" + str + "','" + txtphone.Text + "','" + 1 + "','" + Password + "','" + adharfile.PostedFile.FileName + "','" + panfilename.PostedFile.FileName + "','" + contettype + "')");
                    if (x > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Registration Completed')", true);
                        Response.Redirect("User_Login.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}