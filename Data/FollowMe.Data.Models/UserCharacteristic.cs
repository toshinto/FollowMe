using System;
using System.ComponentModel.DataAnnotations;
using FollowMe.Data.Common.Models;
using FollowMe.Data.Models.Enum;

namespace FollowMe.Data.Models
{
    public class UserCharacteristic : BaseDeletableModel<string>
    {
        public UserCharacteristic()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string PhotoId { get; set; }

        public Photo Photo { get; set; }

        [MaxLength(10)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public City City { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        public EyesColor EyeColor { get; set; }

        public WeddingStatus WeddingStatus { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public WhatAreYouSearchingFor WhatAreYouSearchingFor { get; set; }

        public HairColor HairColor { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
