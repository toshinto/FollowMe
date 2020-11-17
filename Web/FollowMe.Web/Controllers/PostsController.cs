using System.Threading.Tasks;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Posts;
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
            var userName = this.postsService.GetNameById(id);
            var viewModel = new PostsCreateModel
            {
                UserId = id,
                UserUserName = userName,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string userId, string content, string title)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            await this.postsService.Create(content, userId, currentUser, title);
            return this.Redirect($"/Profiles/Profile?id={userId}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            var user = this.postsService.GetUserByPostId(id);
            await this.postsService.Delete(id, currentUser);
            return this.Redirect($"/Profiles/Profile?id={user}");
        }
    }
}
