using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Posts
{
    public class PostsCreateModel : IMapFrom<Post>
    {
        public string UserUserName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
