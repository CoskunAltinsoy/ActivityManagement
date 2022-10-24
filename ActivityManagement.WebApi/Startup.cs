using ActivityManagement.Application.Interfaces.Repositories;
using ActivityManagement.Application.Interfaces.ServiceInterfaces;
using ActivityManagement.Application.Interfaces.UnitOfWorks;
using ActivityManagement.Application.Security.Jwt;
using ActivityManagement.Application.Services;
using ActivityManagement.Infrastructure.DependencyContainers;
using ActivityManagement.Infrastructure.Repositories;
using ActivityManagement.Infrastructure.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityManagement.WebApi
{
    public class Startup
    {
        IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddInfrastructureServices(Configuration);

            services.AddScoped<TokenGenerator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICityService, CityService>();
          //  services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
