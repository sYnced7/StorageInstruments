using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentService
    {
        Instrument GetInstrumentById(int id);
        Instrument Delete(int id);
        IEnumerable<Instrument> GetInstrumentsByName(string name);
        Instrument AddOrUpdateInstrument(Instrument instrument);
        int GetCountOfInstruments();
    }
}
