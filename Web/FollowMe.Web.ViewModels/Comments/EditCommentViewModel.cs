using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class EditCommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }
    }
}
