using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Extensions
/// </summary>
public static class Extensions
{
    public static bool CheckFiles(this FileUpload fileUpload)
    {
        List<string> list = new List<string>() { "png", "jpg", "docx", "doc", "rar", "zip", "pdf" };
        if (!fileUpload.HasFiles) return false;
        foreach (var file in fileUpload.PostedFiles)
        {
            if (file.ContentLength > 4 * 1024 * 1024)
                return false;
            string check = file.FileName.Substring(file.FileName.LastIndexOf('.') + 1);
            return list.Contains(check.ToLower());
        }
        return true;
    }
}