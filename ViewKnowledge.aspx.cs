using LightKnowledge.aspx.Models;
using Markdig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class ViewKnowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int id = Convert.ToInt32(RouteData.Values["id"]);

                    var readData = db.Knowledge.First(t => t.KnowledgeId == id);
                    KnowledgeTitle.Text = readData.Title;
                    this.Title = readData.Title;

                    var pipeline = new MarkdownPipelineBuilder()
                        .Use(new ResourceExtension { id = id })
                        .Build();
                    Description.Text = Markdig.Markdown.ToHtml(readData.Description, pipeline);
                }
            }
        }

        public List<Tag> GetTags()
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int knowledgeId = Convert.ToInt32(RouteData.Values["id"]);
                    var tagIds = db.KnowledgeTags.Where(kt => kt.KnowledgeId == knowledgeId).Select(kt => kt.TagId);
                    return db.Tags.Where(t => tagIds.Contains(t.TagId)).OrderBy(t => t.TagId).ToList();
                }
            }
            else
            {
                return new List<Tag>();
            }
        }
    }
}