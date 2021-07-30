using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Weelo.Core.Entities;

namespace Weelo.Infraestructure.Data
{
    public class WeeloDbContext : DbContext
    {
        public WeeloDbContext(DbContextOptions<WeeloDbContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
