using Resume.Business.Services.Interface;
using Resume.DAL.Models.Education;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class EducationService : IEducationService
    {
        #region Fields

        private readonly IEducationRepository _educationRepository;

        #endregion

        #region Contructor

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        #endregion

        public async Task<CreateEducationResult> CreateEducationAsync(CreateEducationViewModel model)
        {
            Education education = new Education()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Title = model.Title,
                CreateDate = DateTime.Now,
                Description = model.Description,
            };

            await _educationRepository.InsertEducationAsync(education);
            await _educationRepository.SaveChangesAsync();

            return CreateEducationResult.Success;
        }

        public async Task<DeleteEducationResult> DeleteEducationAsync(DeleteEducationViewModel model)
        {
            var education = await _educationRepository.GetEducationByIDAsync(model.ID);
            if (education == null)
            {
                return DeleteEducationResult.NotFound;
            }

            //education.Title = model.Title;
            //education.Description = model.Description;
            //education.StartDate = model.StartDate;
            //education.EndDate = model.EndDate;

            _educationRepository.DeleteEducationAsync(education);
            await _educationRepository.SaveChangesAsync();

            return DeleteEducationResult.Success;
        }

        public async Task<EditEducationResult> EditEducationAsync(EditEducationViewModel model)
        {
            var education = await _educationRepository.GetEducationByIDAsync(model.ID);
            if (education == null)
            {
                return EditEducationResult.NotFound;
            }

            education.Title = model.Title;
            education.Description = model.Description;
            education.StartDate = model.StartDate;
            education.EndDate = model.EndDate;

            _educationRepository.EditEducationAsync(education);
            await _educationRepository.SaveChangesAsync();

            return EditEducationResult.Success;
        }

        public async Task<FilterEducationViewModel> FilterEducationAsync(FilterEducationViewModel model)
        {
            return await _educationRepository.FilterEducationAsync(model);
        }

        public async Task<DeleteEducationViewModel> GetEducationForDeleteByIDAsync(int id)
        {
            return await _educationRepository.GetEducationForDeleteByIDAsync(id);
        }

        public async Task<EditEducationViewModel> GetEducationForEditByIDAsync(int id)
        {
            return await _educationRepository.GetEducationForEditByIDAsync(id);
        }
    }
}
