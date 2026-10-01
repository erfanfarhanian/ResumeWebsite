using Resume.DAL.Models.Activitiy;
using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IActivityRepository
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);
        Task InsertAsync(Activity activity);
        void UpdateAsync(Activity activity);
        void DeleteAsync(Activity activity);
        Task SaveAsync();
        Task<EditActvityViewModel?> GetInfoByIDAsync(int id);
        Task<DeleteActivityViewModel?> GetInfoByIdForDeleteAsync(int id);
        Task<Activity?> GetActivityByIdAsync(int id);
        Task<List<ActivityDetailsViewModel>> GetAllInfoAsync();

	}
}
