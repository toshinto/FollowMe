using System.Threading.Tasks;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICommentsService commentsService;

        public CommentsController(IPostsService postsService, UserManager<ApplicationUser> userManager,
            ICommentsService commentsService)
        {
            this.postsService = postsService;
            this.userManager = userManager;
            this.commentsService = commentsService;
        }
        public IActionResult Create(string postId)
        {
            var viewModel = new CommentsCreateModel
            {
                PostId = this.postsService.GetPostById(postId),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string postId, string id, string content)
        {
            await this.commentsService.CreateAsync(postId, id, content);
            return this.Redirect($"/");
        }
    }
}
