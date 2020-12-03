using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IAdminsService
    {
        IEnumerable<T> GetAllPosts<T>();

        Task DeletePost(string postId);
    }
}
