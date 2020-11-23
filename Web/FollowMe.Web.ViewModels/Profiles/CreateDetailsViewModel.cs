using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class CreateDetailsViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("[A-Z][a-z]{2,9}")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Z][a-z]{2,14}")]
        public string LastName { get; set; }

        [Required]
        public string CoverImageUrl { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Range(130, 240)]
        public int Height { get; set; }

        [Required]
        [Range(35, 250)]
        public int Weight { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public string EyeColor { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string HairColor { get; set; }

        [Required]
        public string WeddingStatus { get; set; }

        [Required]
        public string WhatAreYouSearchingFor { get; set; }
    }
}
