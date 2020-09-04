using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAB.BusinessLogic.Implementations;
using MAB.BusinessLogic.Interfaces;
using MAB.DataAccess;
using MAB.UnitOfWork;
using MAB.WebAPI.Authentication;
using MAB.WebAPI.GlobalErrorHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MAB.WebAPI
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
            services.AddTransient<ITokenLogic, TokenLogic>();
            services.AddTransient<ISupplierLogic, SupplierLogic>();
            services.AddTransient<ICustomerLogic, CustomerLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();

            services.AddSingleton<IUnitOfWork>(option => new MABUnitOfWork(
                Configuration.GetConnectionString("Database")
                ));

            var tokenProvider = new JwtProvider("issuer", "audeince", "northwind_2000");
            services.AddSingleton<ITokenProvider>(tokenProvider);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
               });
            services.AddAuthorization( auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();


            app.ConfigureExceptionHandler();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
