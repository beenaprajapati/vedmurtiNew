using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Configurations;
using DataLayer;
using System.Net;
using System.Net.Mail;
using System.Data;
public partial class ViewCart : System.Web.UI.Page
{
    DataHelper helper = new DataHelper();
    Config conf = new Config();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fillcart1();
        }
        //Fillcart1();
    }
    protected void Fillcart1()
    {
        try
        {
            if (Session["userID"] != null && Session["username"] != null)
            {
                decimal total = 0;
                Config config = new Config();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Reset();
                ds = config.get_Addtocart_detailwithuserid(Session["userID"].ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        grdviewcart.DataSource = ds.Tables[0];
                        grdviewcart.DataBind();
                        for (int i = 0; i < grdviewcart.Rows.Count; i++)
                        {
                            DropDownList ddl = (DropDownList)grdviewcart.Rows[i].FindControl("ddllise");
                            Label lblPrice = (Label)grdviewcart.Rows[i].FindControl("lblPrice");
                            Label lblTotal = (Label)grdviewcart.Rows[i].FindControl("lbltotal");
                            // TextBox lblqty = (TextBox)grdviewcart.Rows[i].FindControl("txtqty");
                            HiddenField hdmaxqty = (HiddenField)grdviewcart.Rows[i].FindControl("hdnmaxqty");
                            HiddenField hdqty = (HiddenField)grdviewcart.Rows[i].FindControl("hdnqty");
                            HiddenField txtqty = (HiddenField)grdviewcart.Rows[i].FindControl("txtqty");
                            decimal qty = Convert.ToDecimal(txtqty.Value);
                            txtqty.Value = qty.ToString("0.##");
                            if (hdmaxqty.Value != "")
                            {
                                decimal maxqty = Convert.ToDecimal(hdqty.Value);
                                decimal multiplication = qty * maxqty;
                                List<string> lst = new List<string>();
                                decimal da = 0;
                                Dictionary<string, decimal> source = new Dictionary<string, decimal>();
                                for (decimal j = multiplication; j <= 100; j += multiplication)
                                {
                                    da = j;
                                    lst.Add(da.ToString("0.##"));
                                }
                                ddl.DataSource = lst;
                                ddl.DataBind();
                                string qt = Convert.ToDecimal(hdmaxqty.Value).ToString("0.##");
                                ddl.SelectedValue = qt;
                                ddl.Visible = true;
                            }
                            else
                            {
                                ddl.Visible = false;

                            }
                            decimal subtotal1 = Convert.ToDecimal(lblPrice.Text) * Convert.ToDecimal(hdmaxqty.Value);
                            total += subtotal1;
                            lblTotal.Text = subtotal1.ToString("0.##");
                            lblsubtotal.Text = total.ToString("0.00");
                            lbltotal.Text = total.ToString("0.00");
                        }


                    }
                    else
                    {
                        btnUpdatecart.Visible = false;
                        btncheckout.Visible = false;
                        totals.Visible = false;
                        grdviewcart.DataSource = null;
                        grdviewcart.DataBind();
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
    protected void grdviewcart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdviewcart.PageIndex = e.NewPageIndex;
        Fillcart1();
    }


    protected void btnUpdatecart_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < grdviewcart.Rows.Count; i++)
            {

                DropDownList txtQty = (DropDownList)grdviewcart.Rows[i].FindControl("ddllise");
                Label lblmsg = (Label)grdviewcart.Rows[i].FindControl("lblmessage");
                HiddenField productid = (HiddenField)grdviewcart.Rows[i].FindControl("hdnid");
                int ProductID = Int32.Parse(productid.Value);
                if (txtQty.SelectedValue != "")
                {
                    int Quantity = int.Parse(txtQty.SelectedValue);
                    string productID = ProductID.ToString();
                    DataSet Editset = new DataSet();
                    Editset.Reset();
                    Editset = conf.get_Addtocart_detailwithproductuserid(productID, Session["userID"].ToString());
                    if (Editset.Tables.Count > 0)
                    {
                        if (Editset.Tables[0].Rows.Count > 0)
                        {
                            decimal stock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                            if (Quantity > 0)
                            {

                                if (Convert.ToDecimal(Quantity) <= stock)
                                {
                                    decimal qty = Convert.ToDecimal(Quantity);
                                    decimal maxqty = Convert.ToDecimal(Editset.Tables[0].Rows[0]["MaxQuantity"].ToString());

                                    decimal quantity1 = qty;
                                    int x = helper.ExecuteNonQuery("update  AddToCart set MaxQuantity='" + quantity1 + "' where CartID='" + Editset.Tables[0].Rows[0]["CartID"] + "'");
                                    if (x > 0)
                                    {

                                        // Fillcart1();
                                    }
                                }
                                else
                                {

                                    decimal availablestock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                                    if (Editset.Tables[0].Rows[0]["AvailableStock"].ToString() == "")
                                    {
                                        lblmsg.Text = "The Maximum quantity allowed for purchase is ";
                                    }
                                    else
                                    {

                                        Fillcart1();

                                    }

                                }


                            }
                            else
                            {
                                int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                                if (removeproduct > 0)
                                {

                                    if (Quantity > 0)
                                    {

                                    }
                                    else
                                    {

                                    }
                                }

                                else
                                {
                                    string message = "Enter Quantity greater than 0";
                                    string url = "ViewCart.aspx";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "');";
                                    script += "window.location = '";
                                    script += url;
                                    script += "'; }";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                                }
                            }
                        }
                    }
                }
                else
                {
                    int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                    if (removeproduct > 0)
                    {

                    }

                    else
                    {
                        string message = "Enter Quantity greater than 0";
                        string url = "ViewCart.aspx";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                    }
                }
            }
            Fillcart1();
            var master = Master as Main_Master;
            if (master != null)
            {
                master.Fillcart();
                master.fillCat();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btncontinue_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < grdviewcart.Rows.Count; i++)
        {

            HiddenField tb = (HiddenField)grdviewcart.Rows[i].Cells[0].FindControl("hdncatid"); //Gets the data value in TextBox that resides in Template Fields in the grid; // Just change the index of cells based on your requirement
            if (tb.Value == null)
            {
                return;
            }
            else
            {

                Response.Redirect("Product.aspx?id=" + tb.Value);
            }


        }
        Response.Redirect("Product.aspx?id=1");
    }
    protected void btncheckout_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < grdviewcart.Rows.Count; i++)
            {

                DropDownList txtQty = (DropDownList)grdviewcart.Rows[i].FindControl("ddllise");
                Label lblmsg = (Label)grdviewcart.Rows[i].FindControl("lblmessage");
                HiddenField productid = (HiddenField)grdviewcart.Rows[i].FindControl("hdnid");
                int ProductID = Int32.Parse(productid.Value);
                if (txtQty.SelectedValue != "")
                {
                    int Quantity = int.Parse(txtQty.SelectedValue);
                    string productID = ProductID.ToString();
                    DataSet Editset = new DataSet();
                    Editset.Reset();
                    Editset = conf.get_Addtocart_detailwithproductuserid(productID, Session["userID"].ToString());
                    if (Editset.Tables.Count > 0)
                    {
                        if (Editset.Tables[0].Rows.Count > 0)
                        {
                            decimal stock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                            if (Quantity > 0)
                            {

                                if (Convert.ToDecimal(Quantity) <= stock)
                                {
                                    decimal qty = Convert.ToDecimal(Quantity);
                                    decimal maxqty = Convert.ToDecimal(Editset.Tables[0].Rows[0]["MaxQuantity"].ToString());

                                    decimal quantity1 = qty;
                                    int x = helper.ExecuteNonQuery("update  AddToCart set MaxQuantity='" + quantity1 + "' where CartID='" + Editset.Tables[0].Rows[0]["CartID"] + "'");
                                    if (x > 0)
                                    {

                                        // Fillcart1();
                                    }
                                }
                                else
                                {

                                    decimal availablestock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                                    if (Editset.Tables[0].Rows[0]["AvailableStock"].ToString() == "")
                                    {
                                        lblmsg.Text = "The Maximum quantity allowed for purchase is ";
                                    }
                                    else
                                    {
                                        string ProductName = Editset.Tables[0].Rows[0]["product_name"].ToString();
                                        int totalstock = Convert.ToInt32(availablestock);
                                        string script = string.Format("alert('{0}');", "Minimum order amount for " + ProductName + " is " + totalstock + "");
                                        if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                                        {
                                            Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
                                        }
                                        return;

                                    }

                                }


                            }
                            else
                            {
                                int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                                if (removeproduct > 0)
                                {

                                    if (Quantity > 0)
                                    {

                                    }
                                    else
                                    {

                                    }
                                }

                                else
                                {
                                    string message = "Enter Quantity greater than 0";
                                    string url = "ViewCart.aspx";
                                    string script = "window.onload = function(){ alert('";
                                    script += message;
                                    script += "');";
                                    script += "window.location = '";
                                    script += url;
                                    script += "'; }";
                                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                                }
                            }
                        }
                    }
                }
                else
                {
                    int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                    if (removeproduct > 0)
                    {

                    }

                    else
                    {
                        string message = "Enter Quantity greater than 0";
                        string url = "ViewCart.aspx";
                        string script = "window.onload = function(){ alert('";
                        script += message;
                        script += "');";
                        script += "window.location = '";
                        script += url;
                        script += "'; }";
                        ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                    }
                }
            }
            Fillcart1();
            var master = Master as Main_Master;
            if (master != null)
            {
                master.Fillcart();
                master.fillCat();
            }
            Response.Redirect("Order.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkButton = sender as LinkButton;
            GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
            HiddenField id = (HiddenField)row.FindControl("hdnid");
            DropDownList txtQty = (DropDownList)row.FindControl("ddllise");
            int quantity = Convert.ToInt32(txtQty.SelectedValue);
            DataSet Editset = new DataSet();
            Editset = conf.get_Addtocart_detailwithproductuserid(id.Value, Session["userID"].ToString());
            if (Editset.Tables.Count > 0)
            {
                if (Editset.Tables[0].Rows.Count > 0)
                {
                    decimal stock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                    int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + id.Value + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                    if (removeproduct > 0)
                    {
                        if (quantity != null)
                        {
                            if (quantity > 0)
                            {

                            }
                            else
                            {
                                string message = "Enter Quantity greater than 0";
                                string url = "ViewCart.aspx";
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
                            string message = "Enter Quantity greater than 0";
                            string url = "ViewCart.aspx";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                        }
                    }
                }
                Fillcart1();
                var master = Master as Main_Master;
                if (master != null)
                {
                    master.Fillcart();
                    master.fillCat();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddllise_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlcouse = (DropDownList)sender;
        GridViewRow Grow = (GridViewRow)ddlcouse.NamingContainer;
        HiddenField productid = ((HiddenField)Grow.FindControl("hdnid"));
        Label lblmsg = ((Label)Grow.FindControl("lblmessage"));

        int ProductID = Int32.Parse(productid.Value);
        if (ddlcouse.SelectedValue != "")
        {
            int Quantity = int.Parse(ddlcouse.SelectedValue);
            string productID = ProductID.ToString();
            DataSet Editset = new DataSet();
            Editset.Reset();
            Editset = conf.get_Addtocart_detailwithproductuserid(productID, Session["userID"].ToString());
            if (Editset.Tables.Count > 0)
            {
                if (Editset.Tables[0].Rows.Count > 0)
                {
                    decimal stock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                    if (Quantity > 0)
                    {

                        if (Convert.ToDecimal(Quantity) <= stock)
                        {
                            decimal qty = Convert.ToDecimal(Quantity);
                            decimal maxqty = Convert.ToDecimal(Editset.Tables[0].Rows[0]["MaxQuantity"].ToString());

                            decimal quantity1 = qty;
                            int x = helper.ExecuteNonQuery("update  AddToCart set MaxQuantity='" + quantity1 + "' where CartID='" + Editset.Tables[0].Rows[0]["CartID"] + "'");
                            if (x > 0)
                            {

                                // Fillcart1();
                            }
                        }
                        else
                        {
                            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Maximum quantity allowed purchase is out of box')", true);
                            string ProductName = Editset.Tables[0].Rows[0]["product_name"].ToString();
                            decimal availablestock = Convert.ToDecimal(Editset.Tables[0].Rows[0]["AvailableStock"].ToString());
                            if (Editset.Tables[0].Rows[0]["AvailableStock"].ToString() == "")
                            {
                                lblmsg.Text = "Minimum order amount for " + ProductName + " is " + availablestock + "";
                            }
                            else
                            {
                                int totalstock = Convert.ToInt32(availablestock);
                                string script = string.Format("alert('{0}');", "Minimum order amount for " + ProductName + " is " + totalstock + "");
                                if (Page != null && !Page.ClientScript.IsClientScriptBlockRegistered("alert"))
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", script, true /* addScriptTags */);
                                }
                                return;
                            }

                        }


                    }
                    else
                    {
                        int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
                        if (removeproduct > 0)
                        {

                            if (Quantity > 0)
                            {

                            }
                            else
                            {

                            }
                        }

                        else
                        {
                            string message = "Enter Quantity greater than 0";
                            string url = "ViewCart.aspx";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "');";
                            script += "window.location = '";
                            script += url;
                            script += "'; }";
                            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

                        }
                    }
                }
            }
        }
        else
        {
            int removeproduct = helper.ExecuteNonQuery("delete from  AddToCart  where productID='" + ProductID + "' and CustomerID='" + Session["userID"].ToString() + "' AND cart_status=0 and orderid=0");
            if (removeproduct > 0)
            {

            }

            else
            {
                string message = "Enter Quantity greater than 0";
                string url = "ViewCart.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

            }
        }
        Fillcart1();
        var master = Master as Main_Master;
        if (master != null)
        {
            master.Fillcart();
            master.fillCat();
        }
    }

}