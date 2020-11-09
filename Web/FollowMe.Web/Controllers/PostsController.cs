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
    }
}
