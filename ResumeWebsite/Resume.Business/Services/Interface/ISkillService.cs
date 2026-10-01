using Resume.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface ISkillService
    {
        Task<FilterSkillViewModel> FilterSkillAsync(FilterSkillViewModel model);
        Task<CreateSkillResult> CreateSkillAsync(CreateSkillViewModel model);
        Task<EditSkillResult> EditSkillAsync(EditSkillViewModel model);
        Task<DeleteSkillResult> DeleteSkillAsync(DeleteSkillViewModel model);
        Task<EditSkillViewModel> GetSkillForEditByIDAsync(int id);
        Task<DeleteSkillViewModel> GetSkillForDeleteByIDAsync(int id);
    }
}
