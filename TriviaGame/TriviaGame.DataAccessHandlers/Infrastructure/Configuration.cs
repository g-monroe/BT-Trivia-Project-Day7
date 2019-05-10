using Microsoft.EntityFrameworkCore;
using TriviaGame.Core.Interfaces.DataAccessHandlers;
using TriviaGame.DataAccessHandlers;
using TriviaGame.DataAccessHandlers.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddDataAccessHandlers(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(provider => new TriviaGameContext(connectionString)); 
            services.AddDbContext<TriviaGameContext>(ServiceLifetime.Scoped);
            services.AddEntityFrameworkSqlServer();

            services.AddTransient<IToDoHandler, ToDoHandler>();

            // TODO: Configure Entity Framework
            return services;
        } 
    }
}
