using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDemo.Application.Contracts.Identity
{
    public interface IIdentityRepository
    {
        // User section
        Task<(bool isSucceed, int userId)> CreateUserAsync(string userName, string password, string email, string fullName,
            List<string> roles);

        Task<bool> SignInUserAsync(string userName, string password);
        Task<int> GetUserIdAsync(string userName);
        Task<(int userId, string fullName, string email, IList<string> roles)> GetUserDetailsAsync(int userId);
        Task<(int userId, string fullName, string email, IList<string> roles)> GetUserDetailsByUserNameAsync(string userName);
        Task<string> GetUserNameAsync(int userId);
        Task<bool> DeleteUserAsync(int userId);
        Task<bool> IsUniqueUserName(string userName);
        Task<List<(int id, string fullName, string userName, string email)>> GetAllUsersAsync();
        Task<List<(int id, string userName, string email, IList<string> roles)>> GetAllUserDetailsAsync();
        Task<bool> UpdateUserProfile(int userId, string fullName, string email, IList<string> roles);

        // Role Section

        Task<bool> CreateRoleAsync();
        Task<bool> DeleteRoleAsync(int roleId);
        Task<List<(int id, string roleName)>> GetRolesAsync();
        Task<(int id, string roleName)> GetRoleByIdAsync(int id);
        Task<bool> UpdateRole(int id, string roleName);

        // User's Role section

        Task<bool> IsInRoleAsync(int userId, string role);
        Task<List<string>> GetUserRolesAsync(int userId);
        Task<bool> AssignUserToRole(string userName, IList<string> roles);
        Task<bool> UpdateUsersRole(string userName, IList<string> usersRole);

    }
}
