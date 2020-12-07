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

        IEnumerable<T> GetAllPhotos<T>();

        IEnumerable<T> GetAllUsers<T>(int page, int itemsPerPage);

        int GetCountOfUsers();

        Task DeletePost(string postId);

        Task DeleteComment(string commentId);

        Task DeletePhoto(string photoId);

        Task DeleteUser(string userId);
    }
}
