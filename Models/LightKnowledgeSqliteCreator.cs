using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SQLite.CodeFirst;

namespace LightKnowledge.aspx.Models
{
    public class LightKnowledgeSqliteCreator : SqliteCreateDatabaseIfNotExists<LightKnowledgeDbContext>
    {
        public LightKnowledgeSqliteCreator(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void Seed(LightKnowledgeDbContext context)
        {
            context.Settings.Add(new Settings { Key = "AppName", Value = "LightKnowledge" });
            context.Settings.Add(new Settings { Key = "SchemaVersion", Value = "1" });
        }
    }
}