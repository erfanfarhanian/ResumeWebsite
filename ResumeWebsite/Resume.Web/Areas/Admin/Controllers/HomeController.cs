using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;
using Resume.DAL.Context;
using Resume.DAL.ViewModels.ContactUs;
using Resume.DAL.ViewModels.Dashboard;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public HomeController(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Actions

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                ProjectsCount = _context.Portfolios.Count(),
                //CommentsCount = _context.(),
                ContactUsCount = _context.ContactUs.Count(),
                BlogCount = _context.Blogs.Count()
            };

            return View(model);
        }

        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Img/UploadImgs",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }

            var url = $"{"/Img/UploadImgs/"}{fileName}";


            return Json(new { uploaded = true, url });
        }

        #endregion

    }
}
