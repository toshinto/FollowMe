using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

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
            var post = new Post
            {
                Content = content,
                UserId = userId,
                SentById = sentBy,
                Title = title,
                CreatedOn = DateTime.UtcNow,
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

        public string GetUserByPostId(string postId)
        {
            var userId = this.postsRepository.All().Where(x => x.Id == postId).Select(x => x.UserId).FirstOrDefault();
            return userId;
        }
    }
}
