using System.Linq;

using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Categories;
using FollowMe.Web.ViewModels.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly IProfilesService profilesService;

        public SearchController(IProfilesService profilesService)
        {
            this.profilesService = profilesService;
        }
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult List(SearchIndexViewModel input)
        {
            var viewModel = new GeneralView()
            {
                People = this.profilesService.GetAllSearch<GeneralAllPeopleView>(input),
            };
            return this.View(viewModel);
        }
    }
}
