using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LightKnowledge.aspx
{
    public partial class DeleteResource : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values.ContainsKey("id") && RouteData.Values.ContainsKey("fileName"))
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                string fileName = RouteData.Values["fileName"].ToString();

                try
                {
                    File.Delete($"{Server.MapPath("/Resources")}/{id}/{fileName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                Response.Redirect($"~/ManageResource/{id}");
            }
        }
    }
}