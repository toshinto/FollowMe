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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMessagesService messagesService;

        public ChatsController(UserManager<ApplicationUser> userManager, IMessagesService messagesService)
        {
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
            return this.View(viewModel);
        }

        public async Task<IActionResult> Create(ChatViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.UserName = User.Identity.Name;
                var sender = await this.userManager.GetUserAsync(this.User);
                model.UserId = sender.Id;
                await this.messagesService.CreateMessageAsync(model.UserName, model.UserId, model.Text);
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
