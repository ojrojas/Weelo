using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Weelo.Core.Entities;

namespace Weelo.Infraestructure.Data
{
    /// <summary>
    /// WeeloDbContext Data Base Code First
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>29/07/2021</date>
    public class WeeloDbContext : DbContext
    {
        public WeeloDbContext(DbContextOptions<WeeloDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Model Entity Owner
        /// </summary>
        public DbSet<Owner> Owners { get; set; }
        /// <summary>
        /// Model Entity User
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Model Entity Property
        /// </summary>
        public DbSet<Property> Properties { get; set; }
        /// <summary>
        /// Model Entity PropertyImage
        /// </summary>
        public DbSet<PropertyImage> PropertyImages { get; set; }
        /// <summary>
        /// Model Entity PropertyTrace
        /// </summary>
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        /// <summary>
        /// OnModel property from property image to property trace
        /// </summary>
        /// <param name="builder">Builder entities realtion</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Property>()
            .HasOne(a => a.PropertyImage)
            .WithOne(b => b.Property)
            .HasForeignKey<PropertyImage>(b => b.PropertyId);

            builder.Entity<Property>()
           .HasOne(a => a.PropertyTrace)
           .WithOne(b => b.Property)
           .HasForeignKey<PropertyTrace>(b => b.PropertyId);

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
