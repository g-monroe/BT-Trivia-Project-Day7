using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SuperheroBattle.BusinessLogic.Managers;
using SuperheroBattle.Core.Managers;
using SuperheroBattle.DataAccessHandlers.Handlers;

namespace SuperheroBattle.Client.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(opt =>
                    {
                        opt.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    });
            services.AddDbContext<DataAccessHandlers.SuperheroBattleContext>(options =>
            {
                options.UseSqlServer(Configuration["DefaultConnection"],
                                     b => b.MigrationsAssembly("SuperheroBattle.Client.Api"));
                options.EnableSensitiveDataLogging(true);
            });
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                                  builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Add managers, engines, handlers here
            services.AddTransient<IBattleManager, BattleManager>();
            services.AddTransient<ISuperheroHandler, SuperheroHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
