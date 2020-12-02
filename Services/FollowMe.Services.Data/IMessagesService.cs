using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FollowMe.Services.Data
{
    public interface IMessagesService
    {
        IEnumerable<T> GetAll<T>();

        Task CreateMessageAsync(string userName, string userId, string text);
    }
}
