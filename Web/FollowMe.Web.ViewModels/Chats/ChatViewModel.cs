using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Chats
{
    public class ChatViewModel : IMapFrom<Message>
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserId { get; set; }

        public string UserUserCharacteristicsFullName { get; set; }
    }
}
