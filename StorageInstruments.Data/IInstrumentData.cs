using StorageInstruments.Model;
using System.Collections.Generic;
using System.Linq;

namespace StorageInstruments.Data
{
    //THIS CLASS WAS JUST USED TO TEST THE FRONTEND IN THE BEGIN. NOT BEING USED
    public interface IInstrumentData
    {
        IEnumerable<Instrument> GetInstrumentsByName(string name);
        Instrument GetById(int id);

        Instrument Add(Instrument instrument);

        Instrument Update(Instrument instrument);

        Instrument Delete(int id);
        int Commit();
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

        public Instrument Add(Instrument instrument)
        {
            instruments.Add(instrument);
            instrument.Id = instruments.Max(x => x.Id) + 1;

            return instrument;
        }

        public int Commit()
        {
            return 0;
        }

        public Instrument Delete(int id)
        {
            var instrument = instruments.FirstOrDefault(x => x.Id == id);

            if (instrument != null)
            {
                instruments.Remove(instrument);
            }

            return instrument;
        }

        public Instrument GetById(int id)
        {
            return instruments.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Instrument> GetInstrumentsByName(string name)
        {
            return from r in instruments
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Id
                   select r;
        }

        public Instrument Update(Instrument instrumentUpdated)
        {
            var instrument = instruments.FirstOrDefault(x => x.Id == instrumentUpdated.Id);

            if(instrument != null)
            {
                instrument.Name = instrumentUpdated.Name;
                instrument.Location = instrumentUpdated.Location;
                instrument.owner = instrumentUpdated.owner;
                instrument.Type = instrumentUpdated.Type;
            }
            return instrument;
        }
    }
}
