using System;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class PostInUserViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SentById { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }

        public string SentByUserCharacteristicsCoverImageUrl { get; set; }
    }
}
