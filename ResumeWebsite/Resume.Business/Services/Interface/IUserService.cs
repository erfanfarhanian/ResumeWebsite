using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Interface
{
    public interface IUserService
    {
        #region Methods

        Task<CreateUserResult> CreateAsync(CreateUserViewModel model);

        Task<EditeUserViewModel> GetForUserByIDAsync(int id);

        Task<EditUserResult> UpdateAsync(EditeUserViewModel model);

        Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);

        Task<LoginResult> LoginAsync(LoginViewModel model);
        
        Task<User> GetByEmailAsync(string email);

        Task<UserDetailsViewModel> GetInformationAsync(int id);

        #endregion
    }
}
