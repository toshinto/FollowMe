using System.Threading.Tasks;

using FollowMe.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace FollowMe.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
