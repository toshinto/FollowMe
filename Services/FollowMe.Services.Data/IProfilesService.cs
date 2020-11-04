using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Services.Data
{
    public interface IProfilesService
    {
        string GetId(string id);
        IEnumerable<T> GetAll<T>();
    }
}
