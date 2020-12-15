using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FollowMe.Data;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Tests.Comments;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace FollowMe.Services.Data.Tests
{
    public class CommentServiceTests
    {
        public CommentServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(CommentViewModel).GetTypeInfo().Assembly);
        }
        [Fact]
        public async Task CreateAsyncShouldWorkCorrectly()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            await service.CreateAsync("1", "1", "Are you crazy?");

            var expectedResult = 1;
            Assert.Equal(expectedResult, comments.Count());
        }

        [Fact]
        public async Task CreatePhotoCommentAsyncShouldWorkCorrectly()
        {
            var comments = new List<Comment>();
            var photos = new List<Photo>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photos.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photos.Add(ph));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, mockPhoto.Object, mockAppUser.Object);

            await service.CreatePhotoCommentAsync("1", "1", "Are you crazy?", "1");

            var expectedResult = 1;
            Assert.Equal(expectedResult, comments.Count());
        }

        [Fact]
        public async Task DeleteAsyncShouldReturnTrue()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var commentToDelete = new Comment
            {
                Id = "1",
                UserId = "1",
            };
            comments.Add(commentToDelete);
            await service.DeleteAsync("1", "1");

            Assert.Equal(true, commentToDelete.IsDeleted);

        }

        [Fact]
        public async Task DeleteAsyncShouldReturnFalse()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var commentToDelete = new Comment
            {
                Id = "1",
                UserId = "1",
            };
            comments.Add(commentToDelete);
            Task result = service.DeleteAsync("2", "1");

            Assert.True(result.IsFaulted);

        }

        [Fact]
        public async Task DeletePhotoCommentShouldReturnTrue()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToDelete = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
            };
            comments.Add(commentToDelete);
            await service.DeletePhotoCommentAsync("1", "1");

            Assert.Equal(true, commentToDelete.IsDeleted);

        }

        [Fact]
        public async Task DeletePhotoCommentShouldReturnFalse()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToDelete = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
            };
            comments.Add(commentToDelete);
            Task result = service.DeletePhotoCommentAsync("2", "1");

            Assert.True(result.IsFaulted);
        }

        [Fact]
        public async Task EditMessageCommentShouldWorkCorrectly()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToChangeContent = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Are you crazy",
            };
            comments.Add(commentToChangeContent);
            await service.EditMessageComment("1", "newContent", "1");

            var expectedResult = "newContent";
            Assert.Equal(expectedResult, commentToChangeContent.Content);
        }

        [Fact]
        public async Task EditMessageCommentShouldReturnFalse()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToChangeContent = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Are you crazy",
            };
            comments.Add(commentToChangeContent);
            Task result = service.EditMessageComment("1", "newContent", "2");

            Assert.False(result.IsFaulted);
        }

        [Fact]
        public async Task EditPhotoCommentShouldWorkCorrectly()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToChangeContent = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Are you crazy?",
            };
            comments.Add(commentToChangeContent);
            await service.EditPhotoComment("1", "newContent", "1");
            var expectedOutput = "newContent";
            Assert.Equal(expectedOutput, commentToChangeContent.Content);
        }

        [Fact]
        public async Task EditPhotoCommentShouldReturnFalse()
        {
            var comments = new List<Comment>();
            var appUsers = new List<ApplicationUser>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUsers.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUsers.Add(appU));

            var service = new CommentsService(mockCommentRepo.Object, null, mockAppUser.Object);

            var commentToChangeContent = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                Content = "Are you crazy?",
            };
            comments.Add(commentToChangeContent);
            Task result = service.EditPhotoComment("1", "newContent", "2");
            Assert.False(result.IsFaulted);
        }

        [Fact]
        public void GetCommentIdByPhotoIdShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Xaxaxa",
            };
            comments.Add(comment);
            var commentId = service.GetCommentIdByPhotoId("1");

            Assert.Equal(comment.Id, commentId);
        }

        [Fact]
        public void GetPhotoIdByCommentIdShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
            };
            comments.Add(comment);
            var photoId = service.GetPhotoIdByCommentId("1");

            Assert.Equal(comment.PhotoId, photoId);
        }

        [Fact]
        public void GetPostIdByCommentIdShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
                PostId = "1",
            };
            comments.Add(comment);
            var postId = service.GetPostIdByCommentId("1");

            Assert.Equal(comment.PostId, postId);
        }

        [Fact]
        public void IsUserCreatorOfCommentShouldReturnTrue()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
                PostId = "1",
            };
            comments.Add(comment);
            var result = service.IsUserCreatorOfComment("1", "1");

            Assert.Equal(true, result);
        }
        [Fact]
        public void IsUserCreatorOfCommentShouldReturnFalse()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
                PostId = "1",
            };
            comments.Add(comment);
            var result = service.IsUserCreatorOfComment("1", "2");

            Assert.Equal(false, result);
        }

        [Fact]
        public void IsUserCreatorOfPhotoCommentShouldReturnTrue()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
                PostId = "1",
            };
            comments.Add(comment);
            var result = service.IsUserCreatorOfPhotoComment("1", "1");

            Assert.Equal(true, result);
        }

        [Fact]
        public void IsUserCreatorOfPhotoCommentShouldReturnFalse()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                UserId = "1",
                SentById = "1",
                PhotoId = "1",
                Content = "Are you crazy?",
                PostId = "1",
            };
            comments.Add(comment);
            var result = service.IsUserCreatorOfPhotoComment("1", "2");

            Assert.Equal(false, result);
        }

        [Fact]
        public async Task GetByUserIdShouldReturnCount2()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                PhotoId = "1",
                Content = "Test",
            };
            var secondComment = new Comment
            {
                Id = "2",
                PhotoId = "1",
                Content = "Another test",
            };

            comments.Add(comment);
            comments.Add(secondComment);
            var countOfCommentsByUser = service.GetByUserId<CommentViewModel>("1");

            var expectedResult = 2;
            Assert.Equal(expectedResult, countOfCommentsByUser.Count());
        }

        [Fact]
        public async Task EditViewShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                PhotoId = "1",
                Content = "Test",
            };

            comments.Add(comment);

            var comm = service.EditView<CommentViewModel>("1");

            Assert.Equal(comment.Content, comm.Content);
        }

        [Fact]
        public async Task EditPhotoCommentViewShouldWorkCorrectly()
        {
            var comments = new List<Comment>();

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comments.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comments.Add(comm));

            var service = new CommentsService(mockCommentRepo.Object, null, null);

            var comment = new Comment
            {
                Id = "1",
                PhotoId = "1",
                Content = "Test",
            };

            comments.Add(comment);

            var comm = service.EditPhotoCommentView<CommentViewModel>("1");

            Assert.Equal(comment.Content, comm.Content);
        }
    }
}
