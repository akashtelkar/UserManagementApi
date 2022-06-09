using UserManagementApis.Models;

namespace UserManagementApis.Services
{
    public interface IUserService
    {
        public Task<List<UserDetails>> GetUserDetail();
        public Task<UserDetails?> GetUserDetailById(int userid);
        public Task CreateUser(UserDetails userDetails);
        public Task UpdateUser(UserDetails userDetails, int userid);
        public Task DeleteUser(int userid);
    }
}
