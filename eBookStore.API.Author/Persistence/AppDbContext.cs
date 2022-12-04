using eBookStore.API.Author.Model;

using Microsoft.EntityFrameworkCore;

using System;

namespace eBookStore.API.Author.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Model.Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Author>().HasData(new[]
            {
                new Model.Author{Id=1, DateOfBirth=DateTime.Parse("1980-11-04"),Name="Lucas Pavack"},
                new Model.Author{Id=2, DateOfBirth=DateTime.Parse("1984-06-05"),Name="Angela Nolskyv"}
            });

            modelBuilder.Entity<AcademicDegree>().HasData(new[]
            {
                new AcademicDegree{Id=1, AuthorId=1, Name="Associate degrees", CenterName="Academy Accel", AchievedOn=DateTime.Parse("1980-11-05")},
                new AcademicDegree{Id=2, AuthorId=2, Name="Associate degrees", CenterName="College Discover", AchievedOn=DateTime.Parse("1995-01-07")},
                new AcademicDegree{Id=3, AuthorId=2, Name="Associate degrees", CenterName="Higher Institute", AchievedOn=DateTime.Parse("1990-10-09")},
            });
        }
    }
}
