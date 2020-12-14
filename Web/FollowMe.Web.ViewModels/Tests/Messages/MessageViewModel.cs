using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Messages
{
    public class MessageViewModel : IMapFrom<Message>
    {
        public string Id { get; set; }
    }
}
