using Microsoft.Extensions.DependencyInjection;
using Property.Application.Interfaces;
using Property.Application.Services;
using Property.Domain.Interfaces;
using Property.Infrastructure.Data.Repositories;

namespace Property.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            
            services.AddScoped<IPropertyImageService, PropertyImageService>();
            services.AddScoped<IPropertyImage, PropertyImageRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwner, OwnerRepository>();

        }
    }
}
