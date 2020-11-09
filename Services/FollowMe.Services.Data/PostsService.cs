using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using System.Linq;

namespace FollowMe.Services.Data
{
    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public PostsService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public string GetNameById(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).Select(x => x.UserName).FirstOrDefault();
            return user;
        }
    }
}
