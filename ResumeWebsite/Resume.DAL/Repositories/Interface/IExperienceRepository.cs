using Resume.DAL.Models.Experience;
using Resume.DAL.ViewModels.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IExperienceRepository
    {
        Task<FilterExperienceViewModel> FilterExperienceAsync(FilterExperienceViewModel model);
        Task InsertExperienceAsync(Experience experience);
        Task<Experience> GetExperienceByIdAsync(int id);
        void EditExperienceAsync(Experience experience);
        void DeleteExperienceAsync(Experience experience);
        Task<EditExperienceViewModel> GetExperienceForEditByIdAsync(int id);
        Task<DeleteExperienceViewModel> GetExperienceForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
