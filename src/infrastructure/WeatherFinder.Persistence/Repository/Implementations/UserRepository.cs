using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Data;
using WeatherFinder.Persistence.Repository.Abstractions;

namespace WeatherFinder.Persistence.Repository.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers(bool trackChanges)
        {
            return await FindAll(trackChanges);
        }

        public async Task<User> GetById(string id, bool trackChanges)
        {
            return await FindByCondition(u => u.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }
    }
}
