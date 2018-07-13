<%@ WebHandler Language="C#" Class="FileuploadHandler" %>

using System;
using System.Web;

public class FileuploadHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    
    {
        if (context.Request.Files.Count > 0)
        {
            HttpFileCollection files = context.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string fname = context.Server.MapPath("~/Documents/" + file.FileName);
                file.SaveAs(fname);
                string strFileName = fname;
                
                string msg = "{";
                msg += string.Format("error:'{0}',\n", string.Empty);
                msg += string.Format("msg:'{0}',\n", strFileName);
                msg += "}";
                context.Response.Write(msg);
            }
        }
      
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}