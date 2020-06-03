using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorageInstruments.Data;

namespace StorageInstruments.Config
{
    public class ContextConfiguration
    {
        public static IServiceCollection ConfigContext(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<InstrumentDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("InstrumentsDb"));
            });

            return services;
        }
    }
}
