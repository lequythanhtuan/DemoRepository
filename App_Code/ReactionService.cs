using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReactionService
/// </summary>
public class ReactionService : PageManagement
{
   public bool AddReaction(Reaction reaction)
    {
        try
        {
            using (EWSDDataContext db = new EWSDDataContext())
            {
                db.Reactions.InsertOnSubmit(reaction);
                db.SubmitChanges();
                return true;
            }
        }
        catch { return false; }
    }
}