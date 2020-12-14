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

        public void GetAllPostsCountShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var adminsService = new AdminsService(mockPostRepo.Object, null, null, null, null);

            var user = new ApplicationUser
            {
                Id = "1",
                UserName = "Pesho",
            };

            var secondUser = new ApplicationUser
            {
                Id = "2",
                UserName = "Gosho",
            };

            appUsers.Add(user);
            appUsers.Add(secondUser);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Xaxa",
            };

            var secondPost = new Post
            {
                Id = "2",
                UserId = "2",
                SentById = "2",
                Content = "Xaxa",
            };

            posts.Add(post);
            posts.Add(secondPost);

            var allPosts = adminsService.GetAllPosts<PostsViewModel>(2, 12);

            Assert.Equal(2, allPosts.Count());

        }
        [Fact]
        public void GetCountOfUsersShouldWorkCorrectly()
        {
            var user = new UserCharacteristic
            {
                Id = "1",
            };

            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            userChars.Add(user);

            var result = service.GetCountOfUsers();

            Assert.Equal(1, result);

        }

        [Fact]
        public void GetCountOfPostsShouldWorkCorrectly()
        {
            var post = new Post
            {
                Id = "1",
                Title = "Can you help me",
                Content = "I am 16 yo and...",
            };

            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
            posts.Add(post);
            var result = service.GetCountOfPosts();
            var expectedResult = 1;

            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void GetCountOfPhotosShouldWorkCorrectly()
        {
            var photo = new Photo
            {
                Id = "1",
                ImagePath = "/images/photos",

            };

            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Photos.Add(photo);
            dbContext.SaveChanges();
            photos.Add(photo);
            var expectedResult = 1;
            var result = service.GetCountOfPhotos();
            Assert.Equal(expectedResult, result);

        }
        [Fact]
        public void GetCountOfPhotosCommentsShouldWorkCorrectly()
        {
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

            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

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
            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var newComment = new Comment
            {
                Id = "123",
                Content = "xaxaxa",
                PhotoId = "1",
                IsDeleted = false,
            };
            dbContext.Comments.Add(newComment);
            dbContext.SaveChanges();
            comments.Add(newComment);
            await service.DeleteComment("123");
            Assert.Equal(true, newComment.IsDeleted);
        }

        [Fact]

        public async Task DeletePhotoShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var photo = new Photo
            {
                Id = "123",
            };
            dbContext.Photos.Add(photo);
            dbContext.SaveChanges();
            photos.Add(photo);
            await service.DeletePhoto("123");
            Assert.Equal(true, photo.IsDeleted);
        }

        [Fact]

        public async Task DeletePostShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post ps) => posts.Add(ps));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var postToDelete = new Post
            {
                Id = "123",
            };
            dbContext.Posts.Add(postToDelete);
            dbContext.SaveChanges();
            posts.Add(postToDelete);
            await service.DeletePost("123");
            Assert.Equal(true, postToDelete.IsDeleted);
        }

        [Fact]

        public async Task DeleteUserShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();
            var userChars = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post ps) => posts.Add(ps));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChars.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChars.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var user = new ApplicationUser
            {
                Id = "123",
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            appUsers.Add(user);
            await service.DeleteUser("123");
            Assert.Equal(true, user.IsDeleted);
        }
    }
}
