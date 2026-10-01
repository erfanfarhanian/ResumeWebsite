using Resume.DAL.Models.Skill;
using Resume.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface ISkillRepository
    {
        Task<FilterSkillViewModel> FilterSkillAsync(FilterSkillViewModel model);
        Task InsertSkillAsync(Skill skill);
        Task<Skill> GetSkillByIdAsync(int id);
        void EditSkillAsync(Skill skill);
        void DeleteSkillAsync(Skill skill);
        Task<EditSkillViewModel> GetSkillForEditByIdAsync(int id);
        Task<DeleteSkillViewModel> GetSkillForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
