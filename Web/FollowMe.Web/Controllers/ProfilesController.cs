using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IProfilesService profilesService;

        public ProfilesController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }
        public IActionResult Details(string id)
        {
            var viewModel = new ProfileIdViewModel
            {
                Id = this.profilesService.GetId(id),
            };
            return this.View();
        }

        public IActionResult Profile()
        {
            return this.View();
        }
    }
}
