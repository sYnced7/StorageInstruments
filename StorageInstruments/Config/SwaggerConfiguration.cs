using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder AppBuilderConfig(IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();

            return app;
        }
    }
}
