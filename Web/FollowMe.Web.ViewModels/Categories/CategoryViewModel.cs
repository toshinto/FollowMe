using FollowMe.Data.Models;
using FollowMe.Data.Models.Enum;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Categories
{
    public class CategoryViewModel : IMapFrom<UserCharacteristic>
    {
        public string Id { get; set; }

        public string Gender { get; set; }

    }
}
