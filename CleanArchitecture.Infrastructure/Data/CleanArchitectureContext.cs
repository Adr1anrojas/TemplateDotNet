using CleanArchitecture.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Data
{
    public partial class CleanArchitectureContext : DbContext
    {
        public CleanArchitectureContext()
        {
        }

        public CleanArchitectureContext(DbContextOptions<CleanArchitectureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
