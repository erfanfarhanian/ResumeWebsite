using Resume.DAL.ViewModels.Blog;
using Resume.DAL.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IBlogService
    {
        Task<FilterBlogViewModel> FilterBlogAsync(FilterBlogViewModel model);
        Task<CreateBlogResult> CreateBlogAsync(CreateBlogViewModel model);
        Task<EditBlogResult> EditBlogAsync(EditBlogViewModel model);
        Task<DeleteBlogResult> DeleteBlogAsync(DeleteBlogViewModel model);
        Task<EditBlogViewModel> GetBlogForEditByIDAsync(int id);
        Task<DeleteBlogViewModel> GetBlogForDeleteByIDAsync(int id);
    }
}
