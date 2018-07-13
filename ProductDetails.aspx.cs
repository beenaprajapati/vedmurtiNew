using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using System.Data;
public partial class ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
                getallproduct();
            
        }
        getallproduct();
    }
    public void getallproduct()
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                Config config = new Config();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Reset();
                ds = config.get_Product_detail(Request.QueryString["Id"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        h1.Value = ds.Tables[0].Rows[0]["Product_id"].ToString();
                        rptdata.DataSource = ds.Tables[0];
                        rptdata.DataBind();
                        foreach (RepeaterItem i in rptdata.Items)
                        {
                            
                            DropDownList ddl = (DropDownList)i.FindControl("ddllise");
                            HiddenField hdmaxqty = (HiddenField)i.FindControl("hdnmaxqty");
                            HiddenField hdproductid = (HiddenField)i.FindControl("h1");
                            HiddenField txtqty = (HiddenField)i.FindControl("txtqty");
                            Label lblmsg = (Label)i.FindControl("lblmsg");
                            LinkButton btn1 = (LinkButton)i.FindControl("btnaddtocart");
                            int qty = Convert.ToInt32(txtqty.Value);
                            if (hdmaxqty.Value != "")
                            {
                                int maxqty = Convert.ToInt32(hdmaxqty.Value);
                                int multiplication = qty * maxqty;
                                List<string> lst = new List<string>();
                                int da = 0;
                                Dictionary<string, int> source = new Dictionary<string, int>();
                                for (int j = multiplication; j <= 100; j += multiplication)
                                {
                                    da = j;
                                    lst.Add(da.ToString());
                                }
                                ddl.DataSource = lst;
                                ddl.DataBind();
                                ddl.Visible = true;
                            }
                            else
                            {
                                ddl.Visible = false;

                            }
                                
                            HiddenField hdnstock = (HiddenField)i.FindControl("hdnstock");
                            double hd = Convert.ToDouble(hdnstock.Value);
                            if (hd != 0.00)
                            {
                                decimal stock = Convert.ToDecimal(hdnstock.Value);
                                if (Convert.ToInt32(txtqty.Value) <= stock)
                                {
                                    lblmsg.Text = "In Stock";
                                }
                                else
                                {
                                    btn1.Visible = false;
                                    lblmsg.Text = "Out Of Stock";
                                }
                            }
                            else
                            {
                                lblmsg.Text = "Stock is not Available";
                            }

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
    protected void btnaddtocart_Click(object sender, EventArgs e)
    {
        try
        {
            DataHelper helper = new DataHelper();
            if (Session["userID"] != null && Session["username"] != null)
            {

                foreach (RepeaterItem i in rptdata.Items)
                {
                    Config config = new Config();

                    DropDownList ddlqty = (DropDownList)i.FindControl("ddllise");
                    Label txtExample = (Label)i.FindControl("lblprice");
                    HiddenField hdproductid = (HiddenField)i.FindControl("h1");
                    HiddenField txtqty = (HiddenField)i.FindControl("txtqty");
                    HiddenField hdnstock = (HiddenField)i.FindControl("hdnstock");
                    double hd = Convert.ToDouble(hdnstock.Value);
                    if (hd != 0.00)
                    {
                        decimal stock = Convert.ToDecimal(hdnstock.Value);
                        int customerid = Convert.ToInt32(Session["userID"]);
                        System.Data.DataSet ds = new System.Data.DataSet();
                        ds.Reset();
                        ds = config.get_Addtocart_detail(Request.QueryString["Id"].ToString(), Session["userID"].ToString());
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (ddlqty.SelectedValue != "")
                                {
                                    if (Convert.ToInt32(ddlqty.SelectedValue) > 0)
                                    {
                                        if (Convert.ToInt32(ddlqty.SelectedValue) <= stock)
                                        {
                                            int qty = Convert.ToInt32(ddlqty.SelectedValue);
                                            int maxqty = Convert.ToInt32(ds.Tables[0].Rows[0]["MaxQuantity"].ToString());
                                            //decimal stock1 = stock - qty;
                                            decimal quantity1 = qty;
                                            int x = helper.ExecuteNonQuery("update  AddToCart set MaxQuantity='" + quantity1 + "' where CartID='" + ds.Tables[0].Rows[0]["CartID"] + "'");
                                            if (x > 0)
                                            {
                                                lblmessage.Text = "Product Successfully added in Cart";
                                                // Response.Redirect("Productdetails.aspx?Id=" + Request.QueryString["Id"].ToString());



                                            }

                                        }
                                        else
                                        {
                                            
                                                System.Data.DataSet ds1 = new System.Data.DataSet();
                                                ds1.Reset();
                                                ds1 = config.get_Addtocart_detailwithproductuserid(Request.QueryString["Id"].ToString(), Session["userID"].ToString());
                                                if (ds1.Tables.Count > 0)
                                                {
                                                    if (ds1.Tables[0].Rows.Count > 0)
                                                    {
                                                        decimal availablestock = Convert.ToDecimal(ds1.Tables[0].Rows[0]["AvailableStock"].ToString());
                                                        if (ds1.Tables[0].Rows[0]["AvailableStock"].ToString() == "")
                                                        {
                                                            lblmessage.Text = "The Maximum quantity allowed for purchase is ";
                                                        }
                                                        else
                                                        {
                                                            int availablestock1 = Convert.ToInt32(availablestock);
                                                            lblmessage.Visible = true;
                                                            lblmessage.Text = "The Maximum quantity allowed for purchase is " + availablestock1;

                                                        }
                                                    }
                                                }
                                           

                                        }


                                    }
                                    else
                                    {
                                        lblmessage.Text = "Enter Quantity greater than 0";

                                    }
                                }


                                else
                                {

                                    lblmessage.Text = "Enter Quantity greater than 0";
                                }
                            }


                            else
                            {
                                if (ddlqty.SelectedValue != "")
                                {
                                    if ((Convert.ToInt32(ddlqty.SelectedValue) > 0))
                                    {
                                        if (Convert.ToInt32(ddlqty.SelectedValue) <= stock)
                                        {
                                            int qty = Convert.ToInt32(txtqty.Value);
                                            // decimal maxqty = Convert.ToDecimal(ds.Tables[0].Rows[0]["MaxQuantity"].ToString());
                                            //decimal stock1 = stock - qty;
                                            int x = helper.ExecuteNonQuery("insert into AddToCart (ProductID,CustomerID,Price,MinQuantity,MaxQuantity,Cart_Status,OrderID) values ('" + hdproductid.Value + "','" + customerid + "','" + txtExample.Text + "','" + txtqty.Value + "','" + ddlqty.SelectedValue + "','" + 0 + "','" + 0 + "')");
                                            if (x > 0)
                                            {
                                                lblmessage.Text = "Product Successfully added in Cart";
                                            }
                                            //int z = helper.ExecuteNonQuery("update products set AvailableStock='" + stock1 + "' where product_ID='" + hdproductid.Value + "'");
                                            //if (z > 0)
                                            //{

                                            //}
                                        }
                                        else
                                        {



                                          
                                                int availablestock1 = Convert.ToInt32(stock);
                                                lblmessage.Visible = true;
                                                lblmessage.Text = "The Maximum quantity allowed for purchase is " + availablestock1;
                                            

                                        }
                                    }
                                    else
                                    {
                                        lblmessage.Text = "Enter Quantity greater than 0";

                                    }
                                }
                                else
                                {
                                    lblmessage.Text = "Enter Quantity greater than 0";

                                }
                            }
                        }
                        else
                        {


                        }
                    }
                    else
                    {
                        lblmessage.Text = "No stock available";

                    }

                }
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "setTimeout(function(){window.location.href='Productdetails.aspx?Id='" + Request.QueryString["Id"].ToString() + ";},1000);", true);
                //Response.Redirect("ProductDetails.aspx?Id=" + Request.QueryString["Id"].ToString());
                var master = Master as Main_Master;
                if (master != null)
                {
                    master.Fillcart();
                    master.fillCat();
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
    //protected void txtqty_TextChanged(object sender, EventArgs e)
    //{
    //    foreach (RepeaterItem i in rptdata.Items)
    //    {
    //        TextBox txtqty = (TextBox)i.FindControl("txtqty");
    //        HiddenField hdnstock = (HiddenField)i.FindControl("hdnstock");
    //        decimal stock = Convert.ToDecimal(hdnstock.Value);
    //        if (txtqty.Text != "")
    //        {
    //            if ((Convert.ToDecimal(txtqty.Text) <= 0))
    //            {
    //                string str = string.Empty;
    //                str = "<script language='javascript'>";
    //                str = str + " var res=alert('Please Enter Valid Quantity.');";
    //                str = str + "if(res==true){ window.close();";
    //                str = str + "}";
    //                str = str + "else{ window.close();";
    //                str = str + "}";
    //                str = str + "</script>";
    //                if (ClientScript.IsClientScriptBlockRegistered("messagebox") == false)
    //                {
    //                    ClientScript.RegisterStartupScript(GetType(), "messagebox", str);
    //                }
    //            }
    //            else if((Convert.ToDecimal(txtqty.Text)>stock))
    //            {
    //                string str = string.Empty;
    //                str = "<script language='javascript'>";
    //                str = str + " var res=alert('Minimum value.');";
    //                str = str + "if(res==true){ window.close();";
    //                str = str + "}";
    //                str = str + "else{ window.close();";
    //                str = str + "}";
    //                str = str + "</script>";
    //                if (ClientScript.IsClientScriptBlockRegistered("messagebox") == false)
    //                {
    //                    ClientScript.RegisterStartupScript(GetType(), "messagebox", str);
    //                }
    //            }
    //            else
    //            {

    //            }
    //        }
    //        else
    //        {
    //            string str = string.Empty;
    //            str = "<script language='javascript'>";
    //            str = str + " var res=alert('Please Enter Valid Quantity.');";
    //            str = str + "if(res==true){ window.close();";
    //            str = str + "}";
    //            str = str + "else{ window.close();";
    //            str = str + "}";
    //            str = str + "</script>";
    //            if (ClientScript.IsClientScriptBlockRegistered("messagebox") == false)
    //            {
    //                ClientScript.RegisterStartupScript(GetType(), "messagebox", str);
    //            }

    //        }


    //    }
    //    //if (txtqty.Text != null)
    //    //{
    //    //}
    //}

    protected void rptdata_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Show or hid div here
            System.Web.UI.HtmlControls.HtmlContainerControl Stockdetail = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("stock");

            System.Web.UI.HtmlControls.HtmlContainerControl Cartdetail = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("cart");
            System.Web.UI.HtmlControls.HtmlContainerControl PriceDetail = (System.Web.UI.HtmlControls.HtmlContainerControl)e.Item.FindControl("price");

            if (Session["userID"] != null)
            {
                Stockdetail.Visible = true;
                Cartdetail.Visible = true;
                PriceDetail.Visible = true;
            }
            else
            {
                Stockdetail.Visible = false;
                Cartdetail.Visible = false;
                PriceDetail.Visible = false;
            }

        }
    }
}