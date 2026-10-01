using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IEducationService
    {
        Task<FilterEducationViewModel> FilterEducationAsync(FilterEducationViewModel model);
        Task<CreateEducationResult> CreateEducationAsync(CreateEducationViewModel model);
        Task<EditEducationResult> EditEducationAsync(EditEducationViewModel model);
        Task<DeleteEducationResult> DeleteEducationAsync(DeleteEducationViewModel model);
        Task<EditEducationViewModel> GetEducationForEditByIDAsync(int id);
        Task<DeleteEducationViewModel> GetEducationForDeleteByIDAsync(int id);
    }
}
