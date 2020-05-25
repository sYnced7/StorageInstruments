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
        Task<Instrument> PostInstrument(Instrument instrument);
        Task<Instrument> DeleteInstrument(int id);
    }
}
