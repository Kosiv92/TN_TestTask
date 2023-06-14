using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Patrol> Patrols { get; private set; }
        public DbSet<Place> Places { get; private set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
