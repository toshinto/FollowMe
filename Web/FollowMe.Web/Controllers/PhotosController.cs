using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class PhotosController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
