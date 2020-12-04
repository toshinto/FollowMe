using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using FollowMe.Common;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;

namespace FollowMe.Services.Data
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<UserCharacteristic> usersRepository;

        public CategoriesService(IDeletableEntityRepository<UserCharacteristic> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IEnumerable<T> GetBirhtdaysPeople<T>()
        {
            var birthdayPeoples = this.usersRepository.All().Where(x => x.Date.Month == DateTime.UtcNow.Month && x.Date.Day == DateTime.UtcNow.Day);
            return birthdayPeoples.To<T>().ToList();
        }

        public IEnumerable<T> GetRandom<T>()
        {
            var randomPeople =
                this.usersRepository.All().OrderBy(x => Guid.NewGuid());
            return randomPeople.To<T>().Take(GlobalConstants.CountOfPeopleOnCategories).ToList();
        }

        public IEnumerable<T> GetTopMen<T>()
        {
            var topMen =
                this.usersRepository.All().Where(x => x.Gender == Gender.Male).OrderByDescending(x => x.User.Photos.Count());
            return topMen.To<T>().Take(GlobalConstants.CountOfPeopleOnCategories).ToList();
        }

        public IEnumerable<T> GetTopWomen<T>()
        {
            var topWomen =
                this.usersRepository.All().Where(x => x.Gender == Gender.Female).OrderByDescending(x => x.User.Photos.Count());
            return topWomen.To<T>().Take(GlobalConstants.CountOfPeopleOnCategories).ToList();
        }
    }
}
