﻿namespace FollowMe.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FollowMe.Data.Common.Repositories;
    using FollowMe.Data.Models;
    using Moq;
    using Xunit;

    public class VoteServiceTests
    {
        [Fact]
        public async Task WhenUserVoteTwoTimesOnlyOneVoteShouldBeCounted()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.VoteAsync("1", "1", false);
            await service.VoteAsync("1", "1", true);

            Assert.Equal(1, list.Count);
            Assert.Equal("UpVote", list.First().Type.ToString());
        }
        [Fact]

        public async Task WhenTwoUsersGiveUpVoteSumShouldbeEqualToTwo()
        {
            var list = new List<Vote>();
            var mockRepo = new Mock<IRepository<Vote>>();
            mockRepo.Setup(x => x.All()).Returns(list.AsQueryable());
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Vote>())).Callback((Vote vote) => list.Add(vote));

            var service = new VotesService(mockRepo.Object);

            await service.VoteAsync("1", "1", true);
            await service.VoteAsync("1", "2", true);

            var sum = service.GetVotes("1");

            Assert.Equal(2, sum);
        }
    }
}