using System;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Photos
{
    public class PhotoComments : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string UserUserCharacteristicsFullName { get; set; }

        public string UserUserCharacteristicsCoverImageUrl { get; set; }

        public string SentByUserCharacteristicsCoverImageUrl { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }

        public string SentById { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string PostId { get; set; }

        public string ImagePath { get; set; }
    }
}
