using System.ComponentModel.DataAnnotations;
using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class EditPostViewModel : IMapFrom<Post>
    {
        public string Id { get; set; }

        [Required]
        public string PostId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.TitleMinLength)]
        [MaxLength(20, ErrorMessage = GlobalConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.ContentMinLength)]
        [MaxLength(100, ErrorMessage = GlobalConstants.ContentMaxLength)]
        public string Content { get; set; }
    }
}
