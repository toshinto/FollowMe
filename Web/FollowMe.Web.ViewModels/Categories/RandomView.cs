using System.Collections.Generic;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Categories
{
    public class RandomView : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        public IEnumerable<RandomPeopleViewModel> RandomPeople { get; set; }
    }
}
