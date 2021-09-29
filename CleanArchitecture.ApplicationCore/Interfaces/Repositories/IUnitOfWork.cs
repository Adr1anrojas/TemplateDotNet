using System;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        IUserRepository UserRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
