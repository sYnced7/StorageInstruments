using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentService
    {
        Instrument GetInstrumentById(int id);
        Instrument Delete(int id);
        IEnumerable<Instrument> GetInstrumentsByName(string name);
        Instrument AddOrUpdateInstrument(Instrument instrument);
        int GetCountOfInstruments();
        Task<Instrument> PostInstrumentAsync(Instrument instrument);
        Task<Instrument> DeleteInstrumentAsync(int id);
        Task<bool> UpdateInstrumentAsync(Instrument instrument);

        Task<IEnumerable<Instrument>> GetInstrumentsAsync();

        Task<Instrument> GetInstrumentAsync(int id);
    }
}
