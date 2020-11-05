using System;
using System.Collections.Generic;
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
            var eye = Enum.TryParse(details.EyeColor, out EyesColor eyesColor);
            var hair = Enum.TryParse(details.HairColor, out HairColor hairColor);
            var sex = Enum.TryParse(details.Gender, out Gender gender);
            var wedding = Enum.TryParse(details.WeddingStatus, out WeddingStatus weddingStatus);
            var whatYouSerachingFor = Enum.TryParse(details.WhatAreYouSearchingFor, out WhatAreYouSearchingFor whatAreYouSearchingFor);

            if (usersRepository.All().Any(x => x.UserId == userId))
            {
                var user = usersRepository.All().Where(x => x.UserId == userId).FirstOrDefault();
                if (user != null)
                {
                    user.FirstName = details.FirstName;
                    user.LastName = details.LastName;
                    user.BirthDate = details.Birthday;
                    user.CoverImageUrl = details.Birthday.ToString();
                    user.Height = details.Height;
                    user.Weight = details.Weight;
                    user.Description = details.Description;
                    user.EyeColor = eyesColor;
                    user.HairColor = hairColor;
                    user.Gender = gender;
                    user.WeddingStatus = weddingStatus;
                    user.WhatAreYouSearchingFor = whatAreYouSearchingFor;
                }
                await this.usersRepository.SaveChangesAsync();
                return;
            }
            var userCharacteristic = new UserCharacteristic
            {
                FirstName = details.FirstName,
                LastName = details.LastName,
                BirthDate = details.Birthday,
                CoverImageUrl = details.ImagePath,
                Height = details.Height,
                Weight = details.Weight,
                Description = details.Description,
                EyeColor = eyesColor,
                HairColor = hairColor,
                Gender = gender,
                WeddingStatus = weddingStatus,
                WhatAreYouSearchingFor = whatAreYouSearchingFor,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
            };
            await this.usersRepository.AddAsync(userCharacteristic);
            await this.usersRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            IQueryable<UserCharacteristic> query =
                this.usersRepository.All().OrderByDescending(x => x.CreatedOn);
            return query.To<T>().Take(GlobalConstants.CountOfPeopleOnIndexView).ToList();
        }

        public T GetByName<T>(string userId)
        {
            var userDetail = this.usersRepository.All()
                .Where(x => x.UserId == userId)
                .To<T>().FirstOrDefault();
            return userDetail;
        }

        public string GetId(string id)
        {
            var userId = this.usersRepository.All().Where(x => x.Id == id).Select(x => x.Id).FirstOrDefault();

            return userId;
        }
    }
}
