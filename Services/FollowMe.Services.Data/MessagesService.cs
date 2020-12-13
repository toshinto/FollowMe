using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowMe.Data.Common.Repositories;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Services.Data
{
    public class MessagesService : IMessagesService
    {
        private readonly IRepository<Message> messagesRepository;

        public MessagesService(IRepository<Message> messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        public async Task CreateMessageAsync(string userName, string userId, string text)
        {
            var message = new Message
            {
                UserName = userName,
                UserId = userId,
                Text = text,
            };

            await this.messagesRepository.AddAsync(message);
            await this.messagesRepository.SaveChangesAsync();
        }

        public async Task DeleteFifteenthCommnet()
        {
            var message =
                this.messagesRepository
                .All()
                .OrderBy(x => x.When)
                .FirstOrDefault();

            this.messagesRepository.Delete(message);
            await this.messagesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var messages =
                this.messagesRepository
                .All()
                .OrderByDescending(x => x.When);

            return messages.To<T>().ToList();
        }
    }
}
