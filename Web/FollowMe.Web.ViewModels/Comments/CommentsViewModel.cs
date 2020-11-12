using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsViewModel : IMapFrom<Comment>
    {
        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
