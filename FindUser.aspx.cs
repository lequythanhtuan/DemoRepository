﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindUser : PageManagement
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            PL.LoadRole2DDL(ddlRole);
            loadToGrv();
        }
    }

    public void loadToGrv()
    {
        try
        {
            using (EWSDDataContext db = new EWSDDataContext())
            {
                var user = db.Users.Join(db.Departments, u => u.DepID, d => d.DepID, (u, d) => new { u, d }).
                     Where(x => x.u.RoleID == int.Parse(ddlRole.SelectedValue)).Select(x => new
                     {
                         IDUsers = x.u.IDUsers,
                         Name = x.u.LastName + x.u.FirstName,
                         Birthdate = x.u.Birthdate,
                         Gender = x.u.Gender,
                         Phone = x.u.Phone,
                         Address = x.u.Address,
                         Email = x.u.Email,
                         DepartmentName = x.d.Name,
                     });
                grvUser.DataSource = user;
                grvUser.DataBind();
            }
        }catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = int.Parse(ddlRole.SelectedValue);
        Response.Redirect("UserManagement.aspx?getRoleID=" + id);
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadToGrv();
    }
}