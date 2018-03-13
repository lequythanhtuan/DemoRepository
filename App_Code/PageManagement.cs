using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PageManagement
/// </summary>
public class PageManagement : System.Web.UI.Page
{
    public User CheckUser
    {
        get
        {
            if (Session["user"] == null)
                return null;
            return Session["user"] as User;
        }
        set
        {
            Session["user"] = value;
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (this.CheckUser == null)
        {
            Response.Redirect("LoginForm.aspx");
        }
    }
}