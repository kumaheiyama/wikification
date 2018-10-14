using Microsoft.EntityFrameworkCore;
using Wikification.Data.Datastructure;
using Wikification.Data.Extensions;

namespace Wikification.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("wikifi");
            builder.ApplyAllConfigurationsFromAssembly(GetType().Assembly);

            MainContextSeeder.Seed(builder);

            base.OnModelCreating(builder);
        }

        public DbSet<Badge> Badges { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContentPage> ContentPages { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<ExternalSystem> Systems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
