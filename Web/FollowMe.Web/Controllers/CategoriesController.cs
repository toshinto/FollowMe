using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        public IActionResult All()
        {
            return this.View();
        }
        public IActionResult Search()
        {
            return this.View();
        }
        public IActionResult Men()
        {
            var viewModel = new GeneralView()
            {
                People = this.categoriesService.GetTopMen<GeneralAllPeopleView>(),
            };
            return this.View(viewModel);
        }
        public IActionResult Women()
        {
            var viewModel = new GeneralView()
            {
                People = this.categoriesService.GetTopWomen<GeneralAllPeopleView>(),
            };
            return this.View(viewModel);
        }
        public IActionResult Birthdays()
        {
            return this.View();
        }
        public IActionResult Random()
        {
            var viewModel = new RandomView()
            {
                RandomPeople = this.categoriesService.GetRandom<RandomPeopleViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
