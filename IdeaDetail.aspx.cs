using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IdeaDetail : CommentService
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadIdeaToDataList();
            span.InnerText = CountComment().ToString();
            LoadRadioButton();
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        LoadCommentToDataList();
        CheckClosureDate();
    }

    public void LoadIdeaToDataList()
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        using (EWSDDataContext db = new EWSDDataContext())
        {
            List<Idea> lsIdea = db.Ideas.ToList();
            foreach (Idea idea in lsIdea)
            {
                if (idea.Anonymous == false)
                {
                    User user = db.Users.FirstOrDefault(x => x.ID_Iden == idea.ID_Iden);
                    idea.DisplayName = user.LastName + " " + user.FirstName;
                }
                else
                {
                    idea.DisplayName = "Anonymous";
                }
            }
            dtlIdea.DataSource = db.Ideas.Where(x => x.IdeaID == id);
            dtlIdea.DataBind();
        }
    }

    public void LoadCommentToDataList()
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        User userSession = Session["user"] as User;
        IQueryable filter;
        using (EWSDDataContext db = new EWSDDataContext())
        {
            List<Comment> lsCom = db.Comments.ToList();
            foreach (Comment comment in lsCom)
            {
                if (comment.Anonymous == false)
                {
                    User user = db.Users.FirstOrDefault(x => x.ID_Iden == comment.ID_Iden);
                    comment.DisplayName = user.LastName + " " + user.FirstName;
                }
                else
                {
                    comment.DisplayName = "Anonymous";
                }
            }

            if (userSession.RoleID == 4)
            {
                filter = db.Comments.Join(db.Users, c => c.ID_Iden, u => u.ID_Iden, (c, u) => new { c, u }).
                Join(db.Ideas, z => z.c.IdeaID, i => i.IdeaID, (u1, i) => new { u1, i }).
                Where(x => x.u1.u.RoleID == 4 && x.i.IdeaID == id).Select(x => new
                {
                    DateCreated = x.u1.c.DateCreated,
                    Content = x.u1.c.Content,
                    DisplayName = x.u1.c.Anonymous ? "Anonymous" : x.u1.u.LastName + x.u1.u.FirstName
                });
            }
            else
            {
                filter = db.Comments.Where(x => x.IdeaID == id);
            }
            dtComment.DataSource = filter;
            dtComment.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        User user = Session["user"] as User;
        Comment comment = new Comment()
        {
            IdeaID = id,
            DateCreated = DateTime.Now,
            Anonymous = chkAnony.Checked,
            ID_Iden = user.ID_Iden,
            Content = txtComment.Text
        };
        bool ok = AddComment(comment);
        if (ok && user.RoleID == 4)
        {
            string email;
            string title = "EWSD.University";
            string content = "Your idea has a new comment";
            using (EWSDDataContext db = new EWSDDataContext())
            {
                var query = db.Ideas.Join(db.Users, i => i.ID_Iden, u => u.ID_Iden, (i, u) => new { i, u }).
                FirstOrDefault(x => x.i.IdeaID == id);
                email = query.u.Email;
            }
            PL.SendMail(email, title, content);
            Response.Write("<script language='javascript'>" + "alert('Successfully Added')" + "</script>");
        }
    }

    public int CountComment()
    {
        User user = Session["user"] as User;
        int id = int.Parse(Request.QueryString["IdeaID"]);
        int i;
        using (EWSDDataContext db = new EWSDDataContext())
        {
            if (user.RoleID == 4)
            {
                i = db.Comments.Join(db.Users, c => c.ID_Iden, u => u.ID_Iden, (c, u) => new { c, u }).Where(x => x.u.RoleID == 4 && x.c.IdeaID == id).Count();
            }
            else
            {
                i = db.Comments.Count(x => x.IdeaID == id);
            }
        }
        return i;
    }

    private Control FindALL(ControlCollection page, string id)
    {
        foreach (Control c in page)
        {
            if (c.ID == id)
            {
                return c;
            }
            if (c.HasControls())
            {
                var res = FindALL(c.Controls, id);

                if (res != null)
                {
                    return res;
                }
            }
        }
        return null;
    }

    public void CheckClosureDate()
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        User userSession = Session["user"] as User;
        LinkButton linkButton = (LinkButton)FindALL(this.Page.Controls, "lbtnEdit");
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var rs = db.Ideas.FirstOrDefault(x => x.IdeaID == id);
            var closureDate = db.ClosureDates.FirstOrDefault(x => x.Status == true);
            if(rs.ID_Iden == userSession.ID_Iden && closureDate.ClosureDate1 > DateTime.Now)
                linkButton.Visible = true;
            else
            {
                linkButton.Visible = false;
            }
        }
    }

    protected void lbtnEdit_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        Response.Redirect("IdeaManagement.aspx?editIdeaID=" + id);
    }

    public void LoadRadioButton()
    {
        int id = int.Parse(Request.QueryString["IdeaID"]);
        User userSession = Session["user"] as User;
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var query = db.Reactions.FirstOrDefault(x => x.IdeaID == id && x.UserID == userSession.ID_Iden);
            rbtnStatus.SelectedValue = query.Status.ToString();
        }
    }
    protected void rbtnStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        User userSession = Session["user"] as User;
        int id = int.Parse(Request.QueryString["IdeaID"]);
        using (EWSDDataContext db = new EWSDDataContext())
        {
            RadioButtonList radioButton = sender as RadioButtonList;
            Reaction reaction = db.Reactions.FirstOrDefault(x => x.UserID == userSession.ID_Iden && x.IdeaID == id);
            if (reaction != null)
            {
                reaction.Status = int.Parse(radioButton.SelectedValue);
            }
            db.SubmitChanges();
        }
    }
}