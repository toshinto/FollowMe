﻿using System.Threading.Tasks;

using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Services.Data
{
    public interface ICommentsService
    {
        Task CreateAsync(string postId, string userId, string content);

        Task DeleteAsync(string commentId, string userId);

        string GetPostIdByCommentId(string id);

        T EditView<T>(string commentId);

        Task EditMessageComment(string commentId, string content);
    }
}
