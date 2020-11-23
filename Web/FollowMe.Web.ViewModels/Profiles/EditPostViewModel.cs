using System.ComponentModel.DataAnnotations;

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
        [MinLength(3)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
