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
        public IActionResult Create(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = new CommentsCreateModel
            {
                PostId = this.postsService.GetPostById(id),
                UserId = userId,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string postId, string userId, string content)
        {
            var parentUserId = this.postsService.GetUserByPostId(postId);
            await this.commentsService.CreateAsync(postId, userId, content);
            return this.Redirect($"/Profiles/Profile?id={parentUserId}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var postId = this.commentsService.GetPostIdByCommentId(id);
            var parentUserProfile = this.postsService.GetUserByPostId(postId);
            await this.commentsService.DeleteAsync(id, userId);
            return this.Redirect($"/Profiles/Profile?id={parentUserProfile}");
        }
    }
}
