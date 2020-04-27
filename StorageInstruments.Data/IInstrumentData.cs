using StorageInstruments.Model;
using System.Collections.Generic;
using System.Linq;

namespace StorageInstruments.Data
{
    public interface IInstrumentData
    {
        IEnumerable<Instrument> GetAllInstruments();
    }

    public class InMemoryInstruments : IInstrumentData
    {
        List<Instrument> instruments;
        public InMemoryInstruments()
        {
            instruments = new List<Instrument>()
            {
                new Instrument {Id = 1, Location = LocationType.Home, Name="Alhambra", owner="Potato", Type = InstrumentType.Chords},
                new Instrument {Id = 2, Location = LocationType.Home, Name="SAD", owner="FFFF", Type = InstrumentType.Percurssion},
                new Instrument {Id = 3, Location = LocationType.WithOwner, Name="gggg", owner="21df", Type = InstrumentType.Tools}
            };
        }

        public IEnumerable<Instrument> GetAllInstruments()
        {
            return from r in instruments
                   orderby r.Id
                   select r;
        }
    }
}
