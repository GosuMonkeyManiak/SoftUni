using Microsoft.EntityFrameworkCore;

namespace CarShop.Data
{
    using Model;

    public class CarShopDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Issue> Issues { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarShop;Trusted_Connection=True;");
            }
        }
    }
}
