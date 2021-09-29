using CleanArchitecture.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetByEmail(string email);
    }
}
