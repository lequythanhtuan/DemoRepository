using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : ReactionService
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadToGrv();
        }
    }

    public void LoadToGrv()
    {
        var id = Request.QueryString["Category"];
        IQueryable query;
        using (EWSDDataContext db = new EWSDDataContext())
        {
            List<Idea> lsIdea = db.Ideas.ToList();
            foreach (Idea idea in lsIdea)
            {
                if (idea.Anonymous == true)
                {
                    User user = db.Users.FirstOrDefault(x => x.ID_Iden == idea.ID_Iden);
                    idea.DisplayName = user.LastName + " " + user.FirstName;
                }
                else
                {
                    idea.DisplayName = "Anonymous";
                }
            }

            if (id == null)
                query = db.Ideas;
            else
            {
                query = db.Ideas.Where(x => x.CatID == int.Parse(id));
            }
            grvIdea.DataSource = query;
            grvIdea.DataBind();
        }
    }

    protected void lbtnID_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = sender as LinkButton;
        int id = int.Parse(lbtn.CommandArgument);
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var idea = db.Ideas.FirstOrDefault(x => x.IdeaID == id);
            idea.Views++;
            db.SubmitChanges();
        }
        User user = Session["user"] as User;
        Reaction reaction = new Reaction()
        {
            UserID = user.ID_Iden,
            IdeaID = id,
            Status = 0
        };
        AddReaction(reaction);
        Response.Redirect("IdeaDetail.aspx?IdeaID=" + id);
    }

    protected void grvIdea_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvIdea.PageIndex = e.NewPageIndex;
        LoadToGrv();
    }
}