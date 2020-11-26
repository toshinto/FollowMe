using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace FollowMe.Web.ViewModels.Photos
{
    public class CreatePhotoInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }
    }
}
