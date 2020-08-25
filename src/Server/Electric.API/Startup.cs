using AutoMapper;
using CommonShare.Logger;
using Electric.API.Extensions;
using Electric.Application.Commands;
using Electric.Application.Handlers;
using Electric.Application.PipelineBehaviours;
using Electric.Application.Queries;
using Electric.Application.Validators;
using Electric.Core.DbSettings;
using Electric.Core.Repositories;
using Electric.Infrastructure.Repository;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NLog;
using System.IO;
using System.Reflection;

namespace Electric.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.Configure<MongoDbSetting>(Configuration.GetSection(nameof(MongoDbSetting)));

            services.AddSingleton<IMongoDbSetting>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSetting>>().Value);
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            // Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Add Repository
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddTransient<IDeviceQuery, DeviceQuery>();

            // Add MediatR
            services.AddMediatR(typeof(CreateGateWayHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateGateWayHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteGateWayHandler).GetTypeInfo().Assembly);


            // Validators
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IValidator<CreateElectricMetterCommand>, CreateDeviceValidator>();
            services.AddTransient<IValidator<UpdateElectricMetterCommand>, UpdateDeviceValidator>();
            services.AddTransient<IValidator<DeleteElectricMetterCommand>, DeleteDeviceValidator>();
            #region Swagger DI

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Electric API", Version = "v1" });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.ConfigureExceptionHandler(logger);
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Electric API V1");
            });
        }
    }
}
