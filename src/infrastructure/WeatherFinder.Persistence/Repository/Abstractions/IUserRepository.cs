using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Domain.Models;

namespace WeatherFinder.Persistence.Repository.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetById(string id, bool trackChanges);
        Task<IEnumerable<User>> GetAllUsers(bool trackChanges);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void CreateUser(User user);
    }
}
