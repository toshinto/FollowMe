using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsCreateModel : IMapFrom<Comment>
    {
        [Required]
        public string PostId { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
