using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetMe.Storing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BudgetMe.Domain
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
            services.AddControllers();

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if(connectionString == null)
            {
              Environment.SetEnvironmentVariable("DB_CONNECTION_STRING", "server=db;port=5432;database=postgres;username=postgres;password=postgres");
              connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            }            
            services.AddDbContext<BudgetDbContext>(options => options.UseNpgsql(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            UpdateDatabase(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BudgetDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
        
    }
}
