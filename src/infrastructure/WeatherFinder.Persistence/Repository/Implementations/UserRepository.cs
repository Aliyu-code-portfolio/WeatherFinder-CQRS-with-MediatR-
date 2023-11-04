using Microsoft.EntityFrameworkCore;
using WeatherFinder.Domain.Models;
using WeatherFinder.Persistence.Data;
using WeatherFinder.Persistence.Repository.Abstractions;

namespace WeatherFinder.Persistence.Repository.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        RepositoryContext repositoryContext;
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
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
        public async Task SaveChangeAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
