using Microsoft.Extensions.DependencyInjection;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Service;

namespace StorageInstruments.Config
{
    public class ContainerConfiguration
    {
        public static IServiceCollection ConfigContext(IServiceCollection services)
        {
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            return services;
        }
    }
}
