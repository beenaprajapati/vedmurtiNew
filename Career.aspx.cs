using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using Configurations;

public partial class Career : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {

        }
    }

    protected void submit2_Click(object sender, EventArgs e)
    {
        string attach1 = null;
        MailMessage mm = new MailMessage();
        mm.Subject = "Job Application";
        string name = mrs.SelectedValue.ToString() + " " + S_name.Text + " " + S_lname.Text;
        string DOB = dateddl.SelectedValue.ToString() + "/" + month.SelectedValue + "/" + year.SelectedValue.ToString();
        string msgText = "<table>" +
            "<tr><td>Name: </td><td>" + name + "</td></tr>" +
            "<tr><td>DOB: </td><td>" + DOB + "</td></tr>" +
            "<tr><td>Email: </td><td>" + S_email.Text + "</td></tr>" +
            "<tr><td>Country: </td><td>" + country.SelectedItem.Text.ToString() + "</td></tr>" +
            "<tr><td>Phone: </td><td>" + S_phone.Text + "</td></tr>" +
            "<tr><td>Mobile: </td><td>" + S_mobile.Text + "</td></tr>" +
            "<tr><td>Present Employer: </td><td>" + employer.Text + "</td></tr>" +
            "<tr><td>Present Location: </td><td>" + present.Text + "</td></tr>" +
            "<tr><td>Preferred Location: </td><td>" + preferred.Text + "</td></tr>" +
            "<tr><td>Highest Education: </td><td>" + highest.Text + "</td></tr>" +
            "<tr><td>Experience: </td><td>" + experience.SelectedValue.ToString() + "</td></tr>" +
            "<tr><td>Comments: </td><td>" + comments.Text + "</td></tr></table>";
        mm.Body = "Hi,<br>" + msgText;
        //mm.Attachments.Add(ExpectedArrival());
        //mm.Attachments.Add();
        mm.IsBodyHtml = true;

        /*strFileName has a attachment file name for 
          attachment process. */
        string strFileName = null;

        /* Bigining of Attachment1 process   & 
           Check the first open file dialog for a attachment */
        if (resume.PostedFile != null)
        {
            /* Get a reference to PostedFile object */
            HttpPostedFile attFile = resume.PostedFile;
            /* Get size of the file */
            int attachFileLength = attFile.ContentLength;
            /* Make sure the size of the file is > 0  */
            if (attachFileLength > 0)
            {
                /* Get the file name */
                strFileName = Path.GetFileName(resume.PostedFile.FileName);
                /* Save the file on the server */
                resume.PostedFile.SaveAs(Server.MapPath(strFileName));
                /* Create the email attachment with the uploaded file */
                Attachment attach = new Attachment(Server.MapPath(strFileName));
                /* Attach the newly created email attachment */
                mm.Attachments.Add(attach);
                /* Store the attach filename so we can delete it later */
                attach1 = strFileName;
            }
        }
        mm.To.Add(S_email.Text);
        SmtpClient smtp = new SmtpClient();
        try
        {
            smtp.Send(mm);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}