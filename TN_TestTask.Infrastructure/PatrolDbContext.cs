using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure
{
    public class PatrolDbContext : DbContext
    {
        public DbSet<Patrol> Patrols { get; private set; }

        public PatrolDbContext(DbContextOptions<PatrolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
