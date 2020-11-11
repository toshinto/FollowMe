using System;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;

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

        public async Task Create(string content, string userId)
        {
            var post = new Post
            {
                Content = content,
                UserId = userId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();
        }

        public string GetNameById(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).Select(x => x.UserCharacteristics.FullName).FirstOrDefault();
            return user;
        }
    }
}
