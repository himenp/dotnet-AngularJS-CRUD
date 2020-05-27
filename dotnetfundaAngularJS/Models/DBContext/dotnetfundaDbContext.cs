using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace dotnetfundaAngularJS.Models
{
    public class dotnetfundaDbContext : DbContext
    {
        public dotnetfundaDbContext()
            : base("name=dotnetfundaDbContext")
        {
            Database.SetInitializer<dotnetfundaDbContext>(null);
        }
        public DbSet<Post> posts { get; set; }
        public DbSet<Tags> tags { get; set; }
        public DbSet<PostTags> posttags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();  
        }

    }
}