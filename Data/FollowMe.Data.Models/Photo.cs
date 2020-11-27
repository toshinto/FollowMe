using System;
using System.Collections.Generic;
using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Photo : BaseDeletableModel<string>
    {
        public Photo()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Comments = new HashSet<Comment>();
        }

        public string ImagePath { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string SentById { get; set; }

        public ApplicationUser SentBy { get; set; }

        public string Extension { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
