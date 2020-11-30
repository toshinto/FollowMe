using System;
using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Message : BaseModel<int>
    {
        public Message()
        {
            this.When = DateTime.UtcNow;
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
