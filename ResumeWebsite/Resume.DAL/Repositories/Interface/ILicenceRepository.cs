using Resume.DAL.Models.Experience;
using Resume.DAL.Models.Licence;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface ILicenceRepository
    {
        Task<FilterLicenceViewModel> FilterLicenceAsync(FilterLicenceViewModel model);
        Task InsertLicenceAsync(Licence licence);
        Task<Licence> GetLicenceByIdAsync(int id);
        void EditLicenceAsync(Licence licence);
        void DeleteLicenceAsync(Licence licence);
        Task<EditLicenceViewModel> GetLicenceForEditByIdAsync(int id);
        Task<DeleteLicenceViewModel> GetLicenceForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
