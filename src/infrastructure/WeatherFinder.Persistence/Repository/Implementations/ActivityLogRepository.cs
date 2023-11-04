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
    public class ActivityLogRepository : RepositoryBase<ActivityLog>, IActivityLogRepository
    {
        private readonly RepositoryContext repositoryContext;
        public ActivityLogRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public void CreateActivityLog(ActivityLog activityLog)
        {
            Create(activityLog);
        }

        public void DeleteActivityLog(ActivityLog activityLog)
        {
            Delete(activityLog);
        }

        public async Task<ActivityLog> GetActivityLogById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivityLog>> GetAllActivityLog(bool trackChanges)
        {
            return await FindAll(trackChanges);
        }

        public async Task<IEnumerable<ActivityLog>> GetAllUserActivityLog(string userId, bool trackChanges)
        {
            return await FindByCondition(a => a.UserId.Equals(userId), trackChanges).ToListAsync();
        }

        public void UpdateActivityLog(ActivityLog activityLog)
        {
            Update(activityLog);
        }
        public async Task SaveChangesAsync()
        {
            await repositoryContext.SaveChangesAsync();
        }
    }
}
