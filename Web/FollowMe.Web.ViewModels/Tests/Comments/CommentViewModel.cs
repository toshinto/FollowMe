using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Comments
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
