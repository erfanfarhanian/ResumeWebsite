using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Activity;
using Resume.DAL.ViewModels.ContactUs;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ActivityController : AdminBaseController
    {
        #region Fields

        private readonly IActivityService _activityService;

        #endregion

        #region Constructore

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterActivityViewModel filter)
        {

            var model = await _activityService.FilterAsync(filter);

            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateActvityViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            #endregion

            var result = await _activityService.CreateAsync(model);
            switch (result)
            {
                case CreateActivityResult.Success:
                    TempData[SuccessMessage] = "فعالیت جدید با موفقیت ارسال شد.";
                    return RedirectToAction("List");
                case CreateActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _activityService.GetInfoByIDAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditActvityViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _activityService.UpdateAsync(model);
            switch (result)
            {
                case EditActivityResult.Success:
                    TempData[SuccessMessage] = "فعالیت جدید با موفقیت ویرایش شد.";
                    return RedirectToAction("List");
                case EditActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
                case EditActivityResult.NotFound:
                    TempData[ErrorMessage] = "فعالیتی برای ویرایش یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _activityService.GetInfoByIdForDeleteAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteActivityViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _activityService.DeleteAsync(model);
            switch (result)
            {
                case DeleteActivityResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteActivityResult.Error:
                    TempData[ErrorMessage] = "خطایی رخ داده است.";
                    break;
                case DeleteActivityResult.NotFound:
                    TempData[ErrorMessage] = "فعالیت مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
