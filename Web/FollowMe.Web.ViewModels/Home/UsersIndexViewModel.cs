using System.Collections.Generic;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Home
{
    public class UsersIndexViewModel : IMapFrom<ApplicationUser>
    {
        public IEnumerable<IndexUserViewModel> UserCharacteristics { get; set; }
        public void CreateMapping(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, IndexUserViewModel>();
        }
    }
}
