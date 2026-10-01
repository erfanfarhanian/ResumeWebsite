using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Education;
using Resume.DAL.ViewModels.Experience;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Fields

        private readonly IEducationService _educationService;

        #endregion

        #region Constructor

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterEducationViewModel filter)
        {
            var model = await _educationService.FilterEducationAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _educationService.CreateEducationAsync(model);
            switch (result)
            {
                case CreateEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreateEducationResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _educationService.GetEducationForEditByIDAsync(id);

            if (model == null) 
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditEducationViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _educationService.EditEducationAsync(model);
            switch (result)
            {
                case EditEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditEducationResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditEducationResult.NotFound:
                    TempData[ErrorMessage] = "سطح تحصیلات یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _educationService.GetEducationForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteEducationViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _educationService.DeleteEducationAsync(model);
            switch (result)
            {
                case DeleteEducationResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteEducationResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeleteEducationResult.NotFound:
                    TempData[ErrorMessage] = "تحصیلات مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
