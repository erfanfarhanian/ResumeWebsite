using Resume.Business.Services.Interface;
using Resume.DAL.Models.Experience;
using Resume.DAL.Models.SocialMedia;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class SocialMediaService : ISocialMediaService
    {
        #region Fields

        private readonly ISocialMediaRepository _socialMediaRepository;

        #endregion

        #region Contructor

        public SocialMediaService(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        #endregion

        public async Task<CreateSocialMediaResult> CreateSocialMediaAsync(CreateSocialMediaViewModel model)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Title = model.Title,
                CreateDate = DateTime.Now,
                Icon = model.Icon,
                Url = model.Url
            };

            await _socialMediaRepository.InsertSocialMediaAsync(socialMedia);
            await _socialMediaRepository.SaveChangesAsync();

            return CreateSocialMediaResult.Success;
        }

        public async Task<DeleteSocialMediaResult> DeleteSocialMediaAsync(DeleteSocialMediaViewModel model)
        {
            var socialMedia = await _socialMediaRepository.GetSocialMediaByIdAsync(model.ID);
            if (socialMedia == null)
            {
                return DeleteSocialMediaResult.NotFound;
            }

            _socialMediaRepository.DeleteSocialMediaAsync(socialMedia);
            await _socialMediaRepository.SaveChangesAsync();

            return DeleteSocialMediaResult.Success;
        }

        public async Task<EditSocialMediaResult> EditSocialMediaAsync(EditSocialMediaViewModel model)
        {
            var socialMedia = await _socialMediaRepository.GetSocialMediaByIdAsync(model.ID);
            if (socialMedia == null)
            {
                return EditSocialMediaResult.NotFound;
            }

            socialMedia.Title = model.Title;
            socialMedia.Icon = model.Icon;
            socialMedia.Url = model.Url;

            _socialMediaRepository.EditSocialMediaAsync(socialMedia);
            await _socialMediaRepository.SaveChangesAsync();

            return EditSocialMediaResult.Success;
        }

        public async Task<FilterSocialMediaViewModel> FilterSocialMediaAsync(FilterSocialMediaViewModel model)
        {
            return await _socialMediaRepository.FilterSocialMediaAsync(model);
        }

        public async Task<DeleteSocialMediaViewModel> GetSocialMediaForDeleteByIDAsync(int id)
        {
            return await _socialMediaRepository.GetSocialMediaForDeleteByIdAsync(id);
        }

        public async Task<EditSocialMediaViewModel> GetSocialMediaForEditByIDAsync(int id)
        {
            return await _socialMediaRepository.GetSocialMediaForEditByIdAsync(id);
        }
    }
}
