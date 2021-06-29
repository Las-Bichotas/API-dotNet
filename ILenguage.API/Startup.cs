using ILenguage.API.Domain.Persistence.Contexts;
using ILenguage.API.Domain.Persistence.Repositories;
using ILenguage.API.Domain.Repositories;
using ILenguage.API.Domain.Services;
using ILenguage.API.Persistence.Repositories;
using ILenguage.API.Services;
using ILenguage.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            //Add CORS Support
            services.AddCors();
            services.AddControllers();

            //AppSettings Section Reference
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JSON Web Token Authentication Configuration
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //Authentication Service Configuration
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer=false,
                        ValidateAudience=false
                    };
                });
            /*services.AddHttpClient("SubscriptionController", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");
            });*/

            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {


                options.UseMySQL(Configuration.GetConnectionString("LocalConnectionHUAMANI"));


            });
            // Dependency Injection Configuration
            services.AddScoped<IRelatedUserRepository, RelatedUserRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserSubscriptionRepository, UserSubscriptionRepository>();
            services.AddScoped<ILanguageOfInterestRespository, LanguageOfInterestRepository>();
            services.AddScoped<ITopicOfInterestRepository, TopicOfInterestRepository>();
            services.AddScoped<IUserTopicRepository, UserTopicsRepository>();
            services.AddScoped<IUserLanguageRepository, UserLanguageRepository>();
            services.AddScoped<IBadgetsRepository, BadgetsRepository>();
            services.AddScoped<IUserBadgetsRepository, UserBadgetsRespository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();

            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IMakePaymentService, MakePaymentService>();
            services.AddScoped<IRelatedUserService, RelatedUserService>();
            services.AddScoped<IRelatedUserService, RelatedUserService>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserSubscriptionService, UserSubscriptionService>();
            services.AddScoped<ILanguageOfInterestService, LanguageOfInterestService>();
            services.AddScoped<ITopicOfInterestService, TopicOfInterestService>();
            services.AddScoped<IUserTopicService, UserTopicService>();
            services.AddScoped<IUserLanguageService, UserLanguageService>();
            services.AddScoped<IUserBadgetsService, UserBadgetsService>();
            services.AddScoped<IBadgetService, BadgetsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSessionService, UserSessionService>();
            services.AddScoped<ICommentService, CommentService>();

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

            //CORS Configuration
            app.UseCors(x => x.SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            app.UseAuthentication();
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
