using CleanArchitecture.ApplicationCore.Entities;
using CleanArchitecture.ApplicationCore.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CleanArchitectureContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetByEmail(string email)
        {
            return await _entities.Where(x => x.Email == email).ToListAsync();
        }
    }
}
