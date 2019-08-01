using TrivaGame.Managers;
using TriviaGame.Core.Interfaces.Managers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddTransient<IToDoManager, ToDoManager>();

            return services;
        }
    }
}
