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
            return entity.Entity;
        }

        #region API


        public async Task<Instrument> PostInstrumentAsync(Instrument instrument)
        {
            return await Task.Factory.StartNew(() => Add(instrument)).ConfigureAwait(false);
        }
        public async Task<Instrument> DeleteInstrumentAsync(int id)
        {
            var aux = await db.Instruments.FindAsync(id);
            if(aux == null)
            {
                return null;
            }

            await Task.Factory.StartNew(() => {
                Delete(id);
                Commit();
                }).ConfigureAwait(false);

            return aux;
        }

        public async Task<bool> UpdateInstrumentAsync(Instrument instrument)
        {
            var aux = await Task.Factory.StartNew(() => Update(instrument)).ConfigureAwait(false);
            if(aux != null)
            {
                await Task.Factory.StartNew(() => Commit());
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            return await Task.Factory.StartNew(() => GetInstrumentsByName(string.Empty)).ConfigureAwait(false);
        }

        public async Task<Instrument> GetInstrumentAsync(int id)
        {
            return await Task.Factory.StartNew(() => GetById(id)).ConfigureAwait(false);
        }
        #endregion


    }
}
