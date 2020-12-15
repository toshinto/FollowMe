using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels;
using FollowMe.Web.ViewModels.Admins;
using FollowMe.Web.ViewModels.Tests.Admins;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class AdminServiceTests
    {
        public AdminServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public void GetCountOfUsersShouldWorkCorrectly()
        {
            var userChars = new List<UserCharacteristic>();

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var service = new AdminsService(null, null, null, mockUserChar.Object, null);

            var user = new UserCharacteristic
            {
                Id = "1",
            };
            userChars.Add(user);

            var expectedResult = 1;
            var result = service.GetCountOfUsers();

            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GetCountOfPostsShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new AdminsService(mockPostRepo.Object, null, null, null, null);

            var post = new Post
            {
                Id = "1",
                Title = "Can you help me",
                Content = "I am 16 yo and...",
            };

            posts.Add(post);
            var result = service.GetCountOfPosts();
            var expectedResult = 1;

            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GetCountOfPhotosShouldWorkCorrectly()
        {
            var photos = new List<Photo>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var service = new AdminsService(null, null, mockPhoto.Object, null, null);

            var photo = new Photo
            {
                Id = "1",
                ImagePath = "/images/photos",

            };
            photos.Add(photo);
            var expectedResult = 1;
            var result = service.GetCountOfPhotos();
            Assert.Equal(expectedResult, result);

        }
        [Fact]
        public void GetCountOfPhotosCommentsShouldWorkCorrectly()
        {
            var comments = new List<Comment>();
            var photos = new List<Photo>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var service = new AdminsService(null, mockCommentRepo.Object, mockPhoto.Object, null, null);

            var photo = new Photo
            {
                Id = "1",
                ImagePath = "/images/photos",
            };
            var comment = new Comment
            {
                Id = "1",
                ImagePath = "/images/photos",
                PhotoId = "1",
                UserId = "1",
                SentById = "1",

            };
            var secondComment = new Comment
            {
                Id = "2",
                ImagePath = "/images/photos",
                PhotoId = "1",
                UserId = "1",
                SentById = "1",
            };

            photos.Add(photo);
            comments.Add(comment);
            comments.Add(secondComment);

            var result = service.GetCountOfPhotosComments();
            var expectedResult = 2;

            Assert.Equal(expectedResult, result);

        }
        [Fact]

        public async Task DeleteCommentShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new AdminsService(null, mockCommentRepo.Object, null, null, null);

            var newComment = new Comment
            {
                Id = "123",
                Content = "You are sick",
                PhotoId = "1",
                IsDeleted = false,
            };

            comments.Add(newComment);
            await service.DeleteComment("123");
            Assert.Equal(true, newComment.IsDeleted);
        }

        [Fact]

        public async Task DeletePhotoShouldWorkCorrectly()
        {
            var photos = new List<Photo>();

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var service = new AdminsService(null, null, mockPhoto.Object, null, null);

            var photo = new Photo
            {
                Id = "123",
            };

            photos.Add(photo);
            await service.DeletePhoto("123");
            Assert.Equal(true, photo.IsDeleted);
        }

        [Fact]

        public async Task DeletePostShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post ps) => posts.Add(ps));

            var service = new AdminsService(mockPostRepo.Object, null, null, null, null);

            var postToDelete = new Post
            {
                Id = "123",
            };

            posts.Add(postToDelete);
            await service.DeletePost("123");
            Assert.Equal(true, postToDelete.IsDeleted);
        }

        [Fact]

        public async Task DeleteUserShouldWorkCorrectly()
        {
            var appUsers = new List<ApplicationUser>();

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(null, null, null, null, mockAppUser.Object);

            var user = new ApplicationUser
            {
                Id = "123",
            };

            appUsers.Add(user);
            await service.DeleteUser("123");
            Assert.Equal(true, user.IsDeleted);
        }
    }
}
