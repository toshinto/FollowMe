using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IPostsService
    {
        string GetNameById(string userId);

        Task Create(string content, string userId, string sentBy, string title);

        Task Delete(string postId, string userId);

        IEnumerable<T> GetByUserId<T>(string id);

        string GetPostById(string id);

        string GetUserByPostId(string postId);

        T EditView<T>(string postId);
    }
}
