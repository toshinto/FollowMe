using System;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Profiles;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CommentsViewModel : IMapFrom<Comment>, IMapFrom<Photo>,  IMapFrom<UserCharacteristic>, IHaveCustomMappings
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string PostId { get; set; }

        public string UserUserCharacteristicsPhotoImagePath { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserCharacteristic, ProfileViewPersonalDetailsViewModel>()
                 .ForMember(x => x.UserUserCharacteristicsPhotoImagePath, opt =>
                     opt.MapFrom(x =>
                         "/images/photos/" + x.Photo.Id + '.' + x.Photo.Extension));
        }
    }
}
