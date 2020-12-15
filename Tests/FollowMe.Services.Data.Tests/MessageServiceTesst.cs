namespace FollowMe.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using FollowMe.Data;
    using FollowMe.Data.Common.Repositories;
    using FollowMe.Data.Models;
    using FollowMe.Services.Mapping;
    using FollowMe.Web.ViewModels.Categories;
    using FollowMe.Web.ViewModels.Chats;
    using FollowMe.Web.ViewModels.Tests.Messages;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class MessageServiceTesst
    {
        public MessageServiceTesst()
        {
            AutoMapperConfig.RegisterMappings(typeof(ChatViewModel).GetTypeInfo().Assembly);
        }
        [Fact]
        public async Task DeleteFiftteenthCommentShouldWorkCorrectly()
        {
            var messages = new List<Message>();

            var mockMessRepo = new Mock<IRepository<Message>>();

            mockMessRepo.Setup(x => x.All()).Returns(messages.AsQueryable());
            mockMessRepo.Setup(x => x.AddAsync(It.IsAny<Message>())).Callback((Message message) => messages.Add(message));

            var service = new MessagesService(mockMessRepo.Object);

            var message = new Message
            {
                Id = 1,
                UserName = "Pesho",
                UserId = "1",
                Text = "Test",
                When = DateTime.UtcNow,
            };

            var secondMessage = new Message
            {
                Id = 2,
                UserName = "Gosho",
                UserId = "2",
                Text = "Test",
                When = DateTime.UtcNow,
            };

            var thirdMessage = new Message
            {
                Id = 3,
                UserName = "Nikola",
                UserId = "3",
                Text = "Test",
                When = DateTime.UtcNow,
            };

            messages.Add(thirdMessage);
            messages.Add(secondMessage);
            messages.Add(message);
            var success = service.DeleteFifteenthCommnet();
            Assert.True(success.IsCompleted);

        }

        [Fact]
        public async Task CreateMessageAsyncShouldWorkCorrectly()
        {
            var messages = new List<Message>();

            var mockMessRepo = new Mock<IRepository<Message>>();

            mockMessRepo.Setup(x => x.All()).Returns(messages.AsQueryable());
            mockMessRepo.Setup(x => x.AddAsync(It.IsAny<Message>())).Callback((Message message) => messages.Add(message));

            var service = new MessagesService(mockMessRepo.Object);

            await service.CreateMessageAsync("Toshko@abv.bg", "1", "I am a developer");
            var expectedResult = 1;
            Assert.Equal(expectedResult, messages.Count());
        }

        [Fact]
        public async Task GetAllMessagesCountShouldBe2()
        {
            var messages = new List<Message>();

            var mockMessRepo = new Mock<IRepository<Message>>();

            mockMessRepo.Setup(x => x.All()).Returns(messages.AsQueryable());
            mockMessRepo.Setup(x => x.AddAsync(It.IsAny<Message>())).Callback((Message message) => messages.Add(message));

            var service = new MessagesService(mockMessRepo.Object);

            await service.CreateMessageAsync("Toshko@abv.bg", "1", "I am a developer");
            await service.CreateMessageAsync("Toshkoo@abv.bg", "2", "I am a dancer");

            var messageCount = service.GetAll<MessageViewModel>();

            var expectedResult = 2;
            Assert.Equal(expectedResult, messageCount.Count());
        }
    }
}
