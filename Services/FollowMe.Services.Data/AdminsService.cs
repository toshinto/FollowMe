using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Services.Data
{
    public class AdminsService : IAdminsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public AdminsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task DeletePost(string postId)
        {
            var postToDelete = this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefault();
            postToDelete.IsDeleted = true;
            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.postsRepository.All().OrderByDescending(x => x.CreatedOn);
            return posts.To<T>().ToList();
        }
    }
}
