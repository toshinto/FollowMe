using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;

namespace FollowMe.Services.Data
{
    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public int GetVotes(string postId)
        {
            var votes =
                this.votesRepository
                .All()
                .Where(x => x.PostId == postId)
                .Sum(x => (int)x.Type);

            return votes;
        }

        public async Task VoteAsync(string postId, string userId, bool isUpVote)
        {
            var vote =
                this.votesRepository
                .All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);

            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.votesRepository.AddAsync(vote);
            }

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
