using AutoMapper;
using IndieVisible.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IndieVisible.Web.Extensions
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}
