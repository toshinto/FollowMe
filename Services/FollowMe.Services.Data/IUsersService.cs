using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Models;

namespace FollowMe.Services.Data
{
    public interface IUsersService
    {
        ApplicationUser GetUserById(string userId);
    }
}
