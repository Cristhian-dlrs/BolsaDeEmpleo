using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BolsaDeEmpleo.BackEnd.Core.Interfaces;
using BolsaDeEmpleo.BackEnd.Core.Services;
using BolsaDeEmpleo.BackEnd.Infrastructure.Data;
using BolsaDeEmpleo.BackEnd.Infrastructure.Filters;
using BolsaDeEmpleo.BackEnd.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
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

namespace BolsaDeEmpleo.BackEnd.API
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services
                .AddControllers(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .AddNewtonsoftJson(op =>
                {
                    op.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    op.SerializerSettings.NullValueHandling = 
                        Newtonsoft.Json.NullValueHandling.Ignore;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                });

            services.AddDbContext<DataBaseContext>(opts =>
            {
                opts.UseSqlServer(
                    Configuration.GetConnectionString("BolsaDeEmpleo"),
                     b => b.MigrationsAssembly("BolsaDeEmpleo.BackEnd.API"));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJobsOfferceService, JobsOfferService>();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "BolsaDeEmpleo.BackEnd.API", Version = "v1" });
            });

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BolsaDeEmpleo.BackEnd.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}