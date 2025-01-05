using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class TagList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Tag> GetTag()
        {
            using (var db = new LightKnowledgeDbContext())
            {
                return db.Tags.ToList();
            }
        }
    }
}