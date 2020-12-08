using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminViewModel : PagingViewModel
    {
        public IEnumerable<AdminPostsView> Posts { get; set; }
    }
}
