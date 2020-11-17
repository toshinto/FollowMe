using System;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string PostId { get; set; }

        public string UserUserCharacteristicsCoverImageUrl { get; set; }
    }
}
