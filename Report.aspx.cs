using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadtoGrv();
    }

    public void LoadtoGrv()
    {
        using (EWSDDataContext db = new EWSDDataContext())
        {
            int i = 0;
            List<sp_countIdeaOnDepartmentResult> spCount = db.sp_countIdeaOnDepartment().ToList();
            foreach(var totalIDeas in spCount)
            {
                i += totalIDeas.QuantityOfIdeas.Value;
            }

            int test = i;
            foreach (var dep in spCount)
            {
                double a = 0;
                a = (double)dep.QuantityOfIdeas.Value/test* 100;
                dep.Percent += Math.Round(a,1);
                
            }
            grvReport.DataSource = spCount;
            grvReport.DataBind();
        }
    }
}