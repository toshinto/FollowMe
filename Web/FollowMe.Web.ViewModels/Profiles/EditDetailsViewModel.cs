using System.ComponentModel.DataAnnotations;
using FollowMe.Common;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class EditDetailsViewModel : IMapFrom<UserCharacteristic>
    {
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = GlobalConstants.FirstName)]
        [MinLength(3, ErrorMessage = GlobalConstants.FirstName)]
        [MaxLength(10, ErrorMessage = GlobalConstants.FirstName)]
        [RegularExpression("[A-Z][a-z]{2,9}", ErrorMessage = GlobalConstants.FirstName)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.LastName)]
        [MinLength(3, ErrorMessage = GlobalConstants.LastName)]
        [MaxLength(15, ErrorMessage = GlobalConstants.LastName)]
        [RegularExpression("[A-Z][a-z]{2,14}", ErrorMessage = GlobalConstants.LastName)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.CoverImageUrl)]

        public string CoverImageUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.Height)]
        [Range(130, 240, ErrorMessage = GlobalConstants.Height)]
        public int Height { get; set; }

        [Required(ErrorMessage = GlobalConstants.Weight)]
        [Range(35, 250, ErrorMessage = GlobalConstants.Weight)]
        public int Weight { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = GlobalConstants.DescriptionMinLength)]
        [MaxLength(200, ErrorMessage = GlobalConstants.DescriptionMaxLength)]

        public string Description { get; set; }
    }
}
