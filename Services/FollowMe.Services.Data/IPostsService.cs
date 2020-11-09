using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Services.Data
{
    public interface IPostsService
    {
        string GetNameById(string userId);
    }
}
