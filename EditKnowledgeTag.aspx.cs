using LightKnowledge.aspx.Models;
using Markdig.Extensions.TaskLists;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class EditKnowledgeTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int id = Convert.ToInt32(RouteData.Values["id"]);
                    
                    var knowledgeData = db.Knowledge.First(t => t.KnowledgeId == id);
                    this.Title = $"{knowledgeData.Title} - タグ編集";

                    TitleLabel.Text = $"{knowledgeData.Title} - タグ編集";

                    var table = new DataTable();
                    table.Columns.Add("relationID", typeof(int));
                    table.Columns.Add("tagName", typeof(string));

                    var query = from k in db.KnowledgeTags
                                join t in db.Tags
                                on k.TagId equals t.TagId
                                where k.KnowledgeId == id
                                select new
                                {
                                    k.RelationId,
                                    TagName = t.Name
                                };

                    foreach (var q in query)
                    {
                        var row = table.NewRow();
                        row["relationID"] = q.RelationId;
                        row["tagName"] = q.TagName;
                        table.Rows.Add(row);
                    }

                    KnowledgeTagList.DataSource = table;
                    KnowledgeTagList.DataBind();

                    AddTagDropDownList.DataSource = db.Tags.ToDictionary(t => t.TagId, t => t.Name);
                    AddTagDropDownList.DataTextField = "Value";
                    AddTagDropDownList.DataValueField = "Key";
                    AddTagDropDownList.DataBind();
                }
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                for (int i = 0; i < KnowledgeTagList.Rows.Count; i++)
                {
                    var row = KnowledgeTagList.Rows[i];
                    if (((CheckBox)row.FindControl("Remove")).Checked)
                    {
                        int relationId = Convert.ToInt32(((Label)row.FindControl("RelationID")).Text);
                        var dbRowData = db.KnowledgeTags.First(k => k.RelationId == relationId);
                        db.KnowledgeTags.Remove(dbRowData);
                    }
                }

                db.SaveChanges();
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int knowledgeId = Convert.ToInt32(RouteData.Values["id"]);
                    int tagId = Convert.ToInt32(AddTagDropDownList.SelectedItem.Value);
                    if (!db.KnowledgeTags.Where(k => k.KnowledgeId == knowledgeId && k.TagId == tagId).Any())
                    {
                        int newRelationId = (db.KnowledgeTags.Max(k => (int?)k.RelationId) ?? 0) + 1;
                        db.KnowledgeTags.Add(new KnowledgeTag { RelationId = newRelationId, KnowledgeId = knowledgeId, TagId = tagId });
                        db.SaveChanges();
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}