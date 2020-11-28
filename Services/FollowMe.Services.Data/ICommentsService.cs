using System.Collections.Generic;
using System.Threading.Tasks;

using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Services.Data
{
    public interface ICommentsService
    {
        Task CreateAsync(string postId, string userId, string content);

        Task CreatePhotoCommentAsync(string photoId, string userId, string content, string currentUser);

        Task DeleteAsync(string commentId, string userId);

        Task DeletePhotoCommentAsync(string commentId, string userId);

        string GetPostIdByCommentId(string id);

        string GetPhotoIdByCommentId(string id);

        T EditView<T>(string commentId);

        Task EditMessageComment(string commentId, string content, string userId);

        bool IsUserCreatorOfComment(string commentId, string userId);

        IEnumerable<T> GetByUserId<T>(string id);
    }
}
