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
        public async Task CreateAsycnShouldWorkCorrectly()
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

            await service.CreateAsync("1", "1", "asd");

            var commentToSearch = new Comment
            { 
                PostId = "1",
                UserId = "1",
                Content = "asd",
            };
            comment.Add(commentToSearch);

            Assert.Equal("1", commentToSearch.PostId);
            Assert.Equal("1", commentToSearch.UserId);
            Assert.Equal("asd", commentToSearch.Content);
        }

    }
}
