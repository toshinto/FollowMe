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
        public IActionResult AllPosts(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            const int ItemsPerPage = 12;
            var viewModel = new AdminViewModel();
            viewModel.PageNumber = id;
            viewModel.ItemsPerPage = ItemsPerPage;
            viewModel.Action = "AllPosts";
            viewModel.UsersCount = this.adminsService.GetCountOfPosts();
            viewModel.Posts = this.adminsService.GetAllPosts<AdminPostsView>(id, ItemsPerPage);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePost(string id)
        {
            await this.adminsService.DeletePost(id);
            return this.Redirect("/Admins/AllPosts");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPhotoComments(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            const int ItemsPerPage = 12;
            var viewModel = new AdminCommentsViewModel();
            viewModel.PageNumber = id;
            viewModel.ItemsPerPage = 12;
            viewModel.Action = "AllPhotoComments";
            viewModel.UsersCount = this.adminsService.GetCountOfPhotosComments();
            viewModel.Comments = this.adminsService.GetAllPhotoComments<AdminCommentsView>(id, ItemsPerPage);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await this.adminsService.DeleteComment(id);
            return this.Redirect("/Admins/AllPhotoComments");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllPhotos(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            const int ItemPerPage = 12;
            var viewModel = new AdminPhotoView();
            viewModel.PageNumber = id;
            viewModel.ItemsPerPage = ItemPerPage;
            viewModel.UsersCount = this.adminsService.GetCountOfPhotos();
            viewModel.Action = "AllPhotos";
            viewModel.Photos = this.adminsService.GetAllPhotos<AdminAllPhotosView>(id, ItemPerPage);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePhoto(string id)
        {
            await this.adminsService.DeletePhoto(id);
            return this.Redirect("/Admins/AllPhotos");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }
            const int ItemPerPage = 12;
            var viewModel = new AdminUserView();
            viewModel.PageNumber = id;
            viewModel.ItemsPerPage = ItemPerPage;
            viewModel.UsersCount = this.adminsService.GetCountOfUsers();
            viewModel.Action = "AllUsers";
            viewModel.Users = this.adminsService.GetAllUsers<AdminAllUsersView>(id, ItemPerPage);
            return this.View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await this.adminsService.DeleteUser(id);
            return this.Redirect("/Admins/AllUsers");
        }
    }
}
