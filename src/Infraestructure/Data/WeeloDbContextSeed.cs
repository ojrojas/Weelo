using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weelo.Core.Entities;

namespace Weelo.Infraestructure.Data
{
    /// <summary>
    /// Seed WeeloContext InMemory
    /// </summary>
    /// <author>OScar Julian ROjas</author>
    /// <date>04/08/2021</date>
    public class WeeloDbContextSeed
    {
        private static Guid UserId1 = Guid.Parse("877157f4-b8f0-40f4-8e38-c05441ba602e");
        private static Guid UserId2 = Guid.NewGuid();
        private static Guid UserId3 = Guid.NewGuid();

        private static Guid OwnerId1 = Guid.NewGuid();
        private static Guid OwnerId2 = Guid.NewGuid();

        private static Guid PropertyId1 = Guid.NewGuid();

        public static async Task SeedAsync(WeeloDbContext weeloDbContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {

                if (!await weeloDbContext.Users.AnyAsync())
                {
                    await weeloDbContext.Users.AddRangeAsync(
                        GetPreconfiguredUsers());

                    await weeloDbContext.SaveChangesAsync();
                }

                if (!await weeloDbContext.Owners.AnyAsync())
                {
                    await weeloDbContext.Owners.AddRangeAsync(
                        GetPreconfiguredOwners());

                    await weeloDbContext.SaveChangesAsync();
                }

                if (!await weeloDbContext.Properties.AnyAsync())
                {
                    await weeloDbContext.Properties.AddRangeAsync(
                        GetPreconfiguredProperties());

                    await weeloDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<WeeloDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(weeloDbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<User> GetPreconfiguredUsers()
        {
            return new List<User>()
            {
                new User{Name ="Fabio", LastName="Ozuna", UserName ="fabio", Password="Abc12345#" },
                new User{Name ="Camila", LastName="Ozuna", UserName ="camila", Password="Abc12345#" },
                new User{Name ="Sandra", LastName="Ozuna", UserName ="sandra", Password="Abc12345#" },
            };
        }

        static IEnumerable<Owner> GetPreconfiguredOwners()
        {
            return new List<Owner>()
            {
                new Owner{  Name = "Kate Michelsen", Address ="Krr 887784 av park", Birthday= DateTime.Now},
                new Owner{  Name = "Kate Michelsen", Address ="Krr 887784 av park", Birthday= DateTime.Now}
            };
        }

        static IEnumerable<Property> GetPreconfiguredProperties()
        {

            var propertyImage = new PropertyImage { File = "", PropertyId = PropertyId1, Width = 100, Height = 100 };
            var propertyTrace = new PropertyTrace { Name = "TraceNew", PropertyId = PropertyId1, Value = 100, Tax = 1.22M };

            return new List<Property>()
            {
                new Property{
                    Address="CEntral parks av ever green 123",
                    Name="Tomahawk",
                    OwnerId=OwnerId1,
                    Price=522145,
                    Year= 1920,
                    PropertyImage = propertyImage,
                    PropertyTrace = propertyTrace},
            };
        }
    }
}
