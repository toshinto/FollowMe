using System;
using System.ComponentModel.DataAnnotations;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Search
{
    public class SearchIndexViewModel : IMapFrom<UserCharacteristic>
    {
        [Range(14, 104)]
        public int FromAge { get; set; }

        [Range(14, 104)]
        public int ToAge { get; set; }

        public DateTime Date { get; set; }

        public int Age => DateTime.UtcNow.Year - Date.Year;

        public Gender Gender { get; set; }

        public WhatAreYouSearchingFor SearchingFor { get; set; }

        public City City { get; set; }
    }
}
