using QuestionForYou.Data.Model;
using System.Configuration;
using System.Data.Entity;

namespace QuestionForYou.Data.Storage
{
    public class QuestionForYouContext : DbContext
    {
        public QuestionForYouContext()
            : this("QuestionForYouConnectionString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<QuestionForYouContext>());
            //this.Database.Initialize(true);
        }

        public QuestionForYouContext(string connectionStringName)
            : base(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString)
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<QuestionForYouContext>());
            //this.Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasOptional(x => x.Category);

            modelBuilder.Entity<Question>()
                .HasMany(b => b.Answers);
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }
    }
}