using Microsoft.AspNetCore.Mvc;

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
