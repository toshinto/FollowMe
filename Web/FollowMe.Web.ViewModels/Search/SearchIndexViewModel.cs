using System;
using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Models.Enum;

namespace FollowMe.Web.ViewModels.Search
{
    public class SearchIndexViewModel
    {
        //[Range(14, 104)]
        //public int FromAge { get; set; }

        //[Range(14, 104)]
        //public int ToAge { get; set; }

        public Gender Gender { get; set; }

        public WhatAreYouSearchingFor SearchingFor { get; set; }

        public City City { get; set; }
    }
}
