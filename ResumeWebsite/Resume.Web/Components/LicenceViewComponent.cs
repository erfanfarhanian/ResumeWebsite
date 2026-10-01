using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class LicenceViewComponent : ViewComponent
    {
        #region Fiels

        private readonly ILicenceService _licenceService;

        #endregion

        #region Contructor

        public LicenceViewComponent(ILicenceService licenceService)
        {
            _licenceService = licenceService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _licenceService.FilterLicenceAsync(new DAL.ViewModels.Licence.FilterLicenceViewModel()
            {
            });

            return View("Licence", model);
        }

        #endregion
    }
}
