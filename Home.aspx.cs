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
           // ViewIndex = 1;
          //  LoadGrvByFilter();
        }
    }

    //public void LoadGrvByFilter()
    //{
    //    using (EWSDDataContext db = new EWSDDataContext())
    //    {
    //        if (ddlFilter.SelectedValue == "1")
    //        {
    //            ViewIndex = 0;
    //            List<sp_LisOfLikeResult> sp = db.sp_LisOfLike().ToList();
    //            foreach (sp_LisOfLikeResult spResult in sp)
    //            {
    //                if (spResult.Anonymous == true)
    //                {
    //                    User user = db.Users.FirstOrDefault(x => x.ID_Iden == spResult.ID_Iden);
    //                    spResult.DisplayName = user.LastName + " " + user.FirstName;
    //                }
    //                else
    //                {
    //                    spResult.DisplayName = "Anonymous";
    //                }
    //            }
    //            grvIdea.DataSource = sp;
    //        }
    //        if(ddlFilter.SelectedValue == "2")
    //        {
    //            ViewIndex = 1;
    //            List<sp_LisOfDislikeResult> sp = db.sp_LisOfDislike().ToList();
    //            foreach (sp_LisOfDislikeResult spResult in sp)
    //            {
    //                if (spResult.Anonymous == true)
    //                {
    //                    User user = db.Users.FirstOrDefault(x => x.ID_Iden == spResult.ID_Iden);
    //                    spResult.DisplayName = user.LastName + " " + user.FirstName;
    //                }
    //                else
    //                {
    //                    spResult.DisplayName = "Anonymous";
    //                }
    //            }
    //            GridView1.DataSource = sp;
    //            GridView1.DataBind();
    //        }
    //    }
    //    grvIdea.DataBind();
    //}

    //public int ViewIndex
    //{
    //    set
    //    {
    //        mtvGrv.ActiveViewIndex = value;
    //    }
    //}

    public void LoadToGrv()
    {
        var id = Request.QueryString["Category"];
     //   int ddlId = int.Parse(ddlFilter.SelectedValue);
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
            if (id != null)
                query = db.Ideas.Where(x => x.CatID == int.Parse(id));
            else
                query = db.Ideas;
            //if (ddlId == 1)
            //    query = db.Ideas.Join(db.Reactions, i => i.IdeaID, r => r.IdeaID, (i, r) => new { i, r }).Where(x => x.r.Status == 1).GroupBy(x => x.r.IdeaID);
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

    //protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int id = int.Parse(ddlFilter.SelectedValue);

    //}
}