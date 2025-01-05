using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class ManageKnowledge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Knowledge> GetKnowledge(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                totalRowCount = db.Knowledge.Count();
                return db.Knowledge.OrderByDescending(k => k.KnowledgeId).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }
    }
}