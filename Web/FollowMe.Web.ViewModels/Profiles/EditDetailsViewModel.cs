using System.ComponentModel.DataAnnotations;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class EditDetailsViewModel : IMapFrom<UserCharacteristic>
    {
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Your first name must start with upper letter and followed by lower letters and no longer than 10 characters")]
        [MinLength(3)]
        [MaxLength(10)]
        [RegularExpression("[A-Z][a-z]{2,9}", ErrorMessage = "Your first name must start with upper letter and followed by lower letters and no longer than 10 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name must start with upper letter and followed by lower letters and no longer than 15 characters")]
        [MinLength(3)]
        [MaxLength(15)]
        [RegularExpression("[A-Z][a-z]{2,14}", ErrorMessage = "Your first name must start with upper letter and followed by lower letters and no longer than 15 characters")]
        public string LastName { get; set; }

        [Required]

        public string CoverImageUrl { get; set; }

        [Required]
        [Range(130, 240)]
        public int Height { get; set; }

        [Required]
        [Range(35, 250)]
        public int Weight { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]

        public string Description { get; set; }
    }
}
