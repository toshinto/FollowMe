using Microsoft.AspNetCore.Mvc;

namespace FollowMe.Web.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Details()
        {
            return this.View();
        }
    }
}
