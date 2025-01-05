using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class AddTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EntryBtn_Click(object sender, EventArgs e)
        {
            var newTagName = TagName.Text.ToString();
            if (string.IsNullOrEmpty(newTagName))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('タグ名を入力してください。')", true);
            }
            else
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    if (db.Tags.Where(t => t.Name == newTagName).Any())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('既に登録済みのタグです。')", true);
                    }
                    else
                    {
                        int newId = (db.Tags.Max(t => (int?)t.TagId) ?? 0) + 1;
                        db.Tags.Add(new Tag { TagId = newId, Name = newTagName });
                        db.SaveChanges();
                        Response.Redirect(Request.RawUrl);
                    }
                }
            }
        }
    }
}