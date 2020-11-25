using System.Threading.Tasks;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Posts;
using FollowMe.Web.ViewModels.Profiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            var userFirstName = this.postsService.GetFirstNameById(currentUser);
            if (userFirstName == null)
            {
                return this.Redirect("/Profiles/Details");
            }
            var userName = this.postsService.GetNameById(id);
            var viewModel = new PostsCreateModel
            {
                UserId = id,
                UserUserName = userName,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostsCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var currentUser = this.userManager.GetUserId(this.User);
            await this.postsService.Create(model.Content, model.UserId, currentUser, model.Title);
            return this.Redirect($"/Profiles/Profile?id={model.UserId}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            var user = this.postsService.GetUserByPostId(id);
            await this.postsService.Delete(id, currentUser);
            return this.Redirect($"/Profiles/Profile?id={user}#{id}");
        }

        public IActionResult Edit(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var parentUserProfile = this.postsService.GetUserByPostId(id);
            if (!this.postsService.IsUserCreatorOfPost(id, userId))
            {
                return this.Redirect($"/Profiles/Profile?id={parentUserProfile}#{id}");
            }
            var viewModel = this.postsService.EditView<EditPostViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var userId = this.userManager.GetUserId(this.User);
            var parentUserProfile = this.postsService.GetUserByPostId(model.PostId);
            await this.postsService.EditPost(model.PostId, model.Content, model.Title, userId);
            return this.Redirect($"/Profiles/Profile?id={parentUserProfile}");
        }
    }
}
