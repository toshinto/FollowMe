using System.ComponentModel.DataAnnotations;

using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsPhotoModel : IMapFrom<Comment>
    {
        [Required]
        public string PhotoId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserFullName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.ContentMinLength)]
        [MaxLength(100, ErrorMessage = GlobalConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
