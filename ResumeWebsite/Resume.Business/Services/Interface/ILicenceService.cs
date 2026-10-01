using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface ILicenceService
    {
        Task<FilterLicenceViewModel> FilterLicenceAsync(FilterLicenceViewModel model);
        Task<CreateLicenceResult> CreateLicenceAsync(CreateLicenceViewModel model);
        Task<EditLicenceResult> EditLicenceAsync(EditLicenceViewModel model);
        Task<DeleteLicenceResult> DeleteLicenceAsync(DeleteLicenceViewModel model);
        Task<EditLicenceViewModel> GetLicenceForEditByIDAsync(int id);
        Task<DeleteLicenceViewModel> GetLicenceForDeleteByIDAsync(int id);
    }
}
