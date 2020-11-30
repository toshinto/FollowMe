using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public IEnumerable<T> GetAll<T>()
        {
            var messages =
                this.messagesRepository.All().OrderByDescending(x => x.When);
            return messages.To<T>().ToList();
        }
    }
}
