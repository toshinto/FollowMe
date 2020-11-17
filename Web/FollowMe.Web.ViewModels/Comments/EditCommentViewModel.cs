using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class EditCommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}
