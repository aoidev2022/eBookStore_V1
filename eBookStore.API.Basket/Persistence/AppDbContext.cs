using eBookStore.API.Basket.Model;

using Microsoft.EntityFrameworkCore;

namespace eBookStore.API.Basket.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Model.Basket> Baskets { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Basket>().HasData(new Model.Basket[]
            {
                new Model.Basket{Id=1,CreatedOn=System.DateTimeOffset.UtcNow, Status=BasketStatusEnum.Open, Username="aoi@182@live.com"},
                new Model.Basket{Id=2,CreatedOn=System.DateTimeOffset.UtcNow, Status=BasketStatusEnum.Open, Username="aoi@182@live.com"},
            });

            modelBuilder.Entity<Item>().HasData(new Model.Item[]
            {
                new Item{Id=1,CreatedOn=System.DateTimeOffset.UtcNow, PurchasedPrice=5, BasketId=1,  BookId=1},
                new Item{Id=2,CreatedOn=System.DateTimeOffset.UtcNow, PurchasedPrice=5, BasketId=1,  BookId=2},
                new Item{Id=3,CreatedOn=System.DateTimeOffset.UtcNow, PurchasedPrice=5, BasketId=1,  BookId=3},

                new Item{Id=5,CreatedOn=System.DateTimeOffset.UtcNow, PurchasedPrice=5, BasketId=2,  BookId=2},
                new Item{Id=6,CreatedOn=System.DateTimeOffset.UtcNow, PurchasedPrice=5, BasketId=2,  BookId=2}
            });
        }
    }
}
