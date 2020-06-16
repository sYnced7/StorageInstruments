using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using StorageInstruments.DataContract.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageInstruments.Utils
{
    public class SeriLog : ISeriLog
    {
        private readonly Serilog.ILogger logger;
        public SeriLog()
        {
            logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
           .Enrich.FromLogContext()
           .WriteTo.Console()
           .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
           .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://localhost:9200")))
           .CreateLogger();

            try
            {
                Log.Information("Starting Amplifier web host");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public void WriteLog(string message, LogLevel logLevel)
        {
            try
            {
                logger.Write((LogEventLevel)logLevel, message);
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace.ToString());
            }
            
        }

    }
}
