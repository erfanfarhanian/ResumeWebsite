using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class ExperienceViewComponent : ViewComponent
    {
        #region Fiels

        private readonly IExperienceService _experienceService;

        #endregion

        #region Contructor

        public ExperienceViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _experienceService.FilterExperienceAsync(new DAL.ViewModels.Experience.FilterExperienceViewModel()
            {
            });

            return View("Experience", model);
        }

        #endregion
    }
}
