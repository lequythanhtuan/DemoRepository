using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IdeaManagement : IdeaService
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PL.LoadCat2DDL(ddlCategories);
            EditIdea();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["EditIdea"] != null)
        {
            int id = int.Parse(Request.QueryString["editIdeaID"]);
            using (EWSDDataContext db = new EWSDDataContext())
            {
                var idea = db.Ideas.FirstOrDefault(x => x.IdeaID == id);
                idea.Title = txtTitle.Text;
                idea.Content = txtContent.Text;
                idea.Anonymous = chkAnony.Checked;
                idea.CatID = int.Parse(ddlCategories.SelectedValue);
                if (chkToR.Checked)
                    db.SubmitChanges();
                else
                {
                    Response.Write("<script language='javascript'>" + "alert('Your must agree to the term of reference before updating the idea" + "</script>");
                }
            }
        }
        else
        {
            var user = Session["user"] as User;
            List<string> list = new List<string>();
            DocumentSupport document = new DocumentSupport();
            int dateId;
            using (EWSDDataContext db = new EWSDDataContext())
            {
                var date = db.ClosureDates.FirstOrDefault(x => x.Status == true);
                dateId = date.Id;
            }
            Idea idea = new Idea()
            {
                CatID = int.Parse(ddlCategories.SelectedValue),
                DateCreated = DateTime.Now,
                Anonymous = chkAnony.Checked,
                ID_Iden = user.ID_Iden,
                Views = 0,
                Status = true,
                Title = txtTitle.Text,
                Content = txtContent.Text,
                ID_Date = dateId
            };
            if (fileUpload.CheckFiles())
            {
                foreach (var file in fileUpload.PostedFiles)
                {
                    list.Add(file.FileName);
                    document.Location = file.FileName;
                    string path = Server.MapPath(document.getLocation);
                    file.SaveAs(path);
                }
            }
            if (chkToR.Checked)
            {
                bool submit = AddIdea(idea, list);
                if (submit)
                {
                    string emailQA;
                    using (EWSDDataContext db = new EWSDDataContext())
                    {
                        var id = db.Users.Join(db.Departments, u => u.DepID, d => d.DepID, (u, d) => new { u, d, }).
                            FirstOrDefault(x => x.u.RoleID == 2 && x.d.DepID == user.DepID);
                        emailQA = id.u.Email;
                    }
                    var title = "There's a new idea just posted";
                    var body = "Your department has just got an idea with content :" + txtContent.Text;
                    PL.SendMail(emailQA, title, body);
                    Response.Redirect("Home.aspx");
                    Response.Write("<script language='javascript'>" + "alert('Your idea has been successfully posted" + "</script>");
                }
            }
            else
            {
                Response.Write("<script language='javascript'>" + "alert('Your must agree to the term of reference before Adding the idea" + "</script>");
            }
        }
    }

    public void EditIdea()
    {
        if (Request.QueryString["editIdeaID"] != null)
        {
            int id = int.Parse(Request.QueryString["editIdeaID"]);
            using (EWSDDataContext db = new EWSDDataContext())
            {
                var idea = db.Ideas.FirstOrDefault(x => x.IdeaID == id);
                txtTitle.Text = idea.Title;
                txtContent.Text = idea.Content;
                ddlCategories.SelectedValue = idea.CatID.ToString();
                chkAnony.Checked = idea.Anonymous;
            }
        }
    }
}