using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PL
/// </summary>
public class PL
{
   public static void LoadRole2DDL(DropDownList dropdowList)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            //Role role = new Role()
            //{
            //    RoleID = 0,
            //    RoleName = "Select Role"
            //};
            var query = db.Roles.ToList();
             
            dropdowList.DataSource = query;
            dropdowList.DataTextField = "RoleName";
            dropdowList.DataValueField = "RoleID";
            dropdowList.DataBind();
        }
    }

    public static void LoadDep2DDL(DropDownList dropdowList)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var dep = db.Departments.Where(x => x.DepID > 1);
            dropdowList.DataSource = dep;
            dropdowList.DataTextField = "Name";
            dropdowList.DataValueField = "DepID";
            dropdowList.DataBind();
        }
    }
    public static void LoadCat2DDL(DropDownList dropdowList)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var categories = db.Categories.ToList();
            dropdowList.DataSource = categories;
            dropdowList.DataTextField = "Name";
            dropdowList.DataValueField = "CatID";
            dropdowList.DataBind();
        }
    }



    public static void LoadCat2Grv(GridView gridView)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var category = db.Categories.ToList();
            gridView.DataSource = category;
            gridView.DataBind();
        }
    }

    public static bool SendMail(string To, string Subject, string Body)
    {
        MailMessage msg = new MailMessage("ewsd.university@gmail.com", To, Subject, Body);
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential("ewsd.university@gmail.com", "thanhtuan");
        smtp.EnableSsl = true;
        try
        {
            smtp.Send(msg);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void CreateZipFile(string fileName, IEnumerable<string> files)
    {
        var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);
        foreach (var file in files)
        {
            zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
        }
        zip.Dispose();
    }

    public static void LoadCat2RPT(Repeater rpt)
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var list = db.sp_GetCategory().ToList();
            rpt.DataSource = list;
            rpt.DataBind();
        }
    }
}