using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IAdminsService
    {
        IEnumerable<T> GetAllPosts<T>();

        IEnumerable<T> GetAllPhotoComments<T>();

        Task DeletePost(string postId);

        Task DeleteComment(string commentId);
    }
}
