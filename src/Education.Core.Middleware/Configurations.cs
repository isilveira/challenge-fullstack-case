using Education.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Education.Core.Domain.Interfaces.Services.Default.Classes;
using Education.Core.Domain.Interfaces.Services.Default.Samples;
using Education.Core.Domain.Interfaces.Services.Default.Schools;
using Education.Core.Domain.Interfaces.Services.Default.Students;
using Education.Core.Domain.Services.Default.Classes;
using Education.Core.Domain.Services.Default.Samples;
using Education.Core.Domain.Services.Default.Schools;
using Education.Core.Domain.Services.Default.Students;
using Education.Core.Domain.Validations.DomainValidations.Default.Classes;
using Education.Core.Domain.Validations.DomainValidations.Default.Samples;
using Education.Core.Domain.Validations.DomainValidations.Default.Schools;
using Education.Core.Domain.Validations.DomainValidations.Default.Students;
using Education.Core.Domain.Validations.EntityValidations.Default;
using Education.Core.Domain.Validations.EntityValidationsDefault;
using Education.Core.Domain.Validations.Specifications.Default.Samples;
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
            services.AddDbContext<IDefaultDbContext, DefaultDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(presentationAssembly.GetName().Name)));
            
            services.AddDbContext<IDefaultDbContextQuery, DefaultDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsAssembly(presentationAssembly.GetName().Name)));

            services.AddTransient<SampleValidator>();
            services.AddTransient<SampleDescriptionAlreadyExistsSpecification>();

            services.AddTransient<SchoolValidator>();

            services.AddTransient<ClassValidator>();

            services.AddTransient<StudentValidator>();

            services.AddTransient<PutSampleSpecificationsValidator>();
            services.AddTransient<PostSampleSpecificationsValidator>();
            services.AddTransient<PatchSampleSpecificationsValidator>();
            services.AddTransient<DeleteSampleSpecificationsValidator>();

            services.AddTransient<PutSchoolSpecificationsValidator>();
            services.AddTransient<PostSchoolSpecificationsValidator>();
            services.AddTransient<PatchSchoolSpecificationsValidator>();
            services.AddTransient<DeleteSchoolSpecificationsValidator>();

            services.AddTransient<PutClassSpecificationsValidator>();
            services.AddTransient<PostClassSpecificationsValidator>();
            services.AddTransient<PatchClassSpecificationsValidator>();
            services.AddTransient<DeleteClassSpecificationsValidator>();

            services.AddTransient<PutStudentSpecificationsValidator>();
            services.AddTransient<PostStudentSpecificationsValidator>();
            services.AddTransient<PatchStudentSpecificationsValidator>();
            services.AddTransient<DeleteStudentSpecificationsValidator>();

            services.AddTransient<IPutSampleService, PutSampleService>();
            services.AddTransient<IPostSampleService, PostSampleService>();
            services.AddTransient<IPatchSampleService, PatchSampleService>();
            services.AddTransient<IDeleteSampleService, DeleteSampleService>();

            services.AddTransient<IPutSchoolService, PutSchoolService>();
            services.AddTransient<IPostSchoolService, PostSchoolService>();
            services.AddTransient<IPatchSchoolService, PatchSchoolService>();
            services.AddTransient<IDeleteSchoolService, DeleteSchoolService>();

            services.AddTransient<IPutClassService, PutClassService>();
            services.AddTransient<IPostClassService, PostClassService>();
            services.AddTransient<IPatchClassService, PatchClassService>();
            services.AddTransient<IDeleteClassService, DeleteClassService>();

            services.AddTransient<IPutStudentService, PutStudentService>();
            services.AddTransient<IPostStudentService, PostStudentService>();
            services.AddTransient<IPatchStudentService, PatchStudentService>();
            services.AddTransient<IDeleteStudentService, DeleteStudentService>();

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
