using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Areas.Admin.Components
{
    public class ContactUsViewComponent : ViewComponent
    {
        #region Fields

        private readonly IContactUsService _contactUsService;

        #endregion

        #region Contructor

        public ContactUsViewComponent(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _contactUsService.FilterAsync(new DAL.ViewModels.ContactUs.FilterContactUsViewModel() { });
            return View("ContactUs", model);
        }
    }
}
