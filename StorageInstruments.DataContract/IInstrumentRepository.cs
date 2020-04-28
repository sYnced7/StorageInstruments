using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentRepository
    {
        IEnumerable<Instrument> GetInstrumentsByName(string name);
        Instrument GetById(int id);

        Instrument Add(Instrument instrument);

        Instrument Update(Instrument instrument);
        int Commit();
    }
}
