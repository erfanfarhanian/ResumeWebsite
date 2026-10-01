using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class SocialMediaViewComponent : ViewComponent
    {
        #region Fiels

        private readonly ISocialMediaService _socialMediaService;

        #endregion

        #region Contructor

        public SocialMediaViewComponent(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _socialMediaService.FilterSocialMediaAsync(new DAL.ViewModels.SocialMedia.FilterSocialMediaViewModel()
            {
            });

            return View("SocialMedia", model);
        }

        #endregion
    }
}
