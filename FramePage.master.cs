using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FramePage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PL.LoadCat2RPT(rptCategory);
        if(UserRole() == 1)
        {
            dvCat.Visible = false;
            lbtnIdeas.Visible = false;
            lbtnDownload.Visible = false;
            lbtnCategoryMenu.Visible = false;
        }
        if (UserRole() == 2 || UserRole() == 3 || UserRole() == 4)
        {
            lbtnUser.Visible = false;
            lbtnYear.Visible = false;
        }
        if(UserRole() == 4)
        {
            lbtnCategoryMenu.Visible = false;
            lbtnDownload.Visible = false;
        }
        if(UserRole() == 2)
        {
            lbtnCategoryMenu.Visible = false;
        }
    }

    public int UserRole()
    {
        User user = Session["user"] as User;
        return user.RoleID;
    }

    protected void lbtnHome_Click(object sender, EventArgs e)
    {
        if (UserRole() == 1)
            Response.Redirect("FindUser.aspx");
        else
            Response.Redirect("Home.aspx");
    }

    protected void lbtnUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("FindUser.aspx");
    }

    protected void lbtnDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("DownloadManagement.aspx");
    }

    protected void lbtnIdeas_Click(object sender, EventArgs e)
    {
        Response.Redirect("IdeaManagement.aspx");
    }

    protected void lbtnYear_Click(object sender, EventArgs e)
    {
        Response.Redirect("YearManagement.aspx");
    }

    protected void lbtnCategory_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = sender as LinkButton;
        int id = int.Parse(linkButton.CommandArgument);
        Response.Redirect("Home.aspx?Category=" + id);
    }

    protected void lbtnCategoryMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("CategoriesManagement.aspx");
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Remove("user");
        Response.Redirect("LoginForm.aspx");
    }

    protected void lbtnChangePass_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }

    protected void lbtnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report.aspx");
    }
}
