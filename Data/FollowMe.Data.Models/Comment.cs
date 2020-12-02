using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Content { get; set; }
        public string PostId { get; set; }

        public Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string SentById { get; set; }

        public ApplicationUser SentBy { get; set; }

        public string PhotoId { get; set; }

        public Photo Photo { get; set; }

        public string ImagePath { get; set; }
    }
}
