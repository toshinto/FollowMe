using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Tests.Profile;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class ProfileServiceTests
    {
        public ProfileServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ProfileViewModel).GetTypeInfo().Assembly);
        }
        [Fact]
        public async Task EditPersonalDetailsShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var userChar = new UserCharacteristic
            {
                Id = "1",
                FirstName = "Todor",
                LastName = "Georgiev",
                Weight = 100,
                Height = 100,
                Description = "xaxa",
                UserId = "1",
                City = City.Burgas,
                Gender = Gender.Male,
                EyeColor = EyesColor.Blue,
                HairColor = HairColor.Black,
                WeddingStatus = WeddingStatus.Single,
                WhatAreYouSearchingFor = WhatAreYouSearchingFor.Date,
            };
            userChars.Add(userChar);
            await service.EditPersonalDetails(new Web.ViewModels.Profiles.EditDetailsViewModel
            {
                Id = "1",
                FirstName = "Simona",
                LastName = "Kasabova",
                Weight = 150,
                Height = 150,
                Description = "az",
                UserId = "1",
                City = City.Dobrich,
                Gender = Gender.Female,
                EyeColor = EyesColor.Brown,
                HairColor = HairColor.Red,
                WeddingStatus = WeddingStatus.Married,
                WhatAreYouSearchingFor = WhatAreYouSearchingFor.Flirt,
            });

            Assert.Equal("Simona", userChar.FirstName);
            Assert.Equal("Kasabova", userChar.LastName);
            Assert.Equal(150, userChar.Weight);
            Assert.Equal(150, userChar.Height);
            Assert.Equal(City.Dobrich, userChar.City);
            Assert.Equal(Gender.Female, userChar.Gender);
            Assert.Equal(EyesColor.Brown, userChar.EyeColor);
            Assert.Equal(HairColor.Red, userChar.HairColor);
            Assert.Equal(WeddingStatus.Married, userChar.WeddingStatus);
            Assert.Equal(WhatAreYouSearchingFor.Flirt, userChar.WhatAreYouSearchingFor);
        }

        [Fact]
        public void GetIdShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "2",
            };

            userChars.Add(user);

            string userId = service.GetId("2");

            var expectedOutput = "2";
            Assert.Equal(expectedOutput, userId);
        }

        [Fact]
        public void IsUserDetailsPageShouldReturnTrue()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
            };

            userChars.Add(user);

            bool result = service.IsUserDetailsPage("1", "1");
            Assert.Equal(true, result);
        }

        [Fact]
        public void IsUserDetailsPageShouldReturnFalse()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
            };
            var secondUser = new UserCharacteristic
            {
                Id = "1",
                UserId = "2",
            };

            userChars.Add(user);
            userChars.Add(secondUser);

            bool result = service.IsUserDetailsPage("1", "2");
            Assert.Equal(false, result);
        }

        [Fact]
        public void GetAllShouldReturnCount2()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
            };
            var secondUser = new UserCharacteristic
            {
                Id = "1",
                UserId = "2",
            };

            userChars.Add(user);
            userChars.Add(secondUser);

            var users = service.GetAll<ProfileViewModel>();
            var expectedResult = 2;
            Assert.Equal(expectedResult, users.Count());
        }

        [Fact]
        public void GetByNameShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
                FirstName = "Todor",
                LastName = "Georgiev",
            };
            userChars.Add(user);

            var usr = service.GetByName<ProfileViewModel>("1", "1");
            Assert.Equal(user.FirstName, usr.FirstName);
            Assert.Equal(user.LastName, usr.LastName);
        }

        [Fact]
        public void EditViewShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
                FirstName = "Todor",
                LastName = "Georgiev",
            };
            userChars.Add(user);

            var usr = service.EditView<ProfileViewModel>("1");
            Assert.Equal(user.FirstName, usr.FirstName);
            Assert.Equal(user.LastName, usr.LastName);
        }

        [Fact]
        public void GetAllSearchShouldReturn1Count()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, null);

            string dateString = "5/14/1995";
            DateTime birthday = DateTime.Parse(dateString,
                          System.Globalization.CultureInfo.InvariantCulture);
            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
                FirstName = "Todor",
                LastName = "Georgiev",
                Gender = Gender.Male,
                City = City.Burgas,
                WhatAreYouSearchingFor = WhatAreYouSearchingFor.Flirt,
                Date = birthday,
            };
            userChars.Add(user);

            var users = service.GetAllSearch<ProfileViewModel>(new Web.ViewModels.Search.SearchIndexViewModel
            {
                City = City.Burgas,
                Gender = Gender.Male,
                MinimumAge = 14,
                MaximumAge = 40,
                SearchingFor = WhatAreYouSearchingFor.Flirt,
            });

            var expectedOutput = 1;
            Assert.Equal(expectedOutput, users.Count());
        }
    }
}
