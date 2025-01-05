using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class ManageTag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Tag> GetTags(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                totalRowCount = db.Tags.Count();
                return db.Tags.OrderByDescending(t => t.TagId).Skip(startRowIndex).Take(maximumRows).ToList();
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                for (int i = 0; i < TagList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = GetValues(TagList.Rows[i]);
                    int tagId = Convert.ToInt32(rowValues["TagId"]);
                    var dbRowData = db.Tags.First(t => t.TagId == tagId);
                    string oldTagName = (rowValues["Name"]).ToString();
                    string newTagName = ((TextBox)TagList.Rows[i].FindControl("NewTagName")).Text.ToString();

                    if (((CheckBox)TagList.Rows[i].FindControl("Remove")).Checked)
                    {
                        db.Tags.Remove(dbRowData);
                    } else if (newTagName != oldTagName && !string.IsNullOrEmpty(newTagName))
                    {
                        dbRowData.Name = newTagName;
                    }
                }

                db.SaveChanges();
            }

            Response.Redirect(Request.RawUrl);
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
            }
            return values;
        }
    }
}