using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IdeaService
/// </summary>
public class IdeaService : PageManagement
{
    EWSDDataContext db = new EWSDDataContext();
    public bool AddIdea(Idea idea, List<String> list = null)
    {
        try
        {
            if(list != null)
            {
                foreach(var l in list)
                {
                    DocumentSupport doc = new DocumentSupport();
                    doc.IdeaID = idea.IdeaID;
                    doc.Location = l.ToString();
                    idea.DocumentSupports.Add(doc);
                }
            }
            db.Ideas.InsertOnSubmit(idea);
            db.SubmitChanges();
            return true;
        }
        catch(Exception ex)
        {
            Response.Write(ex.ToString());
            return false; }
    }
}