using System.Collections.Generic;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Categories
{
    public class GeneralView : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        public IEnumerable<GeneralAllPeopleView> People { get; set; }
    }
}
