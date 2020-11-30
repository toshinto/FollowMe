using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data;
using FollowMe.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Web.Controllers
{
    public class ChatsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public ChatsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Chat()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var messages = await this.context.Messages.ToListAsync();
            return this.View();
        }
    }
}
