using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;
using FollowMe.Web.Infrastructure.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class CreateDetailsViewModel
    {
        [Required(ErrorMessage = GlobalConstants.FirstName)]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("[A-Z][a-z]{2,9}", ErrorMessage = GlobalConstants.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.LastName)]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Z][a-z]{2,14}", ErrorMessage = GlobalConstants.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.Birthday)]
        [RestrictionAge(14, ErrorMessage = GlobalConstants.BirthdayRestriction)]
        public DateTime Date { get; set; }

        [Required]
        public City City { get; set; }

        [Required(ErrorMessage = GlobalConstants.Height)]
        [Range(130, 240, ErrorMessage = GlobalConstants.Height)]

        public int Height { get; set; }

        [Required(ErrorMessage = GlobalConstants.Weight)]
        [Range(35, 250, ErrorMessage = GlobalConstants.Weight)]

        public int Weight { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.DescriptionMinLength)]
        [MaxLength(100, ErrorMessage = GlobalConstants.DescriptionMaxLength)]

        public string Description { get; set; }

        [Required]
        public EyesColor EyeColor { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public HairColor HairColor { get; set; }

        [Required]
        public WeddingStatus WeddingStatus { get; set; }

        [Required]
        public WhatAreYouSearchingFor WhatAreYouSearchingFor { get; set; }

        [Required]
        public IFormFile Image { get; set; }
    }
}
