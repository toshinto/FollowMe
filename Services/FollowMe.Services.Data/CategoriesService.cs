using System;
using System.Collections.Generic;
using System.Linq;

using FollowMe.Common;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
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
        public IEnumerable<T> GetRandom<T>()
        {
            var randomPeople =
                this.usersRepository.All().OrderBy(x => Guid.NewGuid());
            return randomPeople.To<T>().Take(GlobalConstants.CountOfRandomPeopleOn).ToList();
        }
    }
}
