using System.Threading.Tasks;

using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Services.Data
{
    public interface ICommentsService
    {
        Task CreateAsync(string postId, string userId, string content);

        Task DeleteAsync(string commentId, string userId);

        string GetPostIdByCommentId(string id);

        T Edit<T>(string commentId);
    }
}
