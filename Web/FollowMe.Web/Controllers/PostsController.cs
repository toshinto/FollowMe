using System.Threading.Tasks;

using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
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
        public async Task<IActionResult> Create(string userId, string content)
        {
            await this.postsService.Create(content, userId);
            return this.Redirect("/");
        }
    }
}
