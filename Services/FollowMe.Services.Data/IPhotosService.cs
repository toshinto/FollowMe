using System.Collections.Generic;
using System.Threading.Tasks;
using FollowMe.Web.ViewModels.Photos;

namespace FollowMe.Services.Data
{
    public interface IPhotosService
    {
        public Task CreateAsync(CreatePhotoInputModel model, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(string userId);

        Task DeleteAsync(string photoId, string userId);

        string GetUserByPhotoId(string photoId);

        T GetByName<T>(string photoId);
    }
}
