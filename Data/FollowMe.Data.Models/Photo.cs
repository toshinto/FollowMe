using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Photo : BaseDeletableModel<string>
    {
        public Photo()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        public string ImagePath { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Extension { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
