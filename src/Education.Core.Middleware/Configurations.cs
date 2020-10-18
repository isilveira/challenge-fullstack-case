using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Classes;
using Education.Core.Domain.Interfaces.Services.Default.Schools;
using Education.Core.Domain.Services.Default.Classes;
using Education.Core.Domain.Services.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Education.Core.Domain.Validations.Specifications.Default.Classes;
using Education.Core.Domain.Validations.Specifications.Default.Schools;
using Education.Core.Infrastructures.Data.Contexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper.Middleware;
using System;
using System.Reflection;

namespace Education.Core.Middleware
{
    public static class Configurations
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services, IConfiguration configuration, Assembly presentationAssembly)
        {
            var defaultConnectionAssembly = typeof(DefaultDbContext).GetTypeInfo().Assembly;
            services.AddDbContext<IDefaultDbContext, DefaultDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(defaultConnectionAssembly.GetName().Name)));
            
            services.AddDbContext<IDefaultDbContextQuery, DefaultDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(defaultConnectionAssembly.GetName().Name)));

            services.AddTransient<SchoolValidator>();
            services.AddTransient<SchoolNameAlreadyExistsSpecification>();

            services.AddTransient<ClassValidator>();
            services.AddTransient<ClassNameAlreadyExistsSpecification>();
            services.AddTransient<ClassCodeAlreadyExistsSpecification>();

            services.AddTransient<PutSchoolSpecificationsValidator>();
            services.AddTransient<PostSchoolSpecificationsValidator>();
            services.AddTransient<PatchSchoolSpecificationsValidator>();
            services.AddTransient<DeleteSchoolSpecificationsValidator>();

            services.AddTransient<PutClassSpecificationsValidator>();
            services.AddTransient<PostClassSpecificationsValidator>();
            services.AddTransient<PatchClassSpecificationsValidator>();
            services.AddTransient<DeleteClassSpecificationsValidator>();

            services.AddTransient<IPutSchoolService, PutSchoolService>();
            services.AddTransient<IPostSchoolService, PostSchoolService>();
            services.AddTransient<IPatchSchoolService, PatchSchoolService>();
            services.AddTransient<IDeleteSchoolService, DeleteSchoolService>();

            services.AddTransient<IPutClassService, PutClassService>();
            services.AddTransient<IPostClassService, PostClassService>();
            services.AddTransient<IPatchClassService, PatchClassService>();
            services.AddTransient<IDeleteClassService, DeleteClassService>();

            var assembly = AppDomain.CurrentDomain.Load("Education.Core.Application");

            services.AddMediatR(assembly);

            services.AddModelWrapper()
                .AddDefaultReturnedCollectionSize(10)
                .AddMinimumReturnedCollectionSize(1)
                .AddMaximumReturnedCollectionSize(100)
                .AddQueryTermsMinimumSize(3)
                .AddSuppressedTerms(new string[] { "the" });

            // YOUR CODE GOES HERE
            return services;
        }

        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder app)
        {
            //app.UseAuthentication();
            //app.UseAuthorization();
            // YOUR CODE GOES HERE
            return app;
        }
    }
}
