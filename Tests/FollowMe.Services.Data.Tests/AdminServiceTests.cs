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
    public class AdminServiceTests
    {
        [Fact]
        public void GetCountOfUsers()
        {
            var user = new ApplicationUser
            {
                Id = "1",
                Email = "test@abv.bg",
            };
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            var expectedResult = 1;

            Assert.Equal(expectedResult, dbContext.Users.Count());

        }

        [Fact]
        public void GetCountOfPosts()
        {
            var post = new Post
            {
                Id = "1",
                Title = "Can you help me",
                Content = "I am 16 yo and...",
            };
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();

            var expectedResult = 1;

            Assert.Equal(expectedResult, dbContext.Posts.Count());

        }

        [Fact]
        public void GetCountOfPhotos()
        {
            var photo = new Photo
            {
                Id = "1",
                ImagePath = "/images/photos",

            };
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Photos.Add(photo);
            dbContext.SaveChanges();

            var expectedResult = 1;

            Assert.Equal(expectedResult, dbContext.Photos.Count());

        }
        [Fact]
        public void GetCountOfPhotosComments()
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

            };
            var secondComment = new Comment
            {
                Id = "2",
                ImagePath = "/images/photos",
                PhotoId = "1",
            };
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            dbContext.Photos.Add(photo);
            dbContext.Comments.Add(comment);
            dbContext.Comments.Add(secondComment);
            dbContext.SaveChanges();

            var expectedResult = 2;

            Assert.Equal(expectedResult, dbContext.Photos.Sum(x => x.Comments.Count()));

        }
        [Fact]

        public async Task DeleteComment()
        {
            var list = new List<Post>();
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();
            var userChar = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => list.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

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
            comment.Add(newComment);
            await service.DeleteComment("123");
            Assert.Equal(true, newComment.IsDeleted);
        }

        [Fact]

        public async Task DeletePhoto()
        {
            var list = new List<Post>();
            var comment = new List<Comment>();
            var photo = new List<Photo>();
            var appUser = new List<ApplicationUser>();
            var userChar = new List<UserCharacteristic>();

            var mockPostRepo = new Mock<IDeletableEntityRepository<Post>>();
            mockPostRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockPostRepo.Setup(x => x.AddAsync(It.IsAny<Post>())).Callback((Post post) => list.Add(post));

            var mockCommentRepo = new Mock<IDeletableEntityRepository<Comment>>();
            mockCommentRepo.Setup(x => x.All()).Returns(comment.AsQueryable());
            mockCommentRepo.Setup(x => x.AddAsync(It.IsAny<Comment>())).Callback((Comment comm) => comment.Add(comm));

            var mockPhoto = new Mock<IDeletableEntityRepository<Photo>>();
            mockPhoto.Setup(x => x.All()).Returns(photo.AsQueryable());
            mockPhoto.Setup(x => x.AddAsync(It.IsAny<Photo>())).Callback((Photo ph) => photo.Add(ph));

            var mockUserChar = new Mock<IDeletableEntityRepository<UserCharacteristic>>();
            mockUserChar.Setup(x => x.All()).Returns(userChar.AsQueryable());
            mockUserChar.Setup(x => x.AddAsync(It.IsAny<UserCharacteristic>())).Callback((UserCharacteristic uc) => userChar.Add(uc));

            var mockAppUser = new Mock<IDeletableEntityRepository<ApplicationUser>>();
            mockAppUser.Setup(x => x.All()).Returns(appUser.AsQueryable());
            mockAppUser.Setup(x => x.AddAsync(It.IsAny<ApplicationUser>())).Callback((ApplicationUser appU) => appUser.Add(appU));

            var service = new AdminsService(mockPostRepo.Object, mockCommentRepo.Object, mockPhoto.Object, mockUserChar.Object, mockAppUser.Object);

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var ph = new Photo
            {
                Id = "123",
                IsDeleted = false,
            };
            dbContext.Photos.Add(ph);
            dbContext.SaveChanges();

            await service.DeleteComment("123");
            Assert.Equal(false, ph.IsDeleted);
        }
    }
}
