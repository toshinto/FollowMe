using System;
using System.ComponentModel.DataAnnotations;
using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }

        public string SentById { get; set; }

        public virtual ApplicationUser SentBy { get; set; }
    }
}
