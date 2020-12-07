using System.Collections.Generic;
using System.Threading.Tasks;

using FollowMe.Web.ViewModels.Profiles;
using FollowMe.Web.ViewModels.Search;

namespace FollowMe.Services.Data
{
    public interface IProfilesService
    {
        string GetId(string id);
        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllSearch<T>(SearchIndexViewModel model);
        T GetByName<T>(string userId, string currUser);

        Task Create(CreateDetailsViewModel details, string userId, string imagePath);

        Task EditPersonalDetails(EditDetailsViewModel model);

        T EditView<T>(string userId);
        bool IsUserDetailsPage(string userId, string currentUser);
    }
}
