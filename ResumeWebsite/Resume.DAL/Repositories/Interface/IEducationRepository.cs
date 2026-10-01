using Resume.DAL.Models.Education;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IEducationRepository
    {
        Task<FilterEducationViewModel> FilterEducationAsync(FilterEducationViewModel model);
        Task InsertEducationAsync(Education education);
        Task<Education> GetEducationByIDAsync(int id);
        void EditEducationAsync(Education education);
        void DeleteEducationAsync(Education education);
        Task<EditEducationViewModel> GetEducationForEditByIDAsync(int id); 
        Task<DeleteEducationViewModel> GetEducationForDeleteByIDAsync(int id); 
        Task SaveChangesAsync();
    }
}
