using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CategoriesManagement : CategoriesService
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        PL.LoadCat2Grv(grvCategory);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var user = Session["user"] as User;
        Category category = new Category()
        {
            CreateBy = user.ID_Iden,
            CreateDate = DateTime.Now,
            Name = txtName.Text,
        };
        var ok = AddCategories(category);
        if(ok)
            Response.Write("<script language='javascript'>" + "alert('Successfully Added')" + "</script>");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        int id = int.Parse(button.CommandArgument);
        Deletecategories(id);
    }
}