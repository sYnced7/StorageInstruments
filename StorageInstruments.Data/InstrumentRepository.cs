using StorageInstruments.DataContract;
using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageInstruments.Data
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly InstrumentDbContext db;
        public InstrumentRepository(InstrumentDbContext db)
        {
            this.db = db;
        }
        public Instrument Add(Instrument instrument)
        {
            db.Add(instrument);

            return instrument;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Instrument Delete(int id)
        {
            var instrument = GetById(id);

            if(instrument != null)
            {
                db.Remove(instrument);
            }

            return instrument;
        }

        public Instrument GetById(int id)
        {
            return db.Instruments.Find(id);
        }

        public int GetCountOfInstruments()
        {
            return db.Instruments.Count();
        }

        public IEnumerable<Instrument> GetInstrumentsByName(string name)
        {
            return from r in db.Instruments
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
        }

        public Instrument Update(Instrument instrument)
        {
            var entity = db.Instruments.Attach(instrument);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return instrument;
        }

        #region API


        public async Task<Instrument> PostInstrument(Instrument instrument)
        {
            return Add(instrument);
        }
        public async Task<Instrument> DeleteInstrument(int id)
        {
            var aux = db.Instruments.FindAsync(id);
            if(aux == null)
            {
                return null;
            }

            return Delete(id);
        }
        #endregion


    }
}
