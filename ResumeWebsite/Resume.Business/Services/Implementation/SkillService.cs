using Resume.Business.Services.Interface;
using Resume.DAL.Models.Licence;
using Resume.DAL.Models.Skill;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Licence;
using Resume.DAL.ViewModels.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class SkillService : ISkillService
    {
        #region Fields

        private readonly ISkillRepository _skillRepository;

        #endregion

        #region Contructor

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        #endregion

        public async Task<CreateSkillResult> CreateSkillAsync(CreateSkillViewModel model)
        {
            Skill skill = new Skill()
            {
                Title = model.Title,
                CreateDate = DateTime.Now,
                Proficiency = model.Proficiency
            };

            await _skillRepository.InsertSkillAsync(skill);
            await _skillRepository.SaveChangesAsync();

            return CreateSkillResult.Success;
        }

        public async Task<DeleteSkillResult> DeleteSkillAsync(DeleteSkillViewModel model)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(model.ID);
            if (skill == null)
            {
                return DeleteSkillResult.NotFound;
            }

            //skill.Title = model.Title;
            //skill.Proficiency = model.Proficiency;

            _skillRepository.DeleteSkillAsync(skill);
            await _skillRepository.SaveChangesAsync();

            return DeleteSkillResult.Success;
        }

        public async Task<EditSkillResult> EditSkillAsync(EditSkillViewModel model)
        {
            var skill = await _skillRepository.GetSkillByIdAsync(model.ID);
            if (skill == null)
            {
                return EditSkillResult.NotFound;
            }

            skill.Title = model.Title;
            skill.Proficiency = model.Proficiency;

            _skillRepository.EditSkillAsync(skill);
            await _skillRepository.SaveChangesAsync();

            return EditSkillResult.Success;
        }

        public async Task<FilterSkillViewModel> FilterSkillAsync(FilterSkillViewModel model)
        {
            return await _skillRepository.FilterSkillAsync(model);
        }

        public async Task<DeleteSkillViewModel> GetSkillForDeleteByIDAsync(int id)
        {
            return await _skillRepository.GetSkillForDeleteByIdAsync(id);
        }

        public async Task<EditSkillViewModel> GetSkillForEditByIDAsync(int id)
        {
            return await _skillRepository.GetSkillForEditByIdAsync(id);
        }
    }
}
