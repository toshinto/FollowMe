using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Photos;

namespace FollowMe.Services.Data
{
    public class PhotosService : IPhotosService
    {
        public PhotosService(IDeletableEntityRepository<Photo> photosRepository)
        {
            this.photosRepository = photosRepository;
        }
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Photo> photosRepository;

        public async Task CreateAsync(CreatePhotoInputModel model, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/photos/");

            foreach (var image in model.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Photo
                {
                    UserId = userId,
                    Extension = extension,
                };

                var physicalPath = $"{imagePath}/photos/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);

                await this.photosRepository.AddAsync(dbImage);
                await this.photosRepository.SaveChangesAsync();
            }
        }

        public IEnumerable<T> GetAll<T>(string userId)
        {
            var photos =
                this.photosRepository.All().Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOn);
            return photos.To<T>().ToList();
        }

        public async Task DeleteAsync(string photoId, string userId)
        {
            var photo = this.photosRepository.All().Where(p => p.Id == photoId).FirstOrDefault();
            if (photo.UserId == userId)
            {
                photo.IsDeleted = true;
            }
            else
            {
                return;
            }

            await this.photosRepository.SaveChangesAsync();
        }

        public string GetUserByPhotoId(string photoId)
        {
            var userId = this.photosRepository.All().Where(p => p.Id == photoId).Select(u => u.UserId).FirstOrDefault();
            return userId;
        }

        public T GetByName<T>(string photoId)
        {
            var photoDetails = this.photosRepository.All()
                .Where(x => x.Id == photoId)
                .To<T>().FirstOrDefault();
            return photoDetails;
        }
    }
}
