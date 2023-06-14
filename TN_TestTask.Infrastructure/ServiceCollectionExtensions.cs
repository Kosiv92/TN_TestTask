using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TN_TestTask.Core;

namespace TN_TestTask.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, AppDbContext>()
                    .AddScoped<IEfRepository<Patrol>, EfRepository<Patrol>>()
                    .AddScoped<IEfRepository<Place>, EfRepository<Place>>()
                    .AddDbContext<AppDbContext>(options =>
                    {
                        //переделать на получение строки подключения из файла конфигурации
                        //var connectionString = configuration.GetConnectionString("PatrolDb");
                        options.UseSqlite("Data Source = PatrolDb");
                    });

            return services;
        }
    }
}
