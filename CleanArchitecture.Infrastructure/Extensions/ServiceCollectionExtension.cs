using CleanArchitecture.ApplicationCore.CustomEntities;
using CleanArchitecture.ApplicationCore.Interfaces.Repositories;
using CleanArchitecture.ApplicationCore.Interfaces.Services;
using CleanArchitecture.ApplicationCore.Services;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanArchitectureContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("CleanArchitecture"))
           );

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(options => configuration.GetSection("Pagination").Bind(options));

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean Architecture API", Version = "v1" });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                doc.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            return services;
        }
    }
}
