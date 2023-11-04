using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherFinder.Domain.Models;

namespace WeatherFinder.Persistence.Repository.Abstractions
{
    public interface IActivityLogRepository
    {
        Task<ActivityLog> GetActivityLogById(int id, bool trackChanges);
        Task<IEnumerable<ActivityLog>> GetAllUserActivityLog(string userId, bool trackChanges);
        Task<IEnumerable<ActivityLog>> GetAllActivityLog(bool trackChanges);
        void UpdateActivityLog(ActivityLog activityLog);
        void DeleteActivityLog(ActivityLog activityLog);
        void CreateActivityLog(ActivityLog activityLog);
        Task SaveChangesAsync();
    }
}
