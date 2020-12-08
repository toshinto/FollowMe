using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminCommentsViewModel : PagingViewModel
    {
        public IEnumerable<AdminCommentsView> Comments { get; set; }
    }
}
