using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminAllPhotosView : IMapFrom<Photo>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImagePath { get; set; }

        public string Extension { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Photo, AdminAllPhotosView>()
               .ForMember(x => x.ImagePath, opt =>
                   opt.MapFrom(x =>
                       "/images/photos/" + x.Id + '.' + x.Extension));
        }
    }
}
