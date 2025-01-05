using LightKnowledge.aspx.Models;
using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class ManageResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && RouteData.Values.ContainsKey("id"))
            {
                using (var db = new LightKnowledgeDbContext())
                {
                    int id = Convert.ToInt32(RouteData.Values["id"]);

                    var readData = db.Knowledge.First(t => t.KnowledgeId == id);
                    this.Title = $"{readData.Title} - リソース編集";

                    TitleLabel.Text = $"{readData.Title} - リソース編集";

                    var table = new DataTable();
                    table.Columns.Add("fileName", typeof(string));

                    var di = new DirectoryInfo($"{Server.MapPath("/Resources")}/{id}");
                    if (di.Exists)
                    {
                        foreach (var f in di.GetFiles("*"))
                        {
                            var row = table.NewRow();
                            row["fileName"] = f.Name;
                            table.Rows.Add(row);
                        }
                    }
                    else
                    {
                        di.Create();
                    }

                    FileList.DataSource = table;
                    FileList.DataBind();
                }
            }
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if (RouteData.Values.ContainsKey("id") && UploadFile.HasFile)
            {
                UploadFile.SaveAs($"{Server.MapPath("/Resources")}/{RouteData.Values["id"]}/{UploadFile.PostedFile.FileName}");
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}