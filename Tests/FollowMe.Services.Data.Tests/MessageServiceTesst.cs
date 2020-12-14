namespace FollowMe.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FollowMe.Data;
    using FollowMe.Data.Common.Repositories;
    using FollowMe.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class MessageServiceTesst
    {
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
                Text = "Xaxaax",
                When = DateTime.UtcNow,
            };

            var secondMessage = new Message
            {
                Id = 2,
                UserName = "Gosho",
                UserId = "2",
                Text = "Xaxax",
                When = DateTime.UtcNow,
            };

            var thirdMessage = new Message
            {
                Id = 3,
                UserName = "Nikola",
                UserId = "3",
                Text = "Xaxax",
                When = DateTime.UtcNow,
            };

            messages.Add(thirdMessage);
            messages.Add(secondMessage);
            messages.Add(message);
            await service.DeleteFifteenthCommnet();
            Assert.Equal(2, messages.Count());

        }
    }
}
