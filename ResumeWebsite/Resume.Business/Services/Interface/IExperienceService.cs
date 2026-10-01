using Resume.DAL.ViewModels.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IExperienceService
    {
        Task<FilterExperienceViewModel> FilterExperienceAsync(FilterExperienceViewModel model);
        Task<CreateExperienceResult> CreateExperienceAsync(CreateExperienceViewModel model);
        Task<EditExperienceResult> EditExperienceAsync(EditExperienceViewModel model);
        Task<DeleteExperienceResult> DeleteExperienceAsync(DeleteExperienceViewModel model);
        Task<EditExperienceViewModel> GetExperienceForEditByIDAsync(int id);
        Task<DeleteExperienceViewModel> GetExperienceForDeleteByIDAsync(int id);
    }
}
