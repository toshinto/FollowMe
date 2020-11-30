using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FollowMe.Data;
using FollowMe.Data.Models;
using FollowMe.Services.Data;
using FollowMe.Web.ViewModels;
using FollowMe.Web.ViewModels.Chats;
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
        private readonly IMessagesService messagesService;

        public ChatsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMessagesService messagesService)
        {
            this.context = context;
            this.userManager = userManager;
            this.messagesService = messagesService;
        }

        public async Task<IActionResult> Chat()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (this.User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var viewModel = new ChatMessages();
            viewModel.Messages = this.messagesService.GetAll<ChatViewModel>();
            var messages = await this.context.Messages.ToListAsync();
            return this.View(viewModel);
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
