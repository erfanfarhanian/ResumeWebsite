using Microsoft.AspNetCore.Mvc;
using Resume.Business.Services.Interface;

namespace Resume.Web.Controllers
{
	public class BlogController : SiteBaseController
	{
		#region Fields

		private readonly IBlogService _blogService;

		#endregion

		#region Constructor

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		#endregion

		#region Actions

		#region Index

		public async Task<IActionResult> Index()
		{
			var model = await _blogService.FilterBlogAsync(new DAL.ViewModels.Blog.FilterBlogViewModel()
			{
			});

			return View(model);
		}

		#endregion

		#region Show

		public async Task<IActionResult> ShowBlog(int id)
		{
			var model = await _blogService.GetBlogForEditByIDAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			return View(model);
		}

		#endregion

		#endregion
	}
}
