using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class AdminsController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IAdminsService adminsService;

        public AdminsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IAdminsService adminsService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminsService = adminsService;
        }
        [Authorize]
        public async Task<IActionResult> AddUserToAdmin()
        {
            if (!await this.roleManager.RoleExistsAsync("Admin"))
            {
                await this.roleManager.CreateAsync(new ApplicationRole
                {
                    Name = "Admin",
                });
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var result = await this.userManager.AddToRoleAsync(user, "Admin");
            return this.Json(result);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AllPosts()
        {
            var viewModel = new AdminViewModel();
            viewModel.Posts = this.adminsService.GetAllPosts<AdminPostsView>();
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(string id)
        {
            await this.adminsService.DeletePost(id);
            return this.Redirect("/Admins/AllPosts");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPhotoComments()
        {
            var viewModel = new AdminCommentsViewModel();
            viewModel.Comments = this.adminsService.GetAllPhotoComments<AdminCommentsView>();
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await this.adminsService.DeleteComment(id);
            return this.Redirect("/Admins/AllPhotoComments");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPhotos()
        {
            var viewModel = new AdminPhotoView();
            viewModel.Photos = this.adminsService.GetAllPhotos<AdminAllPhotosView>();
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePhoto(string id)
        {
            await this.adminsService.DeletePhoto(id);
            return this.Redirect("/Admins/AllPhotos");
        }
    }
}
