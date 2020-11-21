using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class EditDetailsViewModel : IMapFrom<UserCharacteristic>
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CoverImageUrl { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }
    }
}
