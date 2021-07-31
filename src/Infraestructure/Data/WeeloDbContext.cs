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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
