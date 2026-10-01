using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.Blog;
using Resume.DAL.Models.Portfolio;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Blog;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class BlogRepository : IBlogRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructor

        public BlogRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        public void DeleteBlogAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
        }

        public void EditBlogAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
        }

        public async Task<FilterBlogViewModel> FilterBlogAsync(FilterBlogViewModel model)
        {
            var query = _context.Blogs.AsQueryable();

            #region Filters

            if (!string.IsNullOrEmpty(model.Title))
            {
                query = query.Where(b => b.Title.Contains(model.Title));
            }

            if (!string.IsNullOrEmpty(model.BlogDate))
            {
                query = query.Where(b => b.BlogDate.Contains(model.BlogDate));
            }

            #endregion

            query = query.OrderByDescending(b => b.CreateDate);

            #region Pagination

            await model.Paging(query.Select(b => new BlogViewModel()
            {
                ID = b.ID,
                Title = b.Title,
                BlogDate = b.BlogDate,
                CreateDate = b.CreateDate,
                ShortText = b.ShortText,
                LongText = b.LongText,
                ImageUrl = b.ImageUrl
            }));

            #endregion

            return model;
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<DeleteBlogViewModel> GetBlogForDeleteByIdAsync(int id)
        {
            return await _context.Blogs.Select(b => new DeleteBlogViewModel()
            {
                ID = b.ID,
                Title = b.Title,
                BlogDate = b.BlogDate,
                ShortText = b.ShortText,
                LongText = b.LongText,
                ImageUrl = b.ImageUrl
            }).FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<EditBlogViewModel> GetBlogForEditByIdAsync(int id)
        {
            return await _context.Blogs.Select(b => new EditBlogViewModel()
            {
                ID = b.ID,
                Title = b.Title,
                BlogDate = b.BlogDate,
                ShortText = b.ShortText,
                LongText = b.LongText,
                ImageUrl = b.ImageUrl
            }).FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task InsertBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
