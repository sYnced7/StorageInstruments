using Microsoft.Extensions.DependencyInjection;
using StorageInstruments.Data;
using StorageInstruments.Data.Migrations;
using StorageInstruments.DataContract;
using StorageInstruments.DataContract.Repository;
using StorageInstruments.DataContract.Service;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.Model;
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
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<,>));
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ISeriLog, SeriLog>();

            return services;
        }
    }
}
