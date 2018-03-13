using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClosureDateService
/// </summary>
public class ClosureDateService : PageManagement
{
   public bool AddDate(DateTime start, DateTime end, DateTime closureDate, DateTime finalDate, int userID)
    {
        try
        {
            using (EWSDDataContext db = new EWSDDataContext())
            {
                ClosureDate _closureDate = new ClosureDate();
                _closureDate.YearStart = start;
                _closureDate.YearEnd = end;
                _closureDate.ClosureDate1 = closureDate;
                _closureDate.FinalClosureDate = finalDate;
                _closureDate.Status = true;
                _closureDate.CreateDate = DateTime.Now;
                _closureDate.CreateBy = userID;
                db.ClosureDates.InsertOnSubmit(_closureDate);
                db.SubmitChanges();
                return true;
            }
        }
        catch { return false; }
    }
}