using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Web.ViewModels.Admins
{
    public class AdminPhotoView : PagingViewModel
    {
        public IEnumerable<AdminAllPhotosView> Photos { get; set; }
    }
}
