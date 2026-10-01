using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.ViewModels.Licence;
using Resume.DAL.ViewModels.Skill;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        #region Fields

        private readonly ISkillService _skillService;

        #endregion

        #region Constructor

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        #endregion

        #region Actions

        #region List

        public async Task<IActionResult> List(FilterSkillViewModel filter)
        {
            var model = await _skillService.FilterSkillAsync(filter);
            return View(model);
        }

        #endregion

        #region Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _skillService.CreateSkillAsync(model);
            switch (result)
            {
                case CreateSkillResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case CreateSkillResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> Update(int id)
        {
            var model = await _skillService.GetSkillForEditByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditSkillViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _skillService.EditSkillAsync(model);
            switch (result)
            {
                case EditSkillResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case EditSkillResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case EditSkillResult.NotFound:
                    TempData[ErrorMessage] = "مهارت مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _skillService.GetSkillForDeleteByIDAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteSkillViewModel model)
        {
            #region Validations

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var result = await _skillService.DeleteSkillAsync(model);
            switch (result)
            {
                case DeleteSkillResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد.";
                    return RedirectToAction("List");
                case DeleteSkillResult.Error:
                    TempData[ErrorMessage] = "عملیات با شکست موجه شد.";
                    break;
                case DeleteSkillResult.NotFound:
                    TempData[ErrorMessage] = "مهارت مورد نظر یافت نشد.";
                    break;
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}
