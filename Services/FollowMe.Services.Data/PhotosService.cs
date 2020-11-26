using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
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

                dbImage.ImagePath = physicalPath;

                await this.photosRepository.AddAsync(dbImage);
                await this.photosRepository.SaveChangesAsync();
            }
        }
    }
}
