using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Document
/// </summary>
public partial class DocumentSupport
{
    public string getLocation
    {
        get
        {
            return string.Format(@"~/Files/{0}", this.Location);
        }
    }
}