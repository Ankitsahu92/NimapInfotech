using Microsoft.EntityFrameworkCore;
using NimapInfotech.Models.EntityModels;

namespace NimapInfotech.Entity
{
    public class NimapInfotechContext : DbContext
    {
        public NimapInfotechContext(DbContextOptions<NimapInfotechContext> options) : base(options)
        {

        }

        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMaster>().HasData(
                new CategoryMaster
                {
                    Id = 1,
                    Name = "Entertainment",
                    CreatedBy = "Yashi",
                    CreatedOn = DateTime.Now
                }
            ); modelBuilder.Entity<ProductMaster>().HasData(
                 new ProductMaster
                 {
                     Id = 1,
                     Name = "Prime Video",
                     CategoryId = 1,
                     CreatedBy = "Yashi",
                     CreatedOn = DateTime.Now
                 }
             );
        }

    }
}
