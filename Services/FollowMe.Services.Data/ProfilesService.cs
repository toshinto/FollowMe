using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IDeletableEntityRepository<UserCharacteristic> usersRepository;

        public ProfilesService(IDeletableEntityRepository<UserCharacteristic> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task Create(CreateDetailsViewModel details, string userId)
        {
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
