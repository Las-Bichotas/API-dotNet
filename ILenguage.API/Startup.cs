using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Persistence.Repositories;
using ILenguage.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILenguage.API
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
            /*services.AddHttpClient("SubscriptionController", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");
            });*/

            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("LocalConnection"));

            });
            // Dependency Injection Configuration
            services.AddScoped<IRelatedUserRepository, RelatedUserRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<ISessionDetailRepository, SessionDetailRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISdayRepository, SdayRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
            services.AddScoped<IUserScheduleRepository, UserScheduleRepository>();
            services.AddScoped<ILanguageOfInterestRespository, LanguageOfInterestRepository>();
            services.AddScoped<ITopicOfInterestRepository, TopicOfInterestRepository>();
            services.AddScoped<IUserTopicRepository, UserTopicsRepository>();
            services.AddScoped<IUserLanguageRepository, UserLanguageRepository>();

            services.AddScoped<IMakePaymentService, MakePaymentService>();
            services.AddScoped<IRelatedUserService, RelatedUserService>();
            services.AddScoped<IRelatedUserService, RelatedUserService>();
            services.AddScoped<ISdayService, SdayService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ISessionDetailService, SessionDetailService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserSubscriptionService, UserSubscriptionService>();
            services.AddScoped<IUserScheduleService, UserScheduleService>();
            services.AddScoped<ILanguageOfInterestService, LanguageOfInterestService>();
            services.AddScoped<ITopicOfInterestService, TopicOfInterestService>();
            services.AddScoped<IUserTopicService, UserTopicService>();
            services.AddScoped<IUserLanguageService, UserLanguageService>();

            //Endpoinst case conventions configurations
            services.AddRouting(options => options.LowercaseUrls = true);
            //startup automapper
            services.AddAutoMapper(typeof(Startup));
            //documentacion setup
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ILenguage.API", Version = "v1" });
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ILenguage.API v1"));
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
