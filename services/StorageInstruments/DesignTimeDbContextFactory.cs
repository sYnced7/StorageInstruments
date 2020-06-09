using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using StorageInstruments.Data;
using System.IO;

namespace StorageInstruments
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InstrumentDbContext>
    {
        public InstrumentDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<InstrumentDbContext>();

            var connectionString = configuration.GetConnectionString("InstrumentsDb");

            builder.UseSqlServer(connectionString);

            return new InstrumentDbContext(builder.Options);
        }
    }
}
