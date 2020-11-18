using System.Linq;
using System.Threading.Tasks;

using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Services.Data
{
    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }
        public async Task CreateAsync(string postId, string userId, string content)
        {
            var comment = new Comment
            {
                PostId = postId,
                UserId = userId,
                Content = content,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string commentId, string userId)
        {
            var comment = this.commentsRepository.All().Where(c => c.Id == commentId).FirstOrDefault();
            if (comment.UserId == userId)
            {
                comment.IsDeleted = true;
            }
            else
            {
                return;
            }

            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task EditMessageComment(string commentId, string content, string userId)
        {
            var comment = this.commentsRepository.All().Where(x => x.Id == commentId).FirstOrDefault();
            if (comment.UserId != userId)
            {
                return;
            }
            comment.Content = content;
            await this.commentsRepository.SaveChangesAsync();
        }

        public T EditView<T>(string commentId)
        {
            var comment = this.commentsRepository.All()
                   .Where(x => x.Id == commentId)
                   .To<T>().FirstOrDefault();
            return comment;
        }

        public string GetPostIdByCommentId(string id)
        {
            var postId = this.commentsRepository.All().Where(c => c.Id == id).Select(p => p.PostId).FirstOrDefault();
            return postId;
        }

        public bool IsUserComment(string commentId, string userId)
        {
            var comment = this.commentsRepository.All().Where(x => x.Id == commentId).FirstOrDefault();
            if (comment.UserId == userId)
            {
                return true;
            }

            return false;
        }
    }
}
