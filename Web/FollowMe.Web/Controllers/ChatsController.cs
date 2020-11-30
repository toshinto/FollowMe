using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data;
using FollowMe.Data.Models;
using FollowMe.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FollowMe.Web.Controllers
{
    [Authorize]
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
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var messages = await this.context.Messages.ToListAsync();
            return this.View(messages);
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (this.ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await this.userManager.GetUserAsync(this.User);
                message.UserId = sender.Id;
                await context.Messages.AddAsync(message);
                await context.SaveChangesAsync();
                return this.Redirect("/Chats/Chat");
            }
            return this.Error();
        }

        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
