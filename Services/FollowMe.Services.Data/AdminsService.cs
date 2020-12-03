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
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public AdminsService(IDeletableEntityRepository<Post> postsRepository, IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.postsRepository = postsRepository;
            this.commentsRepository = commentsRepository;
        }

        public async Task DeleteComment(string commentId)
        {
            var commentToDelete = this.commentsRepository.All().Where(c => c.Id == commentId).FirstOrDefault();
            commentToDelete.IsDeleted = true;
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeletePost(string postId)
        {
            var postToDelete = this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefault();
            postToDelete.IsDeleted = true;
            await this.postsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllPhotoComments<T>()
        {
            var comments = this.commentsRepository.All().OrderByDescending(x => x.CreatedOn).Where(x => x.UserId != null && x.SentById != null);
            return comments.To<T>().ToList();
        }

        public IEnumerable<T> GetAllPosts<T>()
        {
            var posts = this.postsRepository.All().OrderByDescending(x => x.CreatedOn);
            return posts.To<T>().ToList();
        }
    }
}
