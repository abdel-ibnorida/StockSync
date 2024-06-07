using Microsoft.EntityFrameworkCore;
using StockSync.Models;

namespace StockSync.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().
                HasData(new Category[]
                {
                    new Category{CategoryID=1, Name = "Sport"},
                    new Category{CategoryID=2, Name = "Audio"},
                    new Category{CategoryID=3, Name = "Tv"},
                    new Category{CategoryID=4, Name = "Console"},
                    new Category{CategoryID=5, Name = "Computer"},
                    new Category{CategoryID=6, Name = "Clothes"},
                });               
            base.OnModelCreating(modelBuilder);
        }
    }
}
