﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Domain.Services;
using TaskManager.Infrastructure.Data.Context;
using TaskManager.Infrastructure.Data.Repositories.BoardRepository;
using TaskManager.Infrastructure.Data.Repositories.TaskRepository;
using TaskManager.Infrastructure.Data.Repositories.UserGroupRepository;
using TaskManager.Infrastructure.Data.Repositories.UserRepository;

namespace TaskManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //Recupera a string de conexão
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //CORS
            // services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //END CORS

            var conn = Configuration.GetConnectionString("TaskManagerDB");

            services.AddDbContext<TaskManagerContext>(option => option.UseLazyLoadingProxies()
                                               .UseNpgsql(conn, m => m.MigrationsAssembly("TaskManager.Infrastructure.Data")));

            //Services
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRespository>();

            services.AddScoped<IBoardAppService, BoardAppService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IBoardRepository, BoardRepository>();

            services.AddScoped<ITaskAppService, TaskAppService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            services.AddScoped<IUserGroupAppService, UserGroupAppService>();
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();

            services.AddMvc()
         .AddJsonOptions(
             options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //CORS
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
