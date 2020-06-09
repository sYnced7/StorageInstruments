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
using User = StorageInstruments.Model.User;

namespace StorageInstruments.Config
{
    public class ContainerConfiguration
    {
        public static IServiceCollection ConfigContext(IServiceCollection services)
        {
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<ISeriLog, SeriLog>();


            return services;
        }
    }
}
