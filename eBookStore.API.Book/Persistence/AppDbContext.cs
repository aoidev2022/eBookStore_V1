using Microsoft.EntityFrameworkCore;

namespace eBookStore.API.Book.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Model.Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Book>().HasData(new[]
            {
                new Model.Book{Id=1, Name="To Kill a Mockingbird", AuthorId=1, Price=5},
                new Model.Book{Id=2, Name="The Great Gatsby", AuthorId=1, Price=5},
                new Model.Book{Id=3, Name="One Hundred Years of Solitude", AuthorId=1, Price=5},
                new Model.Book{Id=4, Name="A Passage to India", AuthorId=1, Price=5}
            });
        }
    }
}
