using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class PhotoServiceTests
    {
        [Fact]
        public async Task DeletePhotoAsyncShouldWorkCorrectly()
        {
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PhotosService(mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photo = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            photos.Add(photo);
            await service.DeleteAsync("1", "1");

            Assert.Equal(true, photo.IsDeleted);
        }

        [Fact]
        public void GetUserByPhotoIdShouldWorkCorrectly()
        {
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PhotosService(mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photo = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            photos.Add(photo);
            var userId = service.GetUserByPhotoId("1");

            Assert.Equal("1", userId);
        }

        [Fact]
        public void GetFirstNameByIdShouldReturnFalse()
        {
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new PhotosService(mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photo = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            var appUser = new ApplicationUser
            {
                Id = "1",
                UserCharacteristics = new UserCharacteristic
                {
                    Id = "1",
                    FirstName = "Pesho",
                },
            };
            var secondAppUser = new ApplicationUser
            {
                Id = "2",
            };

            photos.Add(photo);
            appUsers.Add(appUser);
            var result = service.GetFirstNameById("2");

            Assert.Equal(false, result);
        }

        [Fact]
        public void GetFirstNameByIdShouldReturnTrue()
        {
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new PhotosService(mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photo = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            var appUser = new ApplicationUser
            {
                Id = "1",
                UserCharacteristics = new UserCharacteristic
                {
                    Id = "1",
                    FirstName = "Pesho",
                },
            };
            var secondAppUser = new ApplicationUser
            {
                Id = "2",
            };

            photos.Add(photo);
            appUsers.Add(appUser);
            var result = service.GetFirstNameById("1");

            Assert.Equal(true, result);
        }
    }
}
