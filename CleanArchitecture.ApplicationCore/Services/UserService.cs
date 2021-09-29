using CleanArchitecture.ApplicationCore.CustomEntities;
using CleanArchitecture.ApplicationCore.Entities;
using CleanArchitecture.ApplicationCore.Exceptions;
using CleanArchitecture.ApplicationCore.Interfaces.Repositories;
using CleanArchitecture.ApplicationCore.Interfaces.Services;
using CleanArchitecture.ApplicationCore.QueryFilters;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public UserService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public PagedList<User> GetUsers(UserQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var users = _unitOfWork.UserRepository.GetAll();

            if (filters.Role != null)
            {
                users = users.Where(x => x.Role == filters.Role);
            }

            if (filters.BirthDay != null)
            {
                users = users.Where(user => user.BirthDay.CompareTo(filters.BirthDay) == 0);
            }

            var pagedPosts = PagedList<User>.Create(users, filters.PageNumber, filters.PageSize);
            return pagedPosts;
        }

        public async Task InsertUser(User user)
        {
            var searchEmail = await _unitOfWork.UserRepository.GetByEmail(user.Email);
            if (searchEmail.Any())
            {
                throw new BusinessException("The mail provided is already in use.");
            }
            await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var existingUser = await _unitOfWork.UserRepository.GetById(user.Id);
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.BirthDay = user.BirthDay;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Role = user.Role;
            _unitOfWork.UserRepository.Update(existingUser);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
