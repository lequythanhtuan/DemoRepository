using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DownloadManagement : PageManagement
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadToGrv();
            DeleteFile();
        }
    }

    protected void chkDown_CheckedChanged(object sender, EventArgs e)
    {
        RememberOldValues();
    }

    protected void grvIdea_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
        grvIdea.PageIndex = e.NewPageIndex;
        LoadToGrv();
        RePopulateValues();
    }

    public void LoadToGrv()
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            grvIdea.DataSource = db.Ideas;
            grvIdea.DataBind();
        }
    }
    private void RememberOldValues()
    {
        ArrayList listIdea = new ArrayList();
        int index = -1;
        foreach (GridViewRow row in grvIdea.Rows)
        {
            index = (int)grvIdea.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("chkDown")).Checked;

            // Check in the Session
            if (Session["selectIdea"] != null)
                listIdea = (ArrayList)Session["selectIdea"];
            if (result)
            {
                if (!listIdea.Contains(index))
                    listIdea.Add(index);
            }
            else
                listIdea.Remove(index);
        }
        if (listIdea != null && listIdea.Count > 0)
            Session["selectIdea"] = listIdea;
    }

    private void RePopulateValues()
    {
        ArrayList listIdea = (ArrayList)Session["selectIdea"];
        if (listIdea != null && listIdea.Count > 0)
        {
            foreach (GridViewRow row in grvIdea.Rows)
            {
                int index = (int)grvIdea.DataKeys[row.RowIndex].Value;
                if (listIdea.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("chkDown");
                    myCheckBox.Checked = true;
                }
            }
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        ArrayList listIdea = (ArrayList)Session["selectIdea"];
        if (listIdea != null && listIdea.Count > 0)
        {
            string time = DateTime.Now.ToString();
            string nameZip = "EWSD_" + Regex.Replace(time, "[^0-9]+", "").ToString() + ".zip";
            List<string> ls = new List<string>();
            foreach (int i in listIdea)
            {
                using (EWSDDataContext db = new EWSDDataContext())
                {
                    List<string> list = new List<string>();
                    var idea = db.Ideas.FirstOrDefault(x => x.IdeaID == i);
                    string name = "EWSD_University_" + idea.Title + ".zip";
                    var aut = db.Users.FirstOrDefault(x => x.ID_Iden == idea.ID_Iden);
                    var cm = db.Comments.Where(x => x.IdeaID == i).ToList();
                    var getDocument = db.DocumentSupports.Where(x => x.IdeaID == i);
                    var path = Server.MapPath(@"~/Files/Temp/" + idea.Title.Trim()) + ".pdf";
                    FileStream fs = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write);
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.AddAuthor("EWSD_University");
                    document.AddCreator("QA-Manager");
                    document.AddTitle("The new idea of ABC");
                    document.Open();
                    Font titleFont = FontFactory.GetFont("Arial", 20);
                    Font regularFont = FontFactory.GetFont("Arial", 13);
                    Font authorFont = FontFactory.GetFont("Arial", 15);
                    Paragraph title;
                    Paragraph text;
                    Paragraph author;
                    Paragraph authorcomment;
                    title = new Paragraph(idea.Title, titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    document.Add(title);
                    author = new Paragraph(aut.IDUsers, authorFont);
                    author.Font.IsBold();
                    document.Add(author);
                    text = new Paragraph(idea.Content, regularFont);
                    document.Add(text);
                    document.Add(new Paragraph("Comments", FontFactory.GetFont("Arial", 20)));
                    document.Add(new Paragraph(" "));
                    foreach (var comment in cm)
                    {
                        var autcomment = db.Users.FirstOrDefault(x => x.ID_Iden == comment.ID_Iden);
                        authorcomment = new Paragraph(autcomment.IDUsers, authorFont);
                        authorcomment.Font.IsBold();
                        document.Add(authorcomment);
                        text = new Paragraph(comment.Content, regularFont);
                        document.Add(text);
                        document.Add(new Paragraph(" "));
                    }
                    document.Close();
                    writer.Close();
                    foreach (var doc in getDocument)
                    {
                        list.Add(Server.MapPath(@"~/Files/" + doc.Location));
                    }
                    list.Add(path);
                    string filename = Server.MapPath(@"~/Files/Temp/" + name);
                    PL.CreateZipFile(filename, list);
                    ls.Add(filename);
                }
            }
            string local = Server.MapPath(@"~/Files/Temp/" + nameZip);
            PL.CreateZipFile(local, ls);
            Response.Redirect("http://localhost:54917/Files/Temp/" + nameZip);
        }
    }

    public void DeleteFile()
    {
        string[] file = Directory.GetFiles(Server.MapPath(@"~/Files/Temp/"));
        foreach (string fileName in file)
            File.Delete(fileName);
    }
    public void Download()
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            var idea = db.Ideas.FirstOrDefault(x => x.IdeaID == 1);
            var aut = db.Users.FirstOrDefault(x => x.ID_Iden == idea.ID_Iden);
            var cm = db.Comments.Where(x => x.IdeaID == 1).ToList();
            var path = Server.MapPath(@"~/Files/Temp/" + idea.Title.Trim()) + ".pdf";
            FileStream fs = new FileStream(path, FileMode.Create, System.IO.FileAccess.Write);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddAuthor("EWSD_University");
            document.AddCreator("QA-Manager");
            document.AddTitle("The new idea of ABC");
            document.Open();
            Font titleFont = FontFactory.GetFont("Arial", 20);
            Font regularFont = FontFactory.GetFont("Arial", 13);
            Font authorFont = FontFactory.GetFont("Arial", 15);
            Paragraph title;
            Paragraph text;
            Paragraph author;
            Paragraph authorcomment;
            title = new Paragraph(idea.Title, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);
            author = new Paragraph(aut.IDUsers, authorFont);
            author.Font.IsBold();
            document.Add(author);
            text = new Paragraph(idea.Content, regularFont);
            document.Add(text);
            document.Add(new Paragraph("Comments", FontFactory.GetFont("Arial", 20)));
            document.Add(new Paragraph(" "));
            foreach (var comment in cm)
            {
                var autcomment = db.Users.FirstOrDefault(x => x.ID_Iden == comment.ID_Iden);
                authorcomment = new Paragraph(autcomment.IDUsers, authorFont);
                authorcomment.Font.IsBold();
                document.Add(authorcomment);
                text = new Paragraph(comment.Content, regularFont);
                document.Add(text);
                document.Add(new Paragraph(" "));
            }

            document.Close();
            writer.Close();
        }
    }

}