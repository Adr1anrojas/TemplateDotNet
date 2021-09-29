using CleanArchitecture.ApplicationCore.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Data;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanArchitectureContext _context;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(CleanArchitectureContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
