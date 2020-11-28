﻿using System.Collections.Generic;
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
    }
}
