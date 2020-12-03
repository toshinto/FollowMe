using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Votes = new HashSet<Vote>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public string SentById { get; set; }

        public virtual ApplicationUser SentBy { get; set; }
        public string ImagePath { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
