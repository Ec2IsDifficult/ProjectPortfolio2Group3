﻿using System;
using Dataservices;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebServiceAPI.Middleware;

namespace WebServiceAPI
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
            services.AddMvc();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            // 2 alternativer
            services.AddSingleton<ITitleRepository, TitleRepository>();
            
            // ---
            
            
            services.AddSingleton<IEpisodeRepository, EpisodeRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            
            services.AddDbContext<ImdbContext>(ServiceLifetime.Singleton);
            //services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings
              //  .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseJwtAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
