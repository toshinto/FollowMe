using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class CreateDetailsViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string ImagePath { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public string EyeColor { get; set; }

        public string Gender { get; set; }

        public string HairColor { get; set; }

        public string WeddingStatus { get; set; }

        public string WhatAreYouSearchingFor { get; set; }
    }
}
