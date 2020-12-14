using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Admins
{
    public class PostsViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }
    }
}
