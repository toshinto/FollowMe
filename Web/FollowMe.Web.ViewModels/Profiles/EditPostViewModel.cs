using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class EditPostViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        public string PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
