using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Knowledge> GetNewKnowledge()
        {
            using (var db = new LightKnowledgeDbContext())
            {
                return db.Knowledge.OrderByDescending(k => k.KnowledgeId).Take(5).ToList();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}