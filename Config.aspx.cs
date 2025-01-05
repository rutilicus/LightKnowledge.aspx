using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    var appName = db.Settings.First(s => s.Key == "AppName");
                    SiteName.Text = appName.Value;
                }
            }
        }

        protected void SetBtn_Click(object sender, EventArgs e)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                var appName = db.Settings.First(s => s.Key == "AppName");
                appName.Value = SiteName.Text;
                db.SaveChanges();
                Application["AppName"] = SiteName.Text;
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}