using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoriesService
/// </summary>
/// 


public class CategoriesService : PageManagement
{
    private EWSDDataContext db = new EWSDDataContext();
    public Category FindCategory(int id)
    {
        return db.Categories.FirstOrDefault(x => x.CatID == id);
    }
    public bool AddCategories(Category category)
    {
        try
        {
            db.Categories.InsertOnSubmit(category);
            db.SubmitChanges();
            return true;
        }
        catch { return false; }
    }

    public bool Deletecategories(int id)
    {
        try
        {
            db.Categories.DeleteOnSubmit(FindCategory(id));
            db.SubmitChanges();
            return true;
        }
        catch { return false; }
    }
}