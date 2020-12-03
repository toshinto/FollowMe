using System;
using System.Threading.Tasks;

using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Photos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPhotosService photosService;
        private readonly ICommentsService commentsService;

        public PhotosController(IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IPhotosService photosService, ICommentsService commentsService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.photosService = photosService;
            this.commentsService = commentsService;
        }
        public IActionResult Create()
        {
            var currentUser = this.userManager.GetUserId(this.User);
            if (!this.photosService.GetFirstNameById(currentUser))
            {
                return this.Redirect("/Profiles/Details");
            }
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePhotoInputModel input)
        {
            var user = this.userManager.GetUserId(this.User);
            try
            {
                await this.photosService.CreateAsync(input, user, $"{this.webHostEnvironment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }
            return this.Redirect($"/Photos/All?id={user}");
        }

        public IActionResult All(string id)
        {
            var viewModel = new PhotosAllViewModel
            {
                Photos = this.photosService.GetAll<AllPhotoUserViewModel>(id),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            var parentUserPhotos = this.photosService.GetUserByPhotoId(id);
            await this.photosService.DeleteAsync(id, currentUser);
            return this.Redirect($"/Photos/All?id={parentUserPhotos}");
        }

        public IActionResult Photo(string id)
        {
            var currentUser = this.userManager.GetUserId(this.User);
            if (!this.photosService.GetFirstNameById(currentUser))
            {
                return this.Redirect("/Profiles/Details");
            }
            var viewModel = this.photosService.GetByName<AllPhotoViewModel>(id);
            viewModel.Comments = this.commentsService.GetByUserId<PhotoComments>(id);
            return this.View(viewModel);
        }
    }
}
