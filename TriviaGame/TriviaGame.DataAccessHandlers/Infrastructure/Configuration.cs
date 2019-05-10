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
            services.AddScoped<TriviaGameContext>(); 
            services.AddDbContext<TriviaGameContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IToDoHandler, ToDoHandler>();

            // TODO: Configure Entity Framework
            return services;
        } 
    }
}
