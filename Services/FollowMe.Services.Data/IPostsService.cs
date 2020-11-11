﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IPostsService
    {
        string GetNameById(string userId);

        Task Create(string content, string userId);

        IEnumerable<T> GetByUserId<T>(string userId);
    }
}
