using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Data.Models;

namespace FollowMe.Data.Seeding
{
    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            var europeCountries = new List<string> { "Russia", "Ukraine", "France",
                "Spain", "Sweden", "Norway", "Germany", "Finland", "Poland", "Italy", "United Kingdom", "Romania", "Belarus", "Kazakhstan", "Greece", "Bulgaria", "Iceland", "Hungary", "Portugal", "Austria", "Czechia",
                "Serbia", "Ireland", "Lithuania", "Latvia", "Croatia", "Bosnia and Herzegovina", "Slovakia", "Estonia", "Denmark", "Switzerland",
                "Moldova", "Belgium", "Armenia", "Albania", "North Macedonia", "Turkey",
                "Slovenia", "Montenegro", "Kosovo", "Azerbaijan", "Cyprus", "Luxemburg",
                "Georgea", "Andorra", "Malta", "Liechtenstein", "San Marino", "Monaco",
                "Vatican City",
            };
            foreach (var country in europeCountries)
            {
                await dbContext.Countries.AddAsync(new Country
                {
                    Name = country,
                });
            }
        }
    }
}
