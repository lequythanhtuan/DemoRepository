using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Idea
/// </summary>

public partial class Idea
{
    public string DisplayName { get; set; }
}

public partial class sp_LisOfLikeResult
{
    public string DisplayName { get; set; }
}

public partial class sp_LisOfDislikeResult
{
    public string DisplayName { get; set; }
}

public partial class sp_countIdeaOnDepartmentResult
{
    public double Percent{ get; set; }
}