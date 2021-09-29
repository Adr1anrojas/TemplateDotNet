using CleanArchitecture.ApplicationCore.Entities;
using CleanArchitecture.ApplicationCore.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CleanArchitectureContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(CleanArchitectureContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }
    }
}
