using BackOfficePOS.Errors;
using BackOfficePOS.Helpers;
using Core.Interfaces;
using Core.Interfaces.GenericInterface;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.GenereicRepository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackOfficePOS.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(MappingProfilescs));
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<ITokenServices, TokenServices>();

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
