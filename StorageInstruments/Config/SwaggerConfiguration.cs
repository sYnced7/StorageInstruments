using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageInstruments.Config
{
    public class SwaggerConfiguration
    {
        public static IServiceCollection ConfigSwagger(IServiceCollection services)
        {
            services.AddOpenApiDocument();
            return services;
        }
    }
}
