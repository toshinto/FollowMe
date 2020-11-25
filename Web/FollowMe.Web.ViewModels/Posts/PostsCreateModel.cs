using System.ComponentModel.DataAnnotations;
using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Posts
{
    public class PostsCreateModel : IMapFrom<Post>
    {
        public string Id { get; set; }
        public string UserUserName { get; set; }

        [Required]
        public string UserId { get; set; }

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
