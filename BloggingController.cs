using Microsoft.EntityFrameworkCore;

namespace BlogsAssignment{
        public class BloggingController : DbContext{
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Post> Posts{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }   
}
