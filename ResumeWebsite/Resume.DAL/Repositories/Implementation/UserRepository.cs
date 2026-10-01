using Microsoft.EntityFrameworkCore;
using Resume.DAL.Context;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Resume.DAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly ResumeContext _context;

        #endregion

        #region Constructors

        public UserRepository(ResumeContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task InsertAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByIDAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ISDuplicatedEmailAsync(int id, string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.ID != id);
        }

        public async Task<bool> ISDuplicatedMobileAsync(int id, string mobile)
        {
            return await _context.Users.AnyAsync(u => u.Mobile == mobile && u.ID != id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model)
        {
            var query = _context.Users.AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(model.Email))
            {
                query = query.Where(u => EF.Functions.Like(u.Email, $"%{model.Email}%"));
            }

            if (!string.IsNullOrEmpty(model.Mobile))
            {
                query = query.Where(u => EF.Functions.Like(u.Mobile, $"%{model.Mobile}%"));
            }

            #endregion

            #region Paging

            await model.Paging(query.Select(u => new UserDetailsViewModel()
            {
                CreateDate = u.CreateDate,
                Email = u.Email,
                Mobile = u.Mobile,
                FirstName = u.FirstName,
                LastName = u.LastName,
                ID = u.ID,
                IsActive = u.IsActive
            }));

            #endregion

            return model;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.IsActive);
        }

        #endregion

    }
}
