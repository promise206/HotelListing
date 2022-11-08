using Newtonsoft.Json;
using System.Data;

namespace HotelListing.API.Data
{
    public class DbInitializer
    {
        public static async Task Seed(IApplicationBuilder builder)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();

            var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();
            //string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, @"ECommerceApp.Infrastructure\Data\");

            if (await context.Database.EnsureCreatedAsync())
                return;

            if (!context.Countries.Any())
            {
                List<Country> countryList = new List<Country>()
                {
                    new Country
                    {
                        Name = "Nigeria",
                        ShortName = "NG"
                    },
                    new Country
                    {
                        Name = "Jamaica",
                        ShortName = "JM"
                    },
                    new Country
                    {
                        Name = "Bahamas",
                        ShortName = "BS"
                    }
                };

                await context.Countries.AddRangeAsync(countryList);
            }

            if (!context.Hotels.Any())
            {
                List<Hotel> hotelList = new List<Hotel>()
                {
                    new Hotel
                {
                    Name = "SBI",
                    Address = "Sangotedo",
                    Rating = 5,
                    CountryId = 1
                },
                new Hotel
                {
                    Name = "Grace Manor",
                    Address = "Nsukka",
                    Rating = 4,
                    CountryId = 2
                },
                new Hotel
                {
                    Name = "King Palace",
                    Address = "Nnewi",
                    Rating = 3,
                    CountryId = 3
                }
                };
                await context.Hotels.AddRangeAsync(hotelList);
            }

            await context.SaveChangesAsync();
        }
    }
}
