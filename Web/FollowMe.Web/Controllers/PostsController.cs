using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowMe.Web.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
