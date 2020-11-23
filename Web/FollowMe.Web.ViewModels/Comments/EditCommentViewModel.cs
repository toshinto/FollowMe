using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class EditCommentViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        [Required]
        public string CommentId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
