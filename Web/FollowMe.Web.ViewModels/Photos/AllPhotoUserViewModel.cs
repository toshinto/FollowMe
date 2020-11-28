using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Photos
{
    public class AllPhotoUserViewModel : IMapFrom<Photo>, IHaveCustomMappings
    {
        public string ImagePath { get; set; }

        public string Id { get; set; }

        public string UserId { get; set; }

        public string Extension { get; set; }

        public int CommentsCount { get; set; }

        public virtual void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Photo, AllPhotoUserViewModel>()
                 .ForMember(x => x.ImagePath, opt =>
                     opt.MapFrom(x =>
                         "/images/photos/" + x.Id + '.' + x.Extension));
        }
    }
}
