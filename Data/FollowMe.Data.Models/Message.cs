﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FollowMe.Data.Models
{
    public class Message
    {
        public Message()
        {
            this.When = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
