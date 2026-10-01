using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Implementation;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Experience;
using Resume.DAL.ViewModels.Licence;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ExperienceController : AdminBaseController
    {
        #region Fields

        private readonly IExperienceService _experienceService;

        #endregion

        #region Constructor

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterExperienceViewModel filter)
        {
            var model = await _experienceService.FilterExperienceAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExperienceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _experienceService.CreateExperienceAsync(model);
            switch (result)
            {
                case CreateExperienceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreateExperienceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _experienceService.GetExperienceForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditExperienceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _experienceService.EditExperienceAsync(model);
            switch (result)
            {
                case EditExperienceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditExperienceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditExperienceResult.NotFound:
                    TempData[ErrorMessage] = "تجربه کاری یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _experienceService.GetExperienceForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteExperienceViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _experienceService.DeleteExperienceAsync(model);
            switch (result)
            {
                case DeleteExperienceResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteExperienceResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeleteExperienceResult.NotFound:
                    TempData[ErrorMessage] = "تجربه مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
