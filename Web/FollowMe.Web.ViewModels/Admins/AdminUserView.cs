using System.Collections.Generic;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminUserView : IMapFrom<UserCharacteristic>
    {
        public IEnumerable<AdminAllUsersView> Users { get; set; }
    }
}
