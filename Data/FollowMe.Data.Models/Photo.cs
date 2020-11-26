﻿using System;
using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Photo : BaseDeletableModel<string>
    {
        public Photo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Extension { get; set; }
    }
}
