using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }
        public IActionResult Search()
        {
            return this.View();
        }
    }
}
