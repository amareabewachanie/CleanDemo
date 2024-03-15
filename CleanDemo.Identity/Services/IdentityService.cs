using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CleanDemo.Application.Contracts.Identity;
using CleanDemo.Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanDemo.Identity.Services
{
    public class IdentityService : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<(bool isSucceed, int userId)> CreateUserAsync(string userName, string password, string email, string fullName, List<string> roles)
        {
            var user = new ApplicationUser
            {
                FullName = fullName,
                UserName = userName,
                Email = email,
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("User doesn't created");
            }
            return (result.Succeeded, user.Id);
        }

        public async Task<bool> SignInUserAsync(string userName, string password)
        {
            var success = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            return success.Succeeded;
        }

        public async Task<int> GetUserIdAsync(string userName)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == userName);
            if (user == null)
                throw new NotFoundException($"{typeof(ApplicationUser)}", userName);
            var userId = await _userManager.GetUserIdAsync(user);
            return Int32.Parse(userId);
        }

        public Task<(int userId, string fullName, string email, IList<string> roles)> GetUserDetailsAsync(int userId)
        {
            
        }

        public Task<(int userId, string fullName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUniqueUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<List<(int id, string fullName, string userName, string email)>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<(int id, string userName, string email, IList<string> roles)>> GetAllUserDetailsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserProfile(int userId, string fullName, string email, IList<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<(int id, string roleName)>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(int id, string roleName)> GetRoleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRole(int id, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(int userId, string role)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUserRolesAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AssignUserToRole(string userName, IList<string> roles)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUsersRole(string userName, IList<string> usersRole)
        {
            throw new NotImplementedException();
        }
    }
}
