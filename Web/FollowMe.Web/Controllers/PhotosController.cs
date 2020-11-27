using System;
using System.Threading.Tasks;

using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Photos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPhotosService photosService;

        public PhotosController(IWebHostEnvironment webHostEnvironment, UserManager<ApplicationUser> userManager, IPhotosService photosService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.userManager = userManager;
            this.photosService = photosService;
        }
        public IActionResult Create()
        {
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
                Photos = this.photosService.GetAll<AllPhotoViewModel>(id),
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
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = this.photosService.GetByName<AllPhotoViewModel>(id);
            return this.View(viewModel);
        }
    }
}
