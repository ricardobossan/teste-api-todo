using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kobold.TodoApp.Api.Models;
using Kobold.TodoApp.Api.Services;
using Kobold.TodoApp.Api.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Kobold.TodoApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
              .AddDbContext<TodoDbContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("MySqlConnection"),
                 mysqlOptions => mysqlOptions.ServerVersion(new Version(5, 7, 43), ServerType.MySql).EnableRetryOnFailure()
             ));

            services.AddControllers(options =>
           {
               options.Filters.Add(typeof(GlobalException));
           });
            services.AddScoped<TodoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TodoDbContext>();
                context.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
