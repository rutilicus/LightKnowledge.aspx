using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            string query = SearchText.Text;
            if (string.IsNullOrEmpty(query))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('テキストを入力してください。')", true);
            }
            else
            {
                Response.Redirect($"~/List/Search/{query}");
            }
        }
    }
}