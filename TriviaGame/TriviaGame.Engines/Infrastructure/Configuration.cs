using System;
using System.Collections.Generic;
using System.Text;
using TriviaGame.Core.Interfaces.Engines;
using TriviaGame.Engines;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Configuration
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddTransient<IToDoEngine, ToDoEngine>();

            return services;
        }
    }
}
