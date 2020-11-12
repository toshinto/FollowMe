using System;
using System.Collections.Generic;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class PostInUserViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SentById { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }

        public int CommentsCount { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }

        public string SentByUserCharacteristicsCoverImageUrl { get; set; }
    }
}
