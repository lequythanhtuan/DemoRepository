using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : UserService
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var check = ChangePassword(CheckUser.ID_Iden, txtNew.Text);
        if (check) Response.Redirect("Home.aspx");
    }
}