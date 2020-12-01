using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FollowMe.Common;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Profiles;

namespace FollowMe.Services.Data
{
    public class ProfilesService : IProfilesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<UserCharacteristic> usersRepository;
        private readonly IDeletableEntityRepository<Photo> photosRepository;

        public ProfilesService(IDeletableEntityRepository<UserCharacteristic> usersRepository, IDeletableEntityRepository<Photo> photosRepository)
        {
            this.usersRepository = usersRepository;
            this.photosRepository = photosRepository;
        }

        public async Task Create(CreateDetailsViewModel details, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/photos/");

            //var eye = Enum.TryParse(details.EyeColor, out EyesColor eyesColor);
            //var hair = Enum.TryParse(details.HairColor, out HairColor hairColor);

            //var wedding = Enum.TryParse(details.WeddingStatus, out WeddingStatus weddingStatus);
            //var whatYouSerachingFor = Enum.TryParse(details.WhatAreYouSearchingFor, out WhatAreYouSearchingFor whatAreYouSearchingFor);
            //var cities = Enum.TryParse(details.City, out City city);
            var userCharacteristic = new UserCharacteristic
            {
                FirstName = details.FirstName,
                LastName = details.LastName,
                City = details.City,
                CoverImageUrl = details.CoverImageUrl,
                Height = details.Height,
                Weight = details.Weight,
                EyeColor = details.EyeColor,
                HairColor = details.HairColor,
                Gender = details.Gender,
                Description = details.Description,
                WeddingStatus = details.WeddingStatus,
                WhatAreYouSearchingFor = details.WhatAreYouSearchingFor,
                CreatedOn = DateTime.UtcNow,
                Date = details.Date,
                UserId = userId,
            };

            var extension = Path.GetExtension(details.Image.FileName).TrimStart('.');
            if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            var photo = new Photo
            {
                UserId = userId,
                Extension = extension,
            };
            var physicalPath = $"{imagePath}/photos/{photo.Id}.{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await details.Image.CopyToAsync(fileStream);
            userCharacteristic.PhotoId = photo.Id;
            photo.ImagePath = physicalPath;

            await this.photosRepository.AddAsync(photo);
            await this.photosRepository.SaveChangesAsync();
            await this.usersRepository.AddAsync(userCharacteristic);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task EditPersonalDetails(EditDetailsViewModel model)
        {
            var userDetails = this.usersRepository.All().Where(x => x.UserId == model.UserId).FirstOrDefault();

            userDetails.FirstName = model.FirstName;
            userDetails.LastName = model.LastName;
            userDetails.CoverImageUrl = model.CoverImageUrl;
            userDetails.Height = model.Height;
            userDetails.Weight = model.Weight;
            userDetails.Description = model.Description;
            userDetails.UserId = model.UserId;
            userDetails.City = model.City;
            userDetails.Gender = model.Gender;
            userDetails.EyeColor = model.EyeColor;
            userDetails.HairColor = model.HairColor;
            userDetails.WeddingStatus = model.WeddingStatus;
            userDetails.WhatAreYouSearchingFor = model.WhatAreYouSearchingFor;

            await this.usersRepository.SaveChangesAsync();
        }

        public T EditView<T>(string userId)
        {
            var userDetails = this.usersRepository.All()
                   .Where(x => x.UserId == userId)
                   .To<T>().FirstOrDefault();
            return userDetails;
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<UserCharacteristic> query =
                this.usersRepository.All().OrderByDescending(x => x.CreatedOn);
            return query.To<T>().Take(GlobalConstants.CountOfPeopleOnIndexView).ToList();
        }

        public T GetByName<T>(string id, string userId)
        {
            var userDetail = this.usersRepository.All()
                .Where(x => x.UserId == id)
                .To<T>().FirstOrDefault();
            return userDetail;
        }

        public string GetId(string id)
        {
            var userId = this.usersRepository.All().Where(x => x.Id == id).Select(x => x.Id).FirstOrDefault();

            return userId;
        }

        public bool IsUserDetailsPage(string userId, string currentUser)
        {
            var user = this.usersRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
            if (user.UserId == currentUser)
            {
                return true;
            }
            return false;
        }
    }
}
