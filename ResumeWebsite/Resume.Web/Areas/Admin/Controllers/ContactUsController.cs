using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        #region Fields

        private readonly IContactUsService _contactUsService;

        #endregion

        #region Contructor

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterContactUsViewModel filter)
        {
            var model = await _contactUsService.FilterAsync(filter);

            return View(model);
        }
        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetByID(id);

            if (contactUs == null) 
            {
                return NotFound();
            }

            return View(contactUs);
        }

        [HttpPost]
		public async Task<IActionResult> Details(ContactUsDetailsViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            #endregion

            var result = await _contactUsService.AnswerAsync(model);
            switch (result)
            {
                case AnswerResult.Success:
                    TempData[SuccessMessage] = "پاسخ برای پیام مورد نظر ارسال شد.";
                    return RedirectToAction("List");
                case AnswerResult.ContactUsNotFound:
                    TempData[ErrorMessage] = "پیام تماس با ما مورد نظر یافت نشد.";
                    break;
                case AnswerResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است."; 
                    break;
                case AnswerResult.AnswerIsNull:
                    TempData[ErrorMessage] = "متن پاسخ خالی است.";
                        break;
                default:
                    break;
            }

            return View(model);
        }

		#endregion

		#endregion
	}
}
