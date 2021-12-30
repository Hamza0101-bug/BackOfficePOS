using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.GenereicRepository;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(MappingProfilescs));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            // Add services to the container.
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();
                    var errorresponse = new ApiValidationErrorResponse
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(errorresponse);
                };
            });
            return services;
        }
    }
}
