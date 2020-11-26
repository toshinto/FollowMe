﻿using System.Collections;
using System.Collections.Generic;
using FollowMe.Data.Models;
using FollowMe.Services.Mapping;

namespace FollowMe.Web.ViewModels.Photos
{
    public class PhotosAllViewModel : IMapFrom<Photo>
    {
        public string Id { get; set; }

        public IEnumerable<AllPhotoViewModel> Photos { get; set; }
    }
}
