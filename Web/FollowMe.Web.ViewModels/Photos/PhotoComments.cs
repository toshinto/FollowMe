using System;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Photos
{
    public class PhotoComments : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string PhotoId { get; set; }

        public string UserUserCharacteristicsCoverImageUrl { get; set; }
    }
}
