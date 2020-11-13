using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IVotesService
    {
        Task VoteAsync(string postId, string userId, bool isUpVote);

        string GetVotes(string postId);
    }
}
