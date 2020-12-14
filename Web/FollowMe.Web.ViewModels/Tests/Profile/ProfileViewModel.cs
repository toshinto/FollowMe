using System;

using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Profile
{
    public class ProfileViewModel : IMapFrom<UserCharacteristic>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public Gender Gender { get; set; }

        public City City { get; set; }

        public WhatAreYouSearchingFor WhatAreYouSearchingFor { get; set; }

        public DateTime Date { get; set; }
    }
}
