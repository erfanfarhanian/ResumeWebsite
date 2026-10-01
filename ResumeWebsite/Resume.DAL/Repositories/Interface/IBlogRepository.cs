using Resume.DAL.Models.Blog;
using Resume.DAL.ViewModels.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IBlogRepository
    {
        Task<FilterBlogViewModel> FilterBlogAsync(FilterBlogViewModel model);
        Task InsertBlogAsync(Blog blog);
        Task<Blog> GetBlogByIdAsync(int id);
        void EditBlogAsync(Blog blog);
        void DeleteBlogAsync(Blog blog);
        Task<EditBlogViewModel> GetBlogForEditByIdAsync(int id);
        Task<DeleteBlogViewModel> GetBlogForDeleteByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
