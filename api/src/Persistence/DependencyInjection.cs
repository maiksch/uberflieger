using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<UberfliegerContext>(options =>
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

                options.UseLoggerFactory(loggerFactory)
                       .EnableSensitiveDataLogging()
                       .UseNpgsql(configuration.GetConnectionString("Database"));
            });
        }
    }
}
