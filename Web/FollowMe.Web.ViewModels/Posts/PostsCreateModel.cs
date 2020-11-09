using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Posts
{
    public class PostsCreateModel : IMapFrom<Post>
    {
        public string UserUserName { get; set; }

        public string UserId { get; set; }

        public string FullName { get; set; }
    }
}
