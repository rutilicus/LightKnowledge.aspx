using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class KnowledgeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string setTitleText = "ナレッジ一覧";
                if (RouteData.Values.ContainsKey("tagId"))
                {
                    using (var db = new LightKnowledgeDbContext())
                    {
                        int tagId = Convert.ToInt32(RouteData.Values["tagId"]);
                        string tagName = db.Tags.First(t => t.TagId == tagId).Name;
                        setTitleText = $"タグ「{tagName}」のナレッジ一覧";
                    }
                }
                else if (RouteData.Values.ContainsKey("query"))
                {
                    setTitleText = $"「{RouteData.Values["query"].ToString()}」の検索結果";
                }
                this.Title = setTitleText;
                TitleLabel.Text = setTitleText;
            }
        }

        public List<Knowledge> GetKnowledge(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                if (RouteData.Values.ContainsKey("tagId"))
                {
                    int tagId = Convert.ToInt32(RouteData.Values["tagId"]);
                    var knowledgeIds = db.KnowledgeTags.Where(kt => kt.TagId == tagId).Select(kt => kt.KnowledgeId);
                    var query = db.Knowledge.Where(k => knowledgeIds.Contains(k.KnowledgeId)).OrderByDescending(k => k.KnowledgeId);
                    totalRowCount = query.Count();
                    return query.Skip(startRowIndex).Take(maximumRows).ToList();
                }
                else if (RouteData.Values.ContainsKey("query"))
                {
                    string searchText = RouteData.Values["query"].ToString();
                    // メソッド構文ではうまく日本語を処理できなかったため、生クエリを実行
                    var query = db.Knowledge.SqlQuery($"SELECT * FROM Knowledge WHERE (Title LIKE '%{searchText}%' OR Description LIKE '%{searchText}%') ORDER BY KnowledgeId DESC");
                    totalRowCount = query.Count();
                    return query.Skip(startRowIndex).Take(maximumRows).ToList();
                }
                else
                {
                    totalRowCount = db.Knowledge.Count();
                    return db.Knowledge.OrderByDescending(k => k.KnowledgeId).Skip(startRowIndex).Take(maximumRows).ToList();
                }
            }
        }
    }
}