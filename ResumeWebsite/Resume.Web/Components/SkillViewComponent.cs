using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Components
{
    public class SkillViewComponent : ViewComponent
    {
        #region Fiels

        private readonly ISkillService _skillService;

        #endregion

        #region Contructor

        public SkillViewComponent(ISkillService skillService)
        {
            _skillService = skillService;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _skillService.FilterSkillAsync(new DAL.ViewModels.Skill.FilterSkillViewModel()
            {
            });

            return View("Skill", model);
        }

        #endregion
    }
}
