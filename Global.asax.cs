using LightKnowledge.aspx.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LightKnowledge.aspx
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            using (var db = new LightKnowledgeDbContext())
            {
                var query = from kv in db.Settings where kv.Key == "AppName" select kv.Value;
                Application["AppName"] = query.Single();
            }

            Directory.CreateDirectory(Server.MapPath("/Resources"));

            RegisterCustomRoutes(RouteTable.Routes);
        }

        private void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "",
                "AddTag",
                "~/AddTag.aspx"
            );
            routes.MapPageRoute(
                "",
                "ManageTag",
                "~/ManageTag.aspx"
            );
            routes.MapPageRoute(
                "",
                "Add",
                "~/EditKnowledge.aspx"
            );
            routes.MapPageRoute(
                "",
                "Edit/{id}",
                "~/EditKnowledge.aspx"
            );
            routes.MapPageRoute(
                "",
                "View/{id}",
                "~/ViewKnowledge.aspx"
            );
            routes.MapPageRoute(
                "",
                "ManageKnowledge",
                "~/ManageKnowledge.aspx"
            );
            routes.MapPageRoute(
                "",
                "ManageResource/{id}",
                "~/ManageResource.aspx"
            );
            routes.MapPageRoute(
                "",
                "DeleteResource/{id}/{fileName}",
                "~/DeleteResource.aspx"
            );
            routes.MapPageRoute(
                "",
                "EditKnowledgeTag/{id}",
                "~/EditKnowledgeTag.aspx"
            );
            routes.MapPageRoute(
                "",
                "DeleteKnowledge/{id}",
                "~/DeleteKnowledge.aspx"
            );
            routes.MapPageRoute(
                "",
                "List",
                "~/KnowledgeList.aspx"
            );
            routes.MapPageRoute(
                "",
                "List/Tag/{tagId}",
                "~/KnowledgeList.aspx"
            );
            routes.MapPageRoute(
                "",
                "List/Search/{query}",
                "~/KnowledgeList.aspx"
            );
            routes.MapPageRoute(
                "",
                "Tags",
                "~/TagList.aspx"
            );
            routes.MapPageRoute(
                "",
                "Search",
                "~/Search.aspx"
            );
            routes.MapPageRoute(
                "",
                "Config",
                "~/Config.aspx"
            );
        }
    }
}