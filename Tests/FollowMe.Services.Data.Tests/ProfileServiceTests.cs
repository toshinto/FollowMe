using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using Moq;
using Xunit;
using FollowMe.Data.Models.Enum;

namespace FollowMe.Services.Data.Tests
{
    public class ProfileServiceTests
    {
        [Fact]
        public async Task EditPersonalDetailsShouldWorkCorrectly()
        {
            var photos = new List<Photo>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

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
            var photos = new List<Photo>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

            var user = new UserCharacteristic
            {
                Id = "2",
            };

            userChars.Add(user);

            string userId = service.GetId("2");
            Assert.Equal("2", userId);
        }

        [Fact]
        public void IsUserDetailsPageShouldReturnTrue()
        {
            var photos = new List<Photo>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

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
            var photos = new List<Photo>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

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
    }
}
