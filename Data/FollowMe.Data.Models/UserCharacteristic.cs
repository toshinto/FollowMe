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

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public string CoverImageUrl { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public EyesColor EyeColor { get; set; }

        public WeddingStatus WeddingStatus { get; set; }

        public DateTime BirthDate { get; set; }

        public WhatAreYouSearchingFor WhatAreYouSearchingFor { get; set; }

        public HairColor HairColor { get; set; }

        public string Description { get; set; }

    }
}
