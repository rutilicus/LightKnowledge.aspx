using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class DeleteKnowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    var knowledgeId = Convert.ToInt32(RouteData.Values["id"]);
                    var removeKnowledgeTags = db.KnowledgeTags.Where(k => k.KnowledgeId == knowledgeId);
                    foreach (var item in removeKnowledgeTags)
                    {
                        db.KnowledgeTags.Remove(item);
                    }
                    var removeKnowledge = db.Knowledge.First(k => k.KnowledgeId == knowledgeId);
                    db.Knowledge.Remove(removeKnowledge);

                    db.SaveChanges();

                    Directory.Delete($"{Server.MapPath("/Resources")}/{knowledgeId}", true);
                }
            }
            Response.Redirect("~/ManageKnowledge");
        }
    }
}