using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement : UserService
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PL.LoadDep2DDL(ddlDep);
            int roleId = int.Parse(Request.QueryString["getRoleID"]);
            if (roleId == 1 || roleId == 3)
            dvDep.Visible = false;
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int roleId = int.Parse(Request.QueryString["getRoleID"]);
        
        bool gen;
        if (gen1.Checked)
            gen = gen1.Checked;
        else
        {
            gen = gen2.Checked;
        }
        User user = new User();
        user.IDUsers = txtUserID.Text;
        user.FirstName = txtFirst.Text;
        user.LastName = txtLast.Text;
        user.Address = txtAddress.Text;
        user.Birthdate = DateTime.Parse(txtBirth.Text);
        user.Password = txtPassword.Text;
        user.Gender = gen;
        user.DepID = roleId == 1 || roleId == 3 ? (int?) null : int.Parse(ddlDep.SelectedValue);
        user.RoleID = roleId;
        user.Phone = txtPhone.Text;
        user.Email = txtEmail.Text;
        bool ok = AddUser(user);
        if (ok)
        {
            Response.Write("<script language='javascript'>" + "alert('Successfully Added" + "</script>");
            Response.Redirect("FindUser.aspx");
        }

    }
}