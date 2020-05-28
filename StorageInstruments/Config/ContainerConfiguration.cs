using Microsoft.Extensions.DependencyInjection;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.Service;
using StorageInstruments.Utils;

namespace StorageInstruments.Config
{
    public class ContainerConfiguration
    {
        public static IServiceCollection ConfigContext(IServiceCollection services)
        {
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddSingleton<ISeriLog, SeriLog>();

            return services;
        }
    }
}
