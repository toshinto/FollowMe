using System;
using System.Collections.Generic;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class ProfileViewPersonalDetailsViewModel : IMapFrom<UserCharacteristic>, IMapFrom<Photo>, IHaveCustomMappings
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime Date { get; set; }

        public string CoverImageUrl { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
        public int Height { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

        public string EyeColor { get; set; }

        public string Gender { get; set; }

        public string HairColor { get; set; }

        public string WeddingStatus { get; set; }

        public string WhatAreYouSearchingFor { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public IEnumerable<PostInUserViewModel> UserPosts { get; set; }

        public int UserPhotosCount { get; set; }

        public string PhotoId { get; set; }

        public string PhotoExtension { get; set; }

        public string UserUserCharacteristicsPhotoImagePath { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserCharacteristic, ProfileViewPersonalDetailsViewModel>()
                 .ForMember(x => x.UserUserCharacteristicsPhotoImagePath, opt =>
                     opt.MapFrom(x =>
                         "/images/photos/" + x.PhotoId + '.' + x.Photo.Extension));
        }
    }
}
