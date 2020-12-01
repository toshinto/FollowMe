using System.Threading.Tasks;

using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Profiles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class ProfilesController : BaseController
    {
        private readonly IProfilesService profilesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostsService postsService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProfilesController(IProfilesService profilesService, UserManager<ApplicationUser> userManager, IPostsService postsService, IWebHostEnvironment webHostEnvironment)
        {
            this.profilesService = profilesService;
            this.userManager = userManager;
            this.postsService = postsService;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Details()
        {
            return this.View();
        }

        public IActionResult Profile(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = this.profilesService.GetByName<ProfileViewPersonalDetailsViewModel>(id, userId);
            if (viewModel == null)
            {
                return this.Redirect("/Profiles/Details");
            }
            viewModel.UserPosts = this.postsService.GetByUserId<PostInUserViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Details(CreateDetailsViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            var userId = this.userManager.GetUserId(this.User);
            await this.profilesService.Create(input, userId, $"{this.webHostEnvironment.WebRootPath}/images");
            return this.Redirect($"/Profiles/Profile?id={userId}");
        }
        public IActionResult EditDetails(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            if (!this.profilesService.IsUserDetailsPage(id, currentUser))
            {
                return this.Redirect("/");
            }
            var viewModel = this.profilesService.EditView<EditDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(EditDetailsViewModel model)
        {
            await this.profilesService.EditPersonalDetails(model);
            return this.Redirect($"/Profiles/Profile?id={model.UserId}");
        }
    }
}
