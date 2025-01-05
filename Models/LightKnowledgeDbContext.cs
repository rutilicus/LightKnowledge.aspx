using SQLite.CodeFirst;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Web.Hosting;

namespace LightKnowledge.aspx.Models
{
    public class LightKnowledgeDbContext : DbContext
    {

        public LightKnowledgeDbContext() : base("LightKnowledge")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new LightKnowledgeSqliteCreator(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        public DbSet<Settings> Settings { get; set; }
        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<KnowledgeTag> KnowledgeTags { get; set; }
    }
}
