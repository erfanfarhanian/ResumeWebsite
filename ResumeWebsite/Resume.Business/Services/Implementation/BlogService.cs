using Resume.Business.Services.Interface;
using Resume.DAL.Models.Blog;
using Resume.DAL.Models.Portfolio;
using Resume.DAL.Repositories.Implementation;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Blog;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
    public class BlogService : IBlogService
    {
        #region Fields

        private readonly IBlogRepository _blogRepository;

        #endregion

        #region Contructor

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        #endregion

        public async Task<CreateBlogResult> CreateBlogAsync(CreateBlogViewModel model)
        {
            if (model.Avatar == null || model.Avatar.Length == 0)
            {
                return CreateBlogResult.Error;
            }

            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName);
            model.ImageUrl = imageName;
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Blog/", model.ImageUrl);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await model.Avatar.CopyToAsync(stream);
            }

            Blog blog = new Blog()
            {
                ImageUrl = model.ImageUrl,
                Title = model.Title,
                CreateDate = DateTime.Now,
                ShortText = model.ShortText,
                LongText = model.LongText,
                BlogDate = model.BlogDate
            };

            await _blogRepository.InsertBlogAsync(blog);
            await _blogRepository.SaveChangesAsync();

            return CreateBlogResult.Success;
        }

        public async Task<DeleteBlogResult> DeleteBlogAsync(DeleteBlogViewModel model)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(model.ID);
            if (blog == null)
            {
                return DeleteBlogResult.NotFound;
            }

            string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Blog/", blog.ImageUrl);
            if (File.Exists(deleteImagePath))
            {
                File.Delete(deleteImagePath);
            }

            _blogRepository.DeleteBlogAsync(blog);
            await _blogRepository.SaveChangesAsync();

            return DeleteBlogResult.Success;
        }

        public async Task<EditBlogResult> EditBlogAsync(EditBlogViewModel model)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(model.ID);
            if (blog == null)
            {
                return EditBlogResult.NotFound;
            }

            blog.Title = model.Title;
            blog.ShortText = model.ShortText;
            blog.LongText = model.LongText;
            blog.BlogDate = model.BlogDate;
            if (model.Avatar != null)
            {
                string deleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Blog/", blog.ImageUrl);
                if (File.Exists(deleteImagePath))
                {
                    File.Delete(deleteImagePath);
                }
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Avatar.FileName).ToString();
                blog.ImageUrl = imageName;
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Blog/", blog.ImageUrl);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await model.Avatar.CopyToAsync(stream);
                }
            }

            _blogRepository.EditBlogAsync(blog);
            await _blogRepository.SaveChangesAsync();

            return EditBlogResult.Success;
        }

        public async Task<FilterBlogViewModel> FilterBlogAsync(FilterBlogViewModel model)
        {
            return await _blogRepository.FilterBlogAsync(model);
        }

        public async Task<DeleteBlogViewModel> GetBlogForDeleteByIDAsync(int id)
        {
            return await _blogRepository.GetBlogForDeleteByIdAsync(id);

        }

        public async Task<EditBlogViewModel> GetBlogForEditByIDAsync(int id)
        {
            return await _blogRepository.GetBlogForEditByIdAsync(id);
        }
    }
}
