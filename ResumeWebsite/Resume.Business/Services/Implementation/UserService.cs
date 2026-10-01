using Resume.Business.Security;
using Resume.Business.Services.Interface;
using Resume.DAL.Models.User;
using Resume.DAL.Repositories.Interface;
using Resume.DAL.ViewModels.Account;
using Resume.DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Services.Implementation
{
	public class UserService : IUserService
	{
		#region Fields

		private readonly IUserRepository _userRepository;

		#endregion

		#region Constructors

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<CreateUserResult> CreateAsync(CreateUserViewModel model)
		{
            User user = new User()
			{
				CreateDate = DateTime.Now,
				Email = model.Email.Trim().ToLower(),
				FirstName = model.FirstName,
				LastName = model.LastName,
				Mobile = model.Mobile,
				IsActive = model.IsActive,
				Password = model.Password.Trim().EncodePasswordMD5(),
			};

            if (await _userRepository.ISDuplicatedEmailAsync(user.ID, model.Email.ToLower().Trim()))
            {
                return CreateUserResult.Error;
            }

            if (await _userRepository.ISDuplicatedMobileAsync(user.ID, model.Mobile.ToLower().Trim()))
            {
                return CreateUserResult.Error;
            }

            await _userRepository.InsertAsync(user);
			await _userRepository.SaveAsync();

			return CreateUserResult.Success;
		}

		public async Task<FilterUserViewModel> FilterAsync(FilterUserViewModel model)
		{
			return await _userRepository.FilterAsync(model);
		}

		public async Task<User> GetByEmailAsync(string email)
		{
			email = email.Trim().ToLower();

			return await _userRepository.GetByEmailAsync(email);
		}

		public async Task<EditeUserViewModel> GetForUserByIDAsync(int id)
		{
			var user = await _userRepository.GetByIDAsync(id);

			if (user == null)
			{
				return null;
			}

			return new EditeUserViewModel()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				Mobile = user.Mobile,
				IsActive = user.IsActive,
				Email = user.Email,
				ID = user.ID
			};
		}

		public async Task<UserDetailsViewModel> GetInformationAsync(int id)
		{
			var user = await _userRepository.GetByIDAsync(id);

			if (user == null)
			{
				return null;
			}

			return new UserDetailsViewModel()
			{
				CreateDate = user.CreateDate,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Mobile = user.Mobile,
				IsActive = user.IsActive,
				Email = user.Email,
				ID = user.ID
			};
		}

		public async Task<LoginResult> LoginAsync(LoginViewModel model)
		{
			model.Email = model.Email.Trim().ToLower();

			var user = await _userRepository.GetByEmailAsync(model.Email);

			if (user == null)
			{
				return LoginResult.UserNotFound;
			}

			string hashPassword = model.Password.Trim().EncodePasswordMD5();

			if (user.Password != hashPassword)
			{
				return LoginResult.UserNotFound;
			}

			return LoginResult.Success;
		}

		public async Task<EditUserResult> UpdateAsync(EditeUserViewModel model)
		{
			var user = await _userRepository.GetByIDAsync(model.ID);

			if (user == null)
			{
				return EditUserResult.UserNotFound;
			}

			user.FirstName = model.FirstName;
			user.LastName = model.LastName;
			user.Mobile = model.Mobile;
			user.IsActive = model.IsActive;
			user.Email = model.Email;

			_userRepository.Update(user);
			await _userRepository.SaveAsync();

			return EditUserResult.Success;
		}

		#endregion

	}
}
