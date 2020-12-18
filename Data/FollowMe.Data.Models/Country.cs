using System;
using System.Collections.Generic;
using System.Text;

using FollowMe.Data.Common.Models;

namespace FollowMe.Data.Models
{
    public class Country : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
