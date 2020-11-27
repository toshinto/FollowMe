using System.Threading.Tasks;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Comments;
using Microsoft.AspNetCore.Authorization;
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
            if (!this.postsService.GetFirstNameById(userId))
            {
                return this.Redirect("/Profiles/Details");
            }
            var viewModel = new CommentsCreateModel
            {
                PostId = this.postsService.GetPostById(id),
                UserId = userId,
                UserFullName = this.postsService.GetCreatorOfPostByCommentId(id),
            };

            return this.View(viewModel);
        }

        [HttpGet]

        public IActionResult Edit(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var postId = this.commentsService.GetPostIdByCommentId(id);
            var parentUserProfile = this.postsService.GetUserByPostId(postId);
            if (!this.commentsService.IsUserCreatorOfComment(id, userId))
            {
                return this.Redirect($"/Profiles/Profile?id={parentUserProfile}#{id}");
            }
            var viewModel = this.commentsService.EditView<EditCommentViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(EditCommentViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }
            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.EditMessageComment(input.CommentId, input.Content, userId);
            var postId = this.commentsService.GetPostIdByCommentId(input.CommentId);
            var parentUserProfile = this.postsService.GetUserByPostId(postId);
            return this.Redirect($"/Profiles/Profile?id={parentUserProfile}#{input.CommentId}");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentsCreateModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            var parentUserProfile = this.postsService.GetUserByPostId(model.PostId);
            await this.commentsService.CreateAsync(model.PostId, model.UserId, model.Content);
            return this.Redirect($"/Profiles/Profile?id={parentUserProfile}#{model.PostId}");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.userManager.GetUserId(this.User);
            var postId = this.commentsService.GetPostIdByCommentId(id);
            var parentUserProfile = this.postsService.GetUserByPostId(postId);
            await this.commentsService.DeleteAsync(id, userId);
            return this.Redirect($"/Profiles/Profile?id={parentUserProfile}#{postId}");
        }

        [HttpGet]
        public IActionResult CreatePhotoComment(string id, string userId)
        {
            var viewModel = new CommentsPhotoModel
            {
                PhotoId = id,
                UserId = userId,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePhotoComment(CommentsPhotoModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.commentsService.CreatePhotoCommentAsync(model.PhotoId, model.UserId, model.Content);
            return this.Redirect("/");
        }
    }
}
