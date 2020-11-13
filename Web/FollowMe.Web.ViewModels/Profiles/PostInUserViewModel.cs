using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;
using FollowMe.Web.ViewModels.Comments;

namespace FollowMe.Web.ViewModels.Profiles
{
    public class PostInUserViewModel : IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string SentById { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }

        public int CommentsCount { get; set; }

        public string SentByUserCharacteristicsFullName { get; set; }

        public string SentByUserCharacteristicsCoverImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostInUserViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
