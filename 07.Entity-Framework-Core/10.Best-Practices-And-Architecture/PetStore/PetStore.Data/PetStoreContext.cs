namespace PetStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetStore.Models;

    public class PetStoreContext : DbContext
    {
        public PetStoreContext()
        {
            
        }

        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            : base(options)
        {

        }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<CustomerServiceType> CustomerServiceTypes { get; set; }

        public DbSet<Decoration> Decorations { get; set; }

        public DbSet<DecorationDistributor> DecorationDistributors { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodDistributor> FoodDistributors { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<IncomeLog> IncomeLogs { get; set; }

        public DbSet<PaymentLog> PaymentLogs { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<PetType> PetTypes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<ToyDistributor> ToyDistributors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserDecoration> UsersDecorations { get; set; }

        public DbSet<UserFood> UsersFoods { get; set; }

        public DbSet<UserService> UsersServices { get; set; }

        public DbSet<UserToy> UsersToys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=PetStore;User Id=sa;Password=Mitko875486123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFood>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.FoodId });

                entity.HasOne(o => o.User)
                    .WithMany(m => m.UsersFoods)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Food)
                    .WithMany(m => m.UsersFoods)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserToy>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.ToyId });

                entity
                    .HasOne(o => o.Toy)
                    .WithMany(m => m.UsersToys)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(o => o.User)
                    .WithMany(m => m.UsersToys)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserDecoration>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.DecorationId });

                entity
                    .HasOne(o => o.User)
                    .WithMany(m => m.UsersDecorations)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(o => o.Decoration)
                    .WithMany(m => m.UsersDecorations)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserService>(entity =>
            {
                entity.HasKey(k => new { k.UserId, k.ServiceId });

                entity
                    .HasOne(o => o.User)
                    .WithMany(m => m.UsersServices)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(o => o.Service)
                    .WithMany(m => m.UsersServices)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Service>()
                .HasOne(o => o.ServiceType)
                .WithMany(m => m.Services)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(o => o.PetType)
                .WithMany(m => m.Services)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Toy>()
                .HasOne(o => o.ToyDistributor)
                .WithMany(m => m.Toys)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Food>()
                .HasOne(o => o.FoodDistributor)
                .WithMany(m => m.Foods)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Decoration>()
                .HasOne(o => o.DecorationDistributor)
                .WithMany(m => m.Decorations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
                .HasOne(o => o.Buyer)
                .WithMany(m => m.Pets)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
                .HasOne(o => o.Gender)
                .WithMany(m => m.Pets)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
                .HasOne(o => o.Breed)
                .WithMany(m => m.Pets)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Breed>()
                .HasOne(o => o.PetType)
                .WithMany(m => m.Breeds)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentLog>()
                .HasOne(o => o.PaymentType)
                .WithMany(m => m.PaymentLogs)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncomeLog>()
                .HasOne(o => o.CustomerServiceType)
                .WithMany(m => m.Transactions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
