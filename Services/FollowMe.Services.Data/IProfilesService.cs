using System.Collections.Generic;
using System.Threading.Tasks;

using FollowMe.Web.ViewModels.Profiles;

namespace FollowMe.Services.Data
{
    public interface IProfilesService
    {
        string GetId(string id);
        IEnumerable<T> GetAll<T>();

        Task Create(CreateDetailsViewModel details, string userId);
    }
}
