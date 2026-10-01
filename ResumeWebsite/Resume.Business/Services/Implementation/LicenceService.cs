using Resume.Business.Services.Interface;
using Resume.DAL.Models.Experience;
using Resume.DAL.Models.Licence;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class LicenceService : ILicenceService
    {
        #region Fields

        private readonly ILicenceRepository _licenceRepository;

        #endregion

        #region Contructor

        public LicenceService(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        #endregion

        public async Task<CreateLicenceResult> CreateLicenceAsync(CreateLicenceViewModel model)
        {
            Licence licence = new Licence()
            {
                IssueDate = model.IssueDate,
                Title = model.Title,
                CreateDate = DateTime.Now,
                Institute = model.Institute,
            };

            await _licenceRepository.InsertLicenceAsync(licence);
            await _licenceRepository.SaveChangesAsync();

            return CreateLicenceResult.Success;
        }

        public async Task<DeleteLicenceResult> DeleteLicenceAsync(DeleteLicenceViewModel model)
        {
            var licence = await _licenceRepository.GetLicenceByIdAsync(model.ID);
            if (licence == null)
            {
                return DeleteLicenceResult.NotFound;
            }

            //licence.Title = model.Title;
            //licence.IssueDate = model.IssueDate;
            //licence.Institute = model.Institute;

            _licenceRepository.DeleteLicenceAsync(licence);
            await _licenceRepository.SaveChangesAsync();

            return DeleteLicenceResult.Success;
        }

        public async Task<EditLicenceResult> EditLicenceAsync(EditLicenceViewModel model)
        {
            var licence = await _licenceRepository.GetLicenceByIdAsync(model.ID);
            if (licence == null)
            {
                return EditLicenceResult.NotFound;
            }

            licence.Title = model.Title;
            licence.IssueDate = model.IssueDate;
            licence.Institute = model.Institute;

            _licenceRepository.EditLicenceAsync(licence);
            await _licenceRepository.SaveChangesAsync();

            return EditLicenceResult.Success;
        }

        public async Task<FilterLicenceViewModel> FilterLicenceAsync(FilterLicenceViewModel model)
        {
            return await _licenceRepository.FilterLicenceAsync(model);
        }

        public async Task<DeleteLicenceViewModel> GetLicenceForDeleteByIDAsync(int id)
        {
            return await _licenceRepository.GetLicenceForDeleteByIdAsync(id);
        }

        public async Task<EditLicenceViewModel> GetLicenceForEditByIDAsync(int id)
        {
            return await _licenceRepository.GetLicenceForEditByIdAsync(id);
        }
    }
}
