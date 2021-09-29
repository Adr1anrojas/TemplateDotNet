using CleanArchitecture.ApplicationCore.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}
