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
    public class CommentServiceTests
    {
        [Fact]
        public async Task CreateAsyncShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            Task task = service.CreateAsync("1", "1", "1");

            Assert.True(task.IsCompleted);
        }

        [Fact]
        public async Task CreatePhotoCommentAsyncShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            Task task = service.CreatePhotoCommentAsync("1", "1", "asd", "1");

            Assert.True(task.IsCompleted);
        }

        [Fact]
        public async Task DeleteAsyncShouldReturnTrue()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
            };
            comment.Add(commentToCheck);
            await service.DeleteAsync("1", "1");

            Assert.Equal(true, commentToCheck.IsDeleted);

        }

        [Fact]
        public async Task DeleteAsyncShouldReturnFalse()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
            };
            comment.Add(commentToCheck);
            Task result = service.DeleteAsync("2", "1");

            Assert.True(result.IsFaulted);

        }

        [Fact]
        public async Task DeletePhotoCommentShouldReturnTrue()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
            };
            comment.Add(commentToCheck);
            await service.DeletePhotoCommentAsync("1", "1");

            Assert.Equal(true, commentToCheck.IsDeleted);

        }

        [Fact]
        public async Task DeletePhotoCommentShouldReturnFalse()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
            };
            comment.Add(commentToCheck);
            Task result = service.DeletePhotoCommentAsync("2", "1");

            Assert.True(result.IsFaulted);
        }

        [Fact]
        public async Task EditMessageCommentShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Xaxaxa",
            };
            comment.Add(commentToCheck);
            await service.EditMessageComment("1", "newContent", "1");

            Assert.Equal("newContent", commentToCheck.Content);
        }

        [Fact]
        public async Task EditPhotoCommentShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Xaxaxa",
            };
            comment.Add(commentToCheck);
            await service.EditPhotoComment("1", "newContent", "1");

            Assert.Equal("newContent", commentToCheck.Content);
        }

        [Fact]
        public async Task GetCommentIdByPhotoIdShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
            };
            comment.Add(commentToCheck);
            var commentId = service.GetCommentIdByPhotoId("1");

            Assert.Equal(commentToCheck.Id, commentId);
        }

        [Fact]
        public async Task GetPhotoIdByCommentIdShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
            };
            comment.Add(commentToCheck);
            var photoId = service.GetPhotoIdByCommentId("1");

            Assert.Equal(commentToCheck.PhotoId, photoId);
        }

        [Fact]
        public async Task GetPostIdByCommentIdShouldWorkCorrectly()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
                PostId = "1",
            };
            comment.Add(commentToCheck);
            var postId = service.GetPostIdByCommentId("1");

            Assert.Equal(commentToCheck.PostId, postId);
        }

        [Fact]
        public async Task IsUserCreatorOfCommentShouldReturnTrue()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
                PostId = "1",
            };
            comment.Add(commentToCheck);
            var result = service.IsUserCreatorOfComment("1", "1");

            Assert.Equal(true, result);
        }
        [Fact]
        public async Task IsUserCreatorOfCommentShouldReturnFalse()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
                PostId = "1",
            };
            comment.Add(commentToCheck);
            var result = service.IsUserCreatorOfComment("1", "2");

            Assert.Equal(false, result);
        }

        [Fact]
        public async Task IsUserCreatorOfPhotoCommentShouldReturnTrue()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
                PostId = "1",
            };
            comment.Add(commentToCheck);
            var result = service.IsUserCreatorOfPhotoComment("1", "1");

            Assert.Equal(true, result);
        }

        [Fact]
        public async Task IsUserCreatorOfPhotoCommentShouldReturnFalse()
        {
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var commentToCheck = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
                PostId = "1",
            };
            comment.Add(commentToCheck);
            var result = service.IsUserCreatorOfPhotoComment("1", "2");

            Assert.Equal(false, result);
        }
    }
}
