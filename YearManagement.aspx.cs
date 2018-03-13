using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YearManagement : ClosureDateService
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime start = DateTime.Parse(txtStart.Text);
        DateTime end = DateTime.Parse(txtEnd.Text);
        DateTime closuredate = DateTime.Parse(txtClosureDate.Text);
        DateTime finaldate = DateTime.Parse(txtFinalDate.Text);
        bool check = AddDate(start,end,closuredate,finaldate,CheckUser.ID_Iden);
        if(check)
        {
            Response.Write("<script language='javascript'>" + "alert('Successfully Added" + "</script>");
            Response.Redirect("FindUser.aspx");
        }
    }
}