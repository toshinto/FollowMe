using System.Threading.Tasks;

using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesController(IProfilesService profilesService, UserManager<ApplicationUser> userManager)
        {
            this.profilesService = profilesService;
            this.userManager = userManager;
        }
        public IActionResult Details(string id)
        {
            var viewModel = new ProfileIdViewModel
            {
                Id = this.profilesService.GetId(id),
            };
            return this.View();
        }

        public IActionResult Profile(string id)
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Details(CreateDetailsViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.profilesService.Create(input, userId);
            return this.Redirect("/Profiles/Profile");
        }
    }
}
