using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentService
/// </summary>
public class CommentService : PageManagement
{
    public bool AddComment(Comment comment)
    {
        try
        {
            using (EWSDDataContext db = new EWSDDataContext())
            {
                db.Comments.InsertOnSubmit(comment);
                db.SubmitChanges();
            }
            return true;
        }
        catch { return false; }
    }
}