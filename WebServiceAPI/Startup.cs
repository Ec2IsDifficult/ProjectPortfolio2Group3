using System;
using System.Text.Json.Serialization;
using Dataservices;
using Dataservices.IRepositories;
using Dataservices.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebServiceAPI.Middleware;
//install Micsrosoft.AspNetCore.Mvc.NewtonsoftJson version 5.0.12

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
            services.AddCors();
            services.AddMvc();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<ITitleRepository, TitleRepository>();
            services.AddSingleton<IEpisodeRepository, EpisodeRepository>();
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddDbContext<ImdbContext>(ServiceLifetime.Singleton);

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings
               .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews();

            /*
             * Fixing the error "A possible object cycle was detected"
             * in different versions of ASP.NET Core
             * sourced from: shorturl.at/nHKWZ
             */
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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

            app.UseFileServer();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseJwtAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
