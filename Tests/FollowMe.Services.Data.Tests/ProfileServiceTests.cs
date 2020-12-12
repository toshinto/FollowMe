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
            var photo = new List<Photo>();
            var userChar = new List<UserCharacteristic>();
            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

            var userCh = new UserCharacteristic
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
            userChar.Add(userCh);
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

            Assert.Equal("Simona", userCh.FirstName);
            Assert.Equal("Kasabova", userCh.LastName);
            Assert.Equal(150, userCh.Weight);
            Assert.Equal(150, userCh.Height);
            Assert.Equal(City.Dobrich, userCh.City);
            Assert.Equal(Gender.Female, userCh.Gender);
            Assert.Equal(EyesColor.Brown, userCh.EyeColor);
            Assert.Equal(HairColor.Red, userCh.HairColor);
            Assert.Equal(WeddingStatus.Married, userCh.WeddingStatus);
            Assert.Equal(WhatAreYouSearchingFor.Flirt, userCh.WhatAreYouSearchingFor);
        }

        [Fact]
        public void GetIdShouldWorkCorrectly()
        {
            var photo = new List<Photo>();
            var userChar = new List<UserCharacteristic>();
            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

            var user = new UserCharacteristic
            {
                Id = "2",
            };

            userChar.Add(user);

            string userId = service.GetId("2");
            Assert.Equal("2", userId);
        }

        [Fact]
        public void IsUserDetailsPageShouldReturnTrue()
        {
            var photo = new List<Photo>();
            var userChar = new List<UserCharacteristic>();
            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var service = new ProfilesService(mockUserChar.Object, mockPhoto.Object);

            var user = new UserCharacteristic
            {
                Id = "1",
                UserId = "1",
            };

            userChar.Add(user);

            bool result = service.IsUserDetailsPage("1", "1");
            Assert.Equal(true, result);
        }

        [Fact]
        public void IsUserDetailsPageShouldReturnFalse()
        {
            var photo = new List<Photo>();
            var userChar = new List<UserCharacteristic>();
            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

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

            userChar.Add(user);
            userChar.Add(secondUser);

            bool result = service.IsUserDetailsPage("1", "2");
            Assert.Equal(false, result);
        }
    }
}
