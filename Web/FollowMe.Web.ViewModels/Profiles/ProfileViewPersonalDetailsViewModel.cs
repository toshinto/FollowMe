using System;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class ProfileViewPersonalDetailsViewModel : IMapFrom<UserCharacteristic>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string CoverImageUrl { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public string EyeColor { get; set; }

        public string Gender { get; set; }

        public string HairColor { get; set; }

        public string WeddingStatus { get; set; }

        public string WhatAreYouSearchingFor { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
