using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class ProfileIdViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
    }
}
