using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IAdminsService
    {
        IEnumerable<T> GetAllPosts<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllPhotoComments<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllPhotos<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllUsers<T>(int page, int itemsPerPage);

        int GetCountOfUsers();

        int GetCountOfPhotos();

        int GetCountOfPosts();

        int GetCountOfPhotosComments();

        Task DeletePost(string postId);

        Task DeleteComment(string commentId);

        Task DeletePhoto(string photoId);

        Task DeleteUser(string userId);
    }
}
