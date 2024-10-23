using MatchS.Core.Entity.Core;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MatchS.Core.Data.Initialize
{
    public class DatabaseInitializer
    {
        private readonly AppDbContext _appDbContext;

        public DatabaseInitializer(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task InitializeDatabase()
        {
            if (!await _appDbContext.GetService<IDatabaseCreator>().CanConnectAsync())
            {
                await _appDbContext.Database.EnsureCreatedAsync();

                await _appDbContext.Categories.AddRangeAsync(new[]
                {
                    new Category()
                    {
                        Name="Bilardo"
                    },
                    new Category()
                    {
                        Name="Voleybol"
                    },
                    new Category()
                    {
                        Name="Futbol"
                    },
                    new Category()
                    {
                        Name="Basketbol"
                    },
                    new Category()
                    {
                        Name="Zar"
                    },
                    new Category()
                    {
                        Name="Kart"
                    },
                });

                await _appDbContext.Users.AddRangeAsync(new[]
                {
                     new User
                     {
                         UserName="Yaso",
                         Password="Yaso123",
                         FirstName="321abc",
                         LastName="123avc",
                         Age=10,
                         CityId="1",
                         DistrictId="3",
                     },
                     new User
                     {
                         UserName="Yaso1234",
                         Password="Yaso1234",
                         FirstName="321abc",
                         LastName="123avc",
                         Age=52,
                         CityId="2",
                         DistrictId="3",
                     },
                     new User
                     {
                         UserName="Yaso12345",
                         Password="Yaso12345",
                         FirstName="321abc",
                         LastName="123avc",
                         Age=30,
                         CityId="3",
                         DistrictId="3",
                     }
                });

                await _appDbContext.SaveChangesAsync();

                await _appDbContext.Adverts.AddRangeAsync(new[]
                {
                     new Advert
                     {
                         Title = "Voleybol İlanı",
                         Content = "Voleybol açıklaması",
                         GameDate = DateTime.Now,
                         RequiredUserCount = 2,
                         CategoryId = 1,
                         UserId = 1,
                         CityId="1",
                         DistrictId="3",
                     },
                     new Advert
                     {
                         Title = "Bilardo İlanı",
                         Content = "Bilardo Açıklama",
                         GameDate = DateTime.Now,
                         RequiredUserCount = 1,
                         CategoryId = 1,
                         UserId = 1,
                         CityId="1",
                         DistrictId="3",
                     },
                     new Advert
                     {
                         Title = "Futbol İlanı",
                         Content = "Futbol Açıklama",
                         GameDate = DateTime.Now,
                         RequiredUserCount = 1,
                         CategoryId = 3,
                         UserId = 2,
                         CityId="2",
                         DistrictId="3",
                     }
                });

                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
