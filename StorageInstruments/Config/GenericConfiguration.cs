using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageInstruments.Config
{
    public class GenericConfiguration
    {
        public static IServiceCollection Config(IServiceCollection services, IConfiguration Configuration)
        {
            services = ConfigGeneric(services);
            services = ContainerConfiguration.ConfigContext(services);
            services = ContextConfiguration.ConfigContext(services, Configuration);
            services = SwaggerConfiguration.ConfigSwagger(services);
            return services;
        }

        public static IServiceCollection ConfigGeneric(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();
            services.AddRazorPages();

            return services;
        }
    }
}
