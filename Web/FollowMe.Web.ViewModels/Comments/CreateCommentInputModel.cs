using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Web.ViewModels.Comments
{
    public class CreateCommentInputModel
    {
        public string PostId { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
    }
}
