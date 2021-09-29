using CleanArchitecture.ApplicationCore.CustomEntities;
using CleanArchitecture.ApplicationCore.Entities;
using CleanArchitecture.ApplicationCore.QueryFilters;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Interfaces.Services
{
    public interface IUserService
    {
        PagedList<User> GetUsers(UserQueryFilter filters);

        Task<User> GetUser(int id);

        Task InsertUser(User user);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);
    }
}
