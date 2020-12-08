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
        private readonly IDeletableEntityRepository<Photo> photosRepository;
        private readonly IDeletableEntityRepository<UserCharacteristic> usersRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> appUserRepository;

        public AdminsService(IDeletableEntityRepository<Post> postsRepository, IDeletableEntityRepository<Comment> commentsRepository, IDeletableEntityRepository<Photo> photosRepository, IDeletableEntityRepository<UserCharacteristic> usersRepository, IDeletableEntityRepository<ApplicationUser> appUserRepository)
        {
            this.postsRepository = postsRepository;
            this.commentsRepository = commentsRepository;
            this.photosRepository = photosRepository;
            this.usersRepository = usersRepository;
            this.appUserRepository = appUserRepository;
        }

        public async Task DeleteComment(string commentId)
        {
            var commentToDelete = this.commentsRepository.All().Where(c => c.Id == commentId).FirstOrDefault();
            commentToDelete.IsDeleted = true;
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task DeletePhoto(string photoId)
        {
            var photoToDelete = this.photosRepository.All().Where(p => p.Id == photoId).FirstOrDefault();
            photoToDelete.IsDeleted = true;
            await this.photosRepository.SaveChangesAsync();
        }

        public async Task DeletePost(string postId)
        {
            var postToDelete = this.postsRepository.All().Where(x => x.Id == postId).FirstOrDefault();
            postToDelete.IsDeleted = true;
            await this.postsRepository.SaveChangesAsync();
        }

        public async Task DeleteUser(string userId)
        {
            var userToDelete = this.appUserRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            userToDelete.IsDeleted = true;
            await this.appUserRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllPhotoComments<T>(int page, int itemsPerPage)
        {
            var comments = this.commentsRepository.All().OrderByDescending(x => x.CreatedOn).Where(x => x.UserId != null && x.SentById != null).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            return comments.To<T>().ToList();
        }

        public IEnumerable<T> GetAllPhotos<T>(int page, int itemsPerPage = 12)
        {
            var photos = this.photosRepository.All().OrderByDescending(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            return photos.To<T>().ToList();
        }

        public IEnumerable<T> GetAllPosts<T>(int page, int itemsPerPage)
        {
            var posts = this.postsRepository.All().OrderByDescending(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            return posts.To<T>().ToList();
        }

        public IEnumerable<T> GetAllUsers<T>(int page, int itemsPerPage = 12)
        {
            var users = this.usersRepository.All().OrderByDescending(x => x.CreatedOn).Skip((page - 1) * itemsPerPage).Take(itemsPerPage).To<T>().ToList();
            return users;
        }

        public int GetCountOfPhotos()
        {
            return photosRepository.All().Count();
        }

        public int GetCountOfPhotosComments()
        {
            return this.commentsRepository.All().OrderByDescending(x => x.CreatedOn).Where(x => x.UserId != null && x.SentById != null).Count();
        }

        public int GetCountOfPosts()
        {
            return this.postsRepository.All().Count();
        }

        public int GetCountOfUsers()
        {
            return this.usersRepository.All().Count();
        }
    }
}
