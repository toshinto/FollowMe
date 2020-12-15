using System;
using System.ComponentModel.DataAnnotations;
using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Search
{
    public class SearchIndexViewModel : IMapFrom<UserCharacteristic>
    {
        [Required(ErrorMessage = GlobalConstants.MinimumAgeIsRequired)]
        [Range(14, 104, ErrorMessage = GlobalConstants.MinimumAge)]
        public int MinimumAge { get; set; }

        [Required(ErrorMessage = GlobalConstants.MaximumAgeIsRequired)]
        [Range(14, 104, ErrorMessage = GlobalConstants.MaximumAge)]
        public int MaximumAge { get; set; }

        public Gender Gender { get; set; }

        public WhatAreYouSearchingFor SearchingFor { get; set; }

        public City City { get; set; }
    }
}
