using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Posts;

namespace FollowMe.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Post> postsRepository)
        {
            this.usersRepository = usersRepository;
            this.postsRepository = postsRepository;
        }

        public async Task Create(string content, string userId, string sentBy, string title)
        {
            var user = this.usersRepository.All().Where(x => x.Id == sentBy).Select(x => x.UserCharacteristics.Photo.Id + "." + x.UserCharacteristics.Photo.Extension).FirstOrDefault();
            var post = new Post
            {
                Content = content,
                UserId = userId,
                SentById = sentBy,
                Title = title,
                CreatedOn = DateTime.UtcNow,
                ImagePath = "/images/photos/" + user,
            };
            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task Delete(string postId, string userId)
        {
            var post = this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefault();
            if (post.SentById == userId || post.UserId == userId)
            {
                post.IsDeleted = true;
            }
            else
            {
                return;
            }

            await this.postsRepository.SaveChangesAsync();
        }

        public async Task EditPost(string postId, string content, string title, string userId)
        {
            var post = this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefault();
            if (post.SentById != userId)
            {
                return;
            }
            post.Content = content;
            post.Title = title;
            await this.postsRepository.SaveChangesAsync();
        }

        public T EditView<T>(string postId)
        {
            var post = this.postsRepository.All()
                   .Where(x => x.Id == postId)
                   .To<T>().FirstOrDefault();
            return post;
        }

        public IEnumerable<T> GetByUserId<T>(string id)
        {
            var posts = this.postsRepository.All().Where(x => x.UserId == id).OrderByDescending(x => x.CreatedOn);

            return posts.To<T>().ToList();
        }

        public bool GetFirstNameById(string userId)
        {
            var userFirstName = this.usersRepository.All().Where(x => x.Id == userId).Select(s => s.UserCharacteristics.FirstName).FirstOrDefault();
            if (userFirstName != null)
            {
                return true;
            }
            return false;
        }

        public string GetNameById(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).Select(x => x.UserCharacteristics.FullName).FirstOrDefault();
            return user;
        }

        public string GetPostById(string id)
        {
            var post = this.postsRepository.All().Where(x => x.Id == id).Select(x => x.Id).FirstOrDefault();
            return post;
        }

        public string GetCreatorOfPostByCommentId(string id)
        {
            var userFullName = this.postsRepository.All().Where(x => x.Id == id).Select(x => x.SentBy.UserCharacteristics.FullName).FirstOrDefault();
            return userFullName;
        }

        public string GetUserByPostId(string postId)
        {
            var userId = this.postsRepository.All().Where(x => x.Id == postId).Select(x => x.UserId).FirstOrDefault();
            return userId;
        }

        public bool IsUserCreatorOfPost(string postId, string userId)
        {
            var post = this.postsRepository.All().Where(p => p.Id == postId).FirstOrDefault();
            if (post.SentById == userId)
            {
                return true;
            }

            return false;
        }
    }
}
