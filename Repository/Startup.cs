using FluentAssertions.Common;
using GenericRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Repository.Models;
using Amna.Interfaces;
using Amna.Repository;

namespace Repository
{
    namespace Service.Models
{
        namespace Repository.Service.Models.Repository.Service
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
                    Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                    string dbConnectionString = this.Configuration.GetConnectionString("Database");
                    services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
                    {
                        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    }));

                    services.AddMvc();
                    services.AddSwaggerGen(c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "My API",
                            Description = "ASP.NET Core Web API"
                        });
                    });
                    //services.AddSwaggerGen();
                    services.AddControllers()
                           .ConfigureApiBehaviorOptions(options =>
                           {
                               options.SuppressModelStateInvalidFilter = true;
                           });
                    services.AddControllers().AddJsonOptions(options => {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;

                    });
                    services.AddCors(options =>
                    {
                        options.AddPolicy(name: "AllowCORS", builder =>
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyMethod()
                                   .AllowAnyHeader();
                        });

                    });
                    services.AddScoped<IRepositoryCountry, RepositoryCountry>();
                    services.AddScoped<IRepositoryCity, RepositoryCity>();
                    services.AddScoped<IRepositoryPermission, RepositoryPermission>();
                    services.AddScoped<IRepositoryRole, RepositoryRole>();
                    services.AddScoped<IRepositoryRolePermission, RepositoryRolePermission>();
                    services.AddScoped<IRepositoryUsers, RepositoryUsers>();

                }


                
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }

                    else
                    {
                        app.UseExceptionHandler("/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                    }
                    app.UseCors("AllowCORS");
                    app.UseCors(options =>
                    options.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
                        c.RoutePrefix = string.Empty;
                    });

                    app.UseHttpsRedirection();
                    app.UseStaticFiles();

                    app.UseRouting();

                    app.UseAuthorization();

                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                    app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                    app.UseHttpsRedirection();
                }
            }
        }
    }
}

