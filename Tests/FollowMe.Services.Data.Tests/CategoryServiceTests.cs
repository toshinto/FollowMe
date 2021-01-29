using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Data.Repositories;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels;
using FollowMe.Web.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using FollowMe.Data.Models.Enum;

namespace FollowMe.Services.Data.Tests
{
    public class CategoryServiceTests
    {
        public CategoryServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(CategoryViewModel).GetTypeInfo().Assembly);
        }
        [Fact]
        public void GetRandomPeopleCountShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var categoryService = new CategoriesService(mockUserChar.Object);

            var user = new UserCharacteristic
            {
                Id = "1",
            };

            var secondUser = new UserCharacteristic
            {
                Id = "2",

            };
            userChars.Add(user);
            userChars.Add(secondUser);

            var expectedResult = 2;
            var randomPeople = categoryService.GetRandom<CategoryViewModel>();

            Assert.Equal(expectedResult, randomPeople.Count());
        }

        [Fact]
        public void GetBirthDaysPeopleCountShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var categoryService = new CategoriesService(mockUserChar.Object);

            var user = new UserCharacteristic
            {
                Id = "1",
                Date = DateTime.UtcNow,
            };

            var secondUser = new UserCharacteristic
            {
                Id = "2",
                Date = DateTime.UtcNow,
            };
            userChars.Add(user);
            userChars.Add(secondUser);

            var expectedResult = 2;
            var birthdayPeople = categoryService.GetBirhtdaysPeople<CategoryViewModel>();

            Assert.Equal(expectedResult, birthdayPeople.Count());
        }

        //[Fact]
        //public void GetTopMenCountShouldWorkCorrectly()
        //{
        //    var userChars = new List<UserCharacteristic>();
        //    var appUsers = new List<ApplicationUser>();
        //    var photos = new List<Photo>();

        //    var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
        //    mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
        //    mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

        //    var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
        //    mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
        //    mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

        //    var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
        //    mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
        //    mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

        //    var categoryService = new CategoriesService(mockUserChar.Object);

        //    var user = new UserCharacteristic
        //    {
        //        Id = "1",
        //        Gender = Gender.Male,
        //        PhotoId = "1",
        //    };

        //    var secondUser = new UserCharacteristic
        //    {
        //        Id = "2",
        //        Gender = Gender.Male,
        //        PhotoId = "1",
        //    };

        //    userChars.Add(user);
        //    userChars.Add(secondUser);

        //    var topMen = categoryService.GetTopMen<CategoryViewModel>();

        //    Assert.Equal(2, topMen.Count());
        //}

        //[Fact]
        //public void GetTopWomenCountShouldWorkCorrectly()
        //{
        //    var userChars = new List<UserCharacteristic>();
        //    var appUsers = new List<ApplicationUser>();
        //    var photos = new List<Photo>();

        //    var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
        //    mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
        //    mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

        //    var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
        //    mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
        //    mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

        //    var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
        //    mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
        //    mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

        //    var categoryService = new CategoriesService(mockUserChar.Object);

        //    var user = new UserCharacteristic
        //    {
        //        Id = "1",
        //        Gender = Gender.Female,
        //        PhotoId = "1",
        //    };

        //    var secondUser = new UserCharacteristic
        //    {
        //        Id = "2",
        //        Gender = Gender.Female,
        //        PhotoId = "1",
        //    };

        //    userChars.Add(user);
        //    userChars.Add(secondUser);

        //    var topWomen = categoryService.GetTopWomen<CategoryViewModel>();

        //    Assert.Equal(2, topWomen.Count());
        //}
    }
}
