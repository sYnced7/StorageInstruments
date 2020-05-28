using Microsoft.Extensions.Logging;

namespace StorageInstruments.DataContract.Utils
{
    public interface ISeriLog
    {
        void WriteLog(string message, LogLevel logLevel);
    }
}
