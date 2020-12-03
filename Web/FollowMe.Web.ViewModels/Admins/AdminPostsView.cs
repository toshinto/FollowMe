using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminPostsView : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }
    }
}
