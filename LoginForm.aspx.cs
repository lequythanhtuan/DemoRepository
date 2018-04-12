using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        notification.Visible = false;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Session.RemoveAll();
        using (EWSDDataContext db = new EWSDDataContext())
        {
            User _user = db.Users.FirstOrDefault(x => x.IDUsers.Equals(txtUser.Text) && x.Password.Equals(txtPassword.Text));
            if (_user == null)
            {
                notification.Visible = true;
                return;
            }
            Session["user"] = _user;
            if (_user.RoleID == 1)
                Response.Redirect("FindUser.aspx");
            else
                Response.Redirect("Home.aspx");
        }
    }
}