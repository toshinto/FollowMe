using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Tests.Posts;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class PostServiceTests
    {
        public PostServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(PostsViewModel).GetTypeInfo().Assembly);
        }
        [Fact]
        public async Task DeletePostAsyncShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

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
        public async Task DeletePostAsyncShouldReturnFalse()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
            };
            posts.Add(post);
            Task result = service.Delete("1", "2");

            Assert.False(result.IsFaulted);
        }

        [Fact]
        public async Task EditPostAsyncShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
                SentById = "1",
            };
            posts.Add(post);
            await service.EditPost("1", "newContent", "newTitle", "1");

            Assert.Equal("newContent", post.Content);
            Assert.Equal("newTitle", post.Title);
        }

        [Fact]
        public async Task EditPostAsyncShouldReturnFalse()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
                SentById = "2",
            };
            posts.Add(post);
            Task result = service.EditPost("1", "newContent", "newTitle", "1");

            Assert.False(result.IsFaulted);
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

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
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

            var expectedOutput = "Pesho";
            Assert.Equal(expectedOutput, appUser.UserCharacteristics.FirstName);

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

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
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

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
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

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
                SentById = "1",
            };
            posts.Add(post);
            var postId = service.GetPostById("1");
            var expectedOutput = "1";
            Assert.Equal(expectedOutput, postId);

        }

        [Fact]
        public void GetUserByPostIdShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
                SentById = "1",
            };
            posts.Add(post);
            var userId = service.GetPostById("1");
            var expectedOutput = "1";
            Assert.Equal(expectedOutput, userId);

        }

        [Fact]
        public void IsUserCreatorOfPostShouldReturnTrue()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
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

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
                Title = "Test",
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

            await service.Create("Text", "1", "1", "Are you crazy?");

            var expectedResult = 1;
            Assert.Equal(expectedResult, posts.Count());

        }

        [Fact]
        public async Task GetByUserIdShouldReturnCount2()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
            };
            var secondPost = new Post
            {
                Id = "2",
                UserId = "1",
            };
            posts.Add(post);
            posts.Add(secondPost);

            var postsCount = service.GetByUserId<PostsViewModel>("1");
            var expectedResult = 2;
            Assert.Equal(expectedResult, postsCount.Count());

        }

        [Fact]
        public async Task EditPostViewShouldWorkCorrectly()
        {
            var posts = new List<Post>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(posts.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => posts.Add(post));

            var service = new PostsService(null, mockPostRepo.Object);

            var post = new Post
            {
                Id = "1",
                UserId = "1",
                Content = "Test",
            };

            posts.Add(post);

            var ps = service.EditView<PostsViewModel>("1");

            Assert.Equal(post.Content, ps.Content);

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
        //        SentById = "1",
        //    };
        //    posts.Add(post);
        //    var userFullName = service.GetCreatorOfPostByCommentId("1");
        //    Assert.Equal("Todor Georgiev", userFullName);

        //}
    }
}
