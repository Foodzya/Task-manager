using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Taskmanager.Data.Context;
using Taskmanager.Repositories;
using Taskmanager.Repositories.Interfaces;
using Taskmanager.Services;
using Taskmanager.Services.Interfaces;

namespace Taskmanager
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
            services.AddDbContext<TaskManagerContext>(opt => opt.UseSqlite("name=ConnectionStrings:TodolistDatabase"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITodolistRepository, TodolistRepository>();
            services.AddTransient<ITodoitemRepository, TodoitemRepository>();
            services.AddTransient<IPriorityRepository, PriorityRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITodolistService, TodolistService>();
            services.AddTransient<ITodoitemService, TodoitemService>();
            services.AddTransient<IPriorityService, PriorityService>();
            services.AddTransient<INoteService, NoteService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
