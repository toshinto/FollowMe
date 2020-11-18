using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;

namespace FollowMe.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public ApplicationUser GetUserById(string userId)
        {
            var user = this.usersRepository.All().Where(x => x.Id == userId).FirstOrDefault();
            return user;
        }
    }
}
