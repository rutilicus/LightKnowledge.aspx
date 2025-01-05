using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class EditKnowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int id = Convert.ToInt32(RouteData.Values["id"]);
                    var readData = db.Knowledge.First(t => t.KnowledgeId == id);
                    KnowledgeTitle.Text = readData.Title;
                    KnowledgeText.Text = readData.Description;
                }
            }
        }

        protected void EntryBtn_Click(object sender, EventArgs e)
        {
            string title = KnowledgeTitle.Text.ToString();
            string description = KnowledgeText.Text.ToString();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('ナレッジ名とナレッジ本文を入力してください。')", true);
            }
            else
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int id = 0;
                    if (RouteData.Values.ContainsKey("id"))
                    {
                        id = Convert.ToInt32(RouteData.Values["id"]);
                        var editData = db.Knowledge.First(t => t.KnowledgeId == id);
                        editData.Title = KnowledgeTitle.Text.ToString();
                        editData.Description = KnowledgeText.Text.ToString();
                    }
                    else
                    {
                        id = (db.Knowledge.Max(t => (int?)t.KnowledgeId) ?? 0) + 1;
                        db.Knowledge.Add(new Knowledge
                        {
                            KnowledgeId = id,
                            Title = KnowledgeTitle.Text.ToString(),
                            Description = KnowledgeText.Text.ToString()
                        });
                    }
                    db.SaveChanges();
                    Response.Redirect($"~/View/{id}");
                }
            }
        }
    }
}