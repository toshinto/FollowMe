namespace FollowMe.Web.Controllers
{
    using System.Diagnostics;
    using AutoMapper;
    using FollowMe.Services.Data;
    using FollowMe.Web.ViewModels;
    using FollowMe.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IProfilesService profilesService;

        public HomeController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }
        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.Redirect("/Identity/Account/Login");
            }
            var viewModel = new UsersIndexViewModel
            {
                UserCharacteristics = this.profilesService.GetAll<IndexUserViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
