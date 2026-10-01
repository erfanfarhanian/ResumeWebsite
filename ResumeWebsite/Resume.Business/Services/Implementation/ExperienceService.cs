using Resume.Business.Services.Interface;
using Resume.DAL.Models.Experience;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class ExperienceService : IExperienceService
    {
        #region Fields

        private readonly IExperienceRepository _experienceRepository;

        #endregion

        #region Contructor

        public ExperienceService(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        #endregion

        public async Task<CreateExperienceResult> CreateExperienceAsync(CreateExperienceViewModel model)
        {
            Experience experience = new Experience()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Title = model.Title,
                CreateDate = DateTime.Now,
                Description = model.Description,
            };

            await _experienceRepository.InsertExperienceAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return CreateExperienceResult.Success;
        }

        public async Task<DeleteExperienceResult> DeleteExperienceAsync(DeleteExperienceViewModel model)
        {
            var experience = await _experienceRepository.GetExperienceByIdAsync(model.ID);
            if (experience == null)
            {
                return DeleteExperienceResult.NotFound;
            }

            //experience.Title = model.Title;
            //experience.Description = model.Description;
            //experience.StartDate = model.StartDate;
            //experience.EndDate = model.EndDate;

            _experienceRepository.DeleteExperienceAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return DeleteExperienceResult.Success;
        }

        public async Task<EditExperienceResult> EditExperienceAsync(EditExperienceViewModel model)
        {
            var experience = await _experienceRepository.GetExperienceByIdAsync(model.ID);
            if (experience == null)
            {
                return EditExperienceResult.NotFound;
            }

            experience.Title = model.Title;
            experience.Description = model.Description;
            experience.StartDate = model.StartDate;
            experience.EndDate = model.EndDate;

            _experienceRepository.EditExperienceAsync(experience);
            await _experienceRepository.SaveChangesAsync();

            return EditExperienceResult.Success;
        }

        public async Task<FilterExperienceViewModel> FilterExperienceAsync(FilterExperienceViewModel model)
        {
            return await _experienceRepository.FilterExperienceAsync(model);
        }

        public async Task<DeleteExperienceViewModel> GetExperienceForDeleteByIDAsync(int id)
        {
            return await _experienceRepository.GetExperienceForDeleteByIdAsync(id);
        }

        public async Task<EditExperienceViewModel> GetExperienceForEditByIDAsync(int id)
        {
            return await _experienceRepository.GetExperienceForEditByIdAsync(id);
        }
    }
}
