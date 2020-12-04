using System;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminAllUsersView : IMapFrom<ApplicationUser>, IMapFrom<UserCharacteristic>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserUserName { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
