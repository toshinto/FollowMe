using System.Collections.Generic;

using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Home
{
    public class IndexUserViewModel : IMapFrom<UserCharacteristic>, IHaveCustomMappings
    {
        public string CoverImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, IndexUserViewModel>();
        }
    }
}
