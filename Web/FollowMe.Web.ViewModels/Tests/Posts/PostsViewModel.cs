using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Posts
{
    public class PostsViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
