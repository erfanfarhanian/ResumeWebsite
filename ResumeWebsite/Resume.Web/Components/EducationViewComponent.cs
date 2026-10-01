using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class EducationViewComponent : ViewComponent
    {
        #region Fiels

        private readonly IEducationService _educationService;

        #endregion

        #region Contructor

        public EducationViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _educationService.FilterEducationAsync(new DAL.ViewModels.Education.FilterEducationViewModel()
            {
                
            });

            return View("Education", model);
        }

        #endregion
    }
}
