using System.Threading.Tasks;
using FollowMe.Web.ViewModels.Photos;

namespace FollowMe.Services.Data
{
    public interface IPhotosService
    {
        public Task CreateAsync(CreatePhotoInputModel model, string userId, string imagePath);
    }
}
