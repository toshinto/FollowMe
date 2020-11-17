using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface ICommentsService
    {
        Task CreateAsync(string postId, string userId, string content);

        Task DeleteAsync(string commentId, string userId);
    }
}
