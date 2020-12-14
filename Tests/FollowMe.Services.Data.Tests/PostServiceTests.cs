using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class PostServiceTests
    {
        [Fact]
        public async Task DeletePostAsyncShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
            };
            posts.Add(post);
            await service.Delete("1", "1");

            Assert.Equal(true, post.IsDeleted);
        }

        [Fact]
        public async Task EditPostAsyncShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            await service.EditPost("1", "newContent", "newTitle", "1");

            Assert.Equal("newContent", post.Content);
            Assert.Equal("newTitle", post.Title);
        }

        [Fact]
        public void GetNameByIdShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var appUser = new ApplicationUser
            {
                Id = "1",
                UserCharacteristics = new UserCharacteristic
                {
                  FirstName = "Pesho",
                },
            };
            appUsers.Add(appUser);

            var userName = service.GetNameById("1");
            Assert.Equal("Pesho", appUser.UserCharacteristics.FirstName);

        }

        [Fact]
        public void GetFirstNameByIdShouldReturnTrue()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var appUser = new ApplicationUser
            {
                Id = "1",
                UserCharacteristics = new UserCharacteristic
                {
                    FirstName = "Pesho",
                },
            };
            appUsers.Add(appUser);

            var result = service.GetFirstNameById("1");
            Assert.Equal(true, result);

        }

        [Fact]
        public void GetFirstNameByIdShouldReturnFalse()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var appUser = new ApplicationUser
            {
                Id = "1",
                UserCharacteristics = new UserCharacteristic
                {
                    FirstName = "Pesho",
                },
            };
            var secondAppUser = new ApplicationUser
            {
                Id = "2",
            };
            appUsers.Add(appUser);

            var result = service.GetFirstNameById("2");
            Assert.Equal(false, result);

        }

        [Fact]
        public void GetPostByIdShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var postId = service.GetPostById("1");
            Assert.Equal("1", postId);

        }

        //[Fact]
        //public void GetCreatorOfPostByCommentIdShouldWorkCorrectly()
        //{
        //    var posts = new List<Post>();
        //    var appUsers = new List<ApplicationUser>();

        //    var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
        //    mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
        //    mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

        //    var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
        //    mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
        //    mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

        //    var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

        //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
        //       .UseInMemoryDatabase("test");
        //    var dbContext = new ApplicationDbContext(optionsBuilder.Options);

        //    var post = new Post
        //    {
        //        Id = "1",
        //        UserId = "1",
        //        Content = "xaxa",
        //        Title = "xaxaa",
        //        SentById = "1",
        //    };

        //    posts.Add(post);
        //    var appUser = new ApplicationUser
        //    {
        //        Id = "1",
        //        UserCharacteristics = new UserCharacteristic
        //        {
        //            Id = "1",
        //            FirstName = "Pesho",
        //            LastName = "Pesho",
        //        },
        //    };

        //    appUsers.Add(appUser);
        //    var userFullName = service.GetCreatorOfPostByCommentId("1");
        //    Assert.Equal("Pesho Pesho", userFullName);

        //}
        [Fact]
        public void GetUserByPostIdShouldWorkCorrectly()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var userId = service.GetPostById("1");
            Assert.Equal("1", userId);

        }

        [Fact]
        public void IsUserCreatorOfPostShouldReturnTrue()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "1",
            };
            posts.Add(post);
            var result = service.IsUserCreatorOfPost("1", "1");
            Assert.Equal(true, result);

        }

        [Fact]
        public void IsUserCreatorOfPostShouldReturnFalse()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "xaxa",
                Title = "xaxaa",
                SentById = "2",
            };
            posts.Add(post);
            var result = service.IsUserCreatorOfPost("1", "1");
            Assert.Equal(false, result);

        }

        [Fact]
        public async Task PhotoCreateCountShouldBeOne()
        {
            var posts = new List<Post>();
            var appUsers = new List<ApplicationUser>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new PostsService(mockAppUser.Object, mockPostRepo.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            await service.Create("Text", "1", "1", "Are you crazy>");

            Assert.Equal(1, posts.Count());

        }
    }
}
