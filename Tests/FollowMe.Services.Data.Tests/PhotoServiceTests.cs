﻿using System;
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

            var photoToCheck = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            photos.Add(photoToCheck);
            await service.DeleteAsync("1", "1");

            Assert.Equal(true, photoToCheck.IsDeleted);
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

            var photoToCheck = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            photos.Add(photoToCheck);
            var userId = service.GetUserByPhotoId("1");

            Assert.Equal("1", userId);
        }

        [Fact]
        public void GetFirstNameByIdShouldReturnFalse()
        {
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChar = new List<UserCharacteristic>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var service = new PhotosService(mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photoToCheck = new Photo
            {
                Id = "1",
                UserId = "1",
            };
            var appUser = new ApplicationUser
            {
                Id = "1",
            };
            var userCh = new UserCharacteristic
            {
                Id = "1",
                FirstName = "Xaxax",
            };
            photos.Add(photoToCheck);
            appUsers.Add(appUser);
            userChar.Add(userCh);
            dbContext.Users.Add(appUser);
            dbContext.Photos.Add(photoToCheck);
            userCh.FirstName = "xaxaxa";
            var userId = service.GetFirstNameById("1");

            Assert.Equal(false, userId);
        }
    }
}
