using Resume.DAL.Models.User;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Interface
{
    public interface IUserRepository
    {
        #region Methods

        Task InsertAsync(User user);

        Task<User> GetByIDAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<bool> ISDuplicatedEmailAsync(int id, string email);

        Task<bool> ISDuplicatedMobileAsync(int id, string mobile);

        void Update(User user);

        Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model);

        Task SaveAsync();

        #endregion
    }
}
