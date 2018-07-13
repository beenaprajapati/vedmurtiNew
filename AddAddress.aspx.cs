using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using System.Data;
using System.IO;


public partial class AddAddress : System.Web.UI.Page
{
    Config config = new Config();
    DataHelper helper = new DataHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["AddressId"] != null)
            {
                GetAddressView(Convert.ToInt32(Request.QueryString["AddressId"].ToString()));
            }
            else
            {
                ContentPlaceHolder1_pagename.InnerText = "Add Address";
                GetAllState();
    
            }
        }

    }
    public enum MessageType { Success, Error, Info, Warning };
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    //Get all Address fetches id
    public void GetAddressView(int addressid)
    {
        try
       {
           ContentPlaceHolder1_pagename.InnerText = "Edit Address";
            DataSet Editset = new DataSet();
            Editset.Reset();
            string zipcode;
            Editset = config.EditAddress(addressid.ToString());
            if (Editset.Tables.Count > 0)
            {
                if (Editset.Tables[0].Rows.Count > 0)
                {
                    txtfirstname.Text = Editset.Tables[0].Rows[0]["FirstName"].ToString();
                    txtfirstname.Focus();
                    txtlastname.Text = Editset.Tables[0].Rows[0]["LastName"].ToString();
                    txtcity.Text = Editset.Tables[0].Rows[0]["City"].ToString();
                    txtemail.Text = Editset.Tables[0].Rows[0]["EmailAddress"].ToString();
                    txtphone.Text = Editset.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    zipcode = Editset.Tables[0].Rows[0]["ZipCode"].ToString();
                    txtzipcode.Text = zipcode.Trim();
                    txtaddress1.Text = Editset.Tables[0].Rows[0]["Address1"].ToString();
                    txtaddress2.Text = Editset.Tables[0].Rows[0]["Address2"].ToString();

                   
                    GetAllState();
                    ddlstate.SelectedValue = Editset.Tables[0].Rows[0]["StateID"].ToString();


                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Get all Country
    
    //Save and update data 
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["AddressId"] != null)
            {
                int Addressid = Convert.ToInt32(Request.QueryString["AddressId"]);
                int y = helper.ExecuteNonQuery("update address set FirstName='" + txtfirstname.Text + "',LastName='" + txtlastname.Text + "',EmailAddress='" + txtemail.Text + "',StateID='" + ddlstate.SelectedItem.Value + "',City='" + txtcity.Text + "',Address1='" + txtaddress1.Text + "',Address2='" + txtaddress2.Text + "',Zipcode='" + txtzipcode.Text + "',PhoneNumber='" + txtphone.Text + "',CustomerID='" + Session["userID"].ToString() + "' where AddressID='" + Addressid + "'");
                if (y > 0)
                {
                    //ShowMessage("Address save successfully..", MessageType.Success);
                    Response.Redirect("ViewAddress.aspx");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtfirstname.Text))
                {
                    int query = helper.ExecuteNonQuery("insert into Address(FirstName,LastName,EmailAddress,StateID,City,Address1,Address2,ZipCode,PhoneNumber,CustomerID,CreatedDate) values('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtemail.Text + "','" + ddlstate.SelectedItem.Value + "','" + txtcity.Text + "','" + txtaddress1.Text + "','" + txtaddress2.Text + "','" + txtzipcode.Text + "','" + txtphone.Text + "','" + Session["userID"].ToString() + "','" + DateTime.Now + "')");
                    if (query > 0)
                    {
                        //ShowMessage("Address save successfully..", MessageType.Success);
                        Response.Redirect("ViewAddress.aspx");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Cancel Button
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAddress.aspx");
    }

    //Get All State
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
    //County Select then bind State
  
}