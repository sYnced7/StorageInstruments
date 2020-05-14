using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentService
    {
        Instrument GetInstrument(bool getById, int? id);
        Instrument Delete(int id);
    }
}
