using Resume.DAL.ViewModels.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IActivityService
    {
        Task<FilterActivityViewModel> FilterAsync(FilterActivityViewModel model);
        Task<CreateActivityResult> CreateAsync(CreateActvityViewModel model);
        Task<EditActivityResult> UpdateAsync(EditActvityViewModel model);
        Task<DeleteActivityResult> DeleteAsync(DeleteActivityViewModel model);
        Task<EditActvityViewModel?> GetInfoByIDAsync(int id);
        Task<DeleteActivityViewModel?> GetInfoByIdForDeleteAsync(int id);
        Task<List<ActivityDetailsViewModel>> GetAllInfoAsync();
    }
}
