using System.Collections.Generic;
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
        private readonly IDeletableEntityRepository<Photo> photosRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository, IDeletableEntityRepository<Photo> photosRepository)
        {
            this.commentsRepository = commentsRepository;
            this.photosRepository = photosRepository;
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

        public async Task CreatePhotoCommentAsync(string photoId, string userId, string content, string currentUser)
        {
            var comment = new Comment
            {
                PhotoId = photoId,
                UserId = userId,
                Content = content,
                SentById = currentUser,
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

        public async Task DeletePhotoCommentAsync(string commentId, string userId)
        {
            var comment = this.commentsRepository.All().Where(c => c.Id == commentId).FirstOrDefault();
            if (comment.SentById == userId)
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

        public async Task EditPhotoComment(string commentId, string content, string userId)
        {
            var comment = this.commentsRepository.All().Where(p => p.Id == commentId).FirstOrDefault();
            if (comment.SentById != userId)
            {
                return;
            }
            comment.Content = content;

            await this.commentsRepository.SaveChangesAsync();
        }

        public T EditPhotoCommentView<T>(string photoId)
        {
            var photoComment = this.commentsRepository.All()
                .Where(x => x.PhotoId == photoId)
                .To<T>().FirstOrDefault();
            return photoComment;
        }

        public T EditView<T>(string commentId)
        {
            var comment = this.commentsRepository.All()
                   .Where(x => x.Id == commentId)
                   .To<T>().FirstOrDefault();
            return comment;
        }

        public IEnumerable<T> GetByUserId<T>(string id)
        {
            var comments = this.commentsRepository.All().Where(x => x.PhotoId == id).OrderByDescending(x => x.CreatedOn);

            return comments.To<T>().ToList();
        }

        public string GetCommentIdByPhotoId(string photoId)
        {
            var commentId = this.commentsRepository.All().Where(p => p.PhotoId == photoId).Select(c => c.Id).FirstOrDefault();
            return commentId;
        }

        public string GetPhotoIdByCommentId(string id)
        {
            var photoId = this.commentsRepository.All().Where(x => x.Id == id).Select(p => p.PhotoId).FirstOrDefault();
            return photoId;
        }

        public string GetPostIdByCommentId(string id)
        {
            var postId = this.commentsRepository.All().Where(c => c.Id == id).Select(p => p.PostId).FirstOrDefault();
            return postId;
        }

        public bool IsUserCreatorOfComment(string commentId, string userId)
        {
            var comment = this.commentsRepository.All().Where(x => x.Id == commentId).FirstOrDefault();
            if (comment.UserId == userId)
            {
                return true;
            }

            return false;
        }

        public bool IsUserCreatorOfPhotoComment(string commentId, string userId)
        {
            var comment = this.commentsRepository.All().Where(x => x.Id == commentId).FirstOrDefault();
            if (comment.SentById == userId)
            {
                return true;
            }

            return false;
        }
    }
}
