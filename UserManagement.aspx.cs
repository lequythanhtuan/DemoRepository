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
            string roleId = null;
            string userID = null;
            if (Request.QueryString["getRoleID"] != null)
                roleId = Request.QueryString["getRoleID"].ToString();
            else
                userID = Request.QueryString["getIdUser"].ToString();

            if (roleId != null)
            {
                if (int.Parse(roleId) == 1 || int.Parse(roleId) == 3)
                    dvDep.Visible = false;
            }
            else
            {
                if (userID != null)
                {
                    if (GetInformation(int.Parse(userID)).RoleID == 1 || GetInformation(int.Parse(userID)).RoleID == 3)
                        dvDep.Visible = false;
                    LoadInforToText(userID);
                }
            }
        }
    }

    public User GetInformation(int uId)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var user = db.Users.FirstOrDefault(x => x.ID_Iden == uId);
            if (user != null)
                return user;
            else return null;
        }
    }

    public void LoadInforToText(string userID)
    {
        dvPassword.Visible = false;
        txtUserID.Enabled = false;
        var user = GetInformation(int.Parse(userID));
        txtUserID.Text = user.IDUsers;
        txtPassword.Text = user.Password;
        txtFirst.Text = user.FirstName;
        txtLast.Text = user.LastName;
        txtBirth.Text = ((DateTime)(user.Birthdate)).ToString("yyyy-MM-dd");
        txtPhone.Text = user.Phone;
        txtAddress.Text = user.Address;
        txtEmail.Text = user.Email;
        btlGender.SelectedValue = user.Gender.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string roleId = null;
        string userID = null;
        User oUser = null;
        bool submit;
        if (Request.QueryString["getRoleID"] != null)
        {
            roleId = Request.QueryString["getRoleID"].ToString();
            oUser = new User();
            oUser.IDUsers = txtUserID.Text;
            oUser.FirstName = txtFirst.Text;
            oUser.LastName = txtLast.Text;
            oUser.Address = txtAddress.Text;
            oUser.Birthdate = DateTime.Parse(txtBirth.Text);
            oUser.Password = txtPassword.Text;
            oUser.Gender = bool.Parse(btlGender.SelectedValue);
            oUser.DepID = int.Parse(roleId) == 1 || int.Parse(roleId) == 3 ? 1 : int.Parse(ddlDep.SelectedValue);
            oUser.RoleID = int.Parse(roleId);
            oUser.Phone = txtPhone.Text;
            oUser.Email = txtEmail.Text;
            submit = AddUser(oUser);
            Response.Redirect("FindUser.aspx");
        }
        else
        {
            using (EWSDDataContext db = new EWSDDataContext())
            {
                userID = Request.QueryString["getIdUser"].ToString();
              //  oUser = GetInformation(int.Parse(userID));
                oUser = db.Users.FirstOrDefault(x => x.ID_Iden == int.Parse(userID));
                if(oUser != null)
                {
                    oUser.FirstName = txtFirst.Text;
                    oUser.LastName = txtLast.Text;
                    oUser.Address = txtAddress.Text;
                    oUser.Birthdate = DateTime.Parse(txtBirth.Text);
                    oUser.Gender = bool.Parse(btlGender.SelectedValue);
                    oUser.DepID = roleId == null || int.Parse(roleId) == 1 || int.Parse(roleId) == 3 ? 1 : int.Parse(ddlDep.SelectedValue);
                    oUser.Phone = txtPhone.Text;
                    oUser.Email = txtEmail.Text;
                    db.SubmitChanges();
                    Response.Redirect("FindUser.aspx");
                }
            }
        }
    }
}