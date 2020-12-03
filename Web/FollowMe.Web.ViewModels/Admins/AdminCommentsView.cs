using System;

using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminCommentsView : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Boolean, AdminCommentsView>();
        }
    }
}
