using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Services.Data
{
    public interface ICategoriesService
    {
        IEnumerable<T> GetRandom<T>();

        IEnumerable<T> GetTopMen<T>();

        IEnumerable<T> GetTopWomen<T>();
    }
}
