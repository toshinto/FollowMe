using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsCreateModel : IMapFrom<Comment>
    {
        public string PostId { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
