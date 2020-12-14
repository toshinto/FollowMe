using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Tests.Photos
{
    public class PhotoViewModel : IMapFrom<Photo>
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string ImagePath { get; set; }
    }
}
