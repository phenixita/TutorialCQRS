using Microsoft.EntityFrameworkCore;

namespace IC6.TutorialCQRS.Model
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Post>().HasData(new Post() { Id = 1, Title = "O bella ciao", Body = "La casa de papel" });
        }


    }
}
