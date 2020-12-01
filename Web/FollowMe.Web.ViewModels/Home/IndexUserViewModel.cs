using System.Collections.Generic;

using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Home
{
    public class IndexUserViewModel : IMapFrom<UserCharacteristic>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string CoverImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public string PhotoId { get; set; }

        public string PhotoExtension { get; set; }

        public string PhotoImagePath { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, IndexUserViewModel>();
            configuration.CreateMap<UserCharacteristic, IndexUserViewModel>()
                 .ForMember(x => x.PhotoImagePath, opt =>
                     opt.MapFrom(x =>
                         "/images/photos/" + x.PhotoId + '.' + x.Photo.Extension));
        }
    }
}
