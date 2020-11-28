using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace FollowMe.Web.ViewModels.Comments
{
    public class EditPhotoViewModel : IMapFrom<Comment>
    {
        public string Id { get; set; }

        public string SentById { get; set; }

        [Required]
        public string CommentId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.ContentMinLength)]
        [MaxLength(100, ErrorMessage = GlobalConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
