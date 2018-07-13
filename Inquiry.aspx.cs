using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Configurations;

public partial class Inquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {

        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        try
        {
            string message = "Dear " + txtname.Text + ",<br> Thank you for your Inquiry. We will get in touch with you shortly.<br> ";
            string content = "Name: " + txtname.Text + "<br> Contact number:" + contact.Text + "<br> Email: " + emailname.Text + "<br> Message: " + msg.Text;

            if (SendMailMessage(emailname.Text, "nainesh_patel@vedmurti.com", "", "Thanks for you inquiry", message + content + "<br>"))
            {
                txtname.Text = contact.Text = emailname.Text = msg.Text = string.Empty;
                string str = string.Empty;
                str = "<script language='javascript'>";
                str = str + " var res=alert('Inquiry submitted');";
                str = str + "if(res==true){ window.close();";
                str = str + "}";
                str = str + "else{ window.close();";
                str = str + "}";
                str = str + "</script>";
                if (ClientScript.IsClientScriptBlockRegistered("messagebox") == false)
                {
                    ClientScript.RegisterStartupScript(GetType(), "messagebox", str);
                }
            }
            else
            {
                txtname.Text = contact.Text = emailname.Text = msg.Text = string.Empty;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public static bool SendMailMessage(string to, string bcc, string cc, string subject, string body)
    {
        try
        {
            bool temp = true;

            MailMessage Msg = new MailMessage();
            // Sender e-mail address.

            // Recipient e-mail address.
            Msg.Bcc.Add(bcc);
            Msg.To.Add(to);
            Msg.Subject = subject;
            Msg.Body = body;
            Msg.IsBodyHtml = true;
            // your remote SMTP server IP.
            SmtpClient smtp = new SmtpClient();
            
            try
            {
                smtp.Send(Msg);
            }
            catch (Exception exp)
            {
                temp = false;
                //throw exp;
            }
            return temp;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}