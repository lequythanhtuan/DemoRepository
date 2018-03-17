using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService : PageManagement
{
    public bool AddUser(User user)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            try
            {
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }

    public bool UpdateUser(User user)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }
    }
}