﻿using BooksManagementSystem.Application.ServiceInterfaces;
using BooksManagementSystem.Application.Services;
using BooksManagementSystem.Application.Validation;
using BooksManagementSystem.Data.Helper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BooksManagementSystem.Application
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Configration for Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configration for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Configration for Fluent validation 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Configration for Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddMemoryCache();

            services.Configure<JwtOptions>(configuration.GetSection("JWT"));

            return services;
        }
    }
}
