using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IPostsService postsService;

        public CommentsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }
        public IActionResult Create(string postId)
        {
            var viewModel = new CommentsCreateModel
            {
                PostId = this.postsService.GetPostById(postId),
            };

            return this.View(viewModel);
        }
    }
}
