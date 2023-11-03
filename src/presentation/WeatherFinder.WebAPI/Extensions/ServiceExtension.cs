using Microsoft.EntityFrameworkCore;
using WeatherFinder.Persistence.Data;
using WeatherFinder.Persistence.Repository.Abstractions;
using WeatherFinder.Persistence.Repository.Implementations;

namespace WeatherFinder.WebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
        }
    }
}
