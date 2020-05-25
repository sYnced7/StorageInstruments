using StorageInstruments.DataContract;
using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageInstruments.Service
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository instrumentRepository;
        public InstrumentService(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }

        /// <summary>
        /// Deletes and retrieves the deleted item from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Instrument Delete(int id)
        {
            if(id != 0)
            {
                var instrument = instrumentRepository.Delete(id);
                instrumentRepository.Commit();
                return instrument;
            }

            return null;
        }

        /// <summary>
        /// Could retrieve a instrument by id
        /// </summary>
        /// <param name="getById"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Instrument GetInstrumentById(int id)
        {
            if(id != 0)
            {
                return instrumentRepository.GetById(id);
            }
            return null;
        }

        /// <summary>
        /// Retrieves a list of instruments by his name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Instrument> GetInstrumentsByName(string name)
        {
            return instrumentRepository.GetInstrumentsByName(name);
        }
        /// <summary>
        /// Validates if is to update or add a new instrument
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        public Instrument AddOrUpdateInstrument(Instrument instrument)
        {
            if (instrument.Id > 0)
            {
                instrumentRepository.Update(instrument);
            }
            else
            {
                instrumentRepository.Add(instrument);
            }
            instrumentRepository.Commit();

            return instrument;
        }

        public int GetCountOfInstruments()
        {
            return instrumentRepository.GetCountOfInstruments();
        }

        #region API
        /// <summary>
        /// Post an instrument Throught API
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        public async Task<Instrument> PostInstrument(Instrument instrument)
        {
            if(instrument != null)
            {
                var aux = await instrumentRepository.PostInstrument(instrument);
                return aux;
            }

            return null;
        }
        /// <summary>
        /// Deletes an instrument throught API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Instrument> DeleteInstrument(int id)
        {
            if(id > 0)
            {
                var aux = await instrumentRepository.DeleteInstrument(id);
            }
            return null;
        }

        public async Task<bool> PutInstrument(Instrument instrument)
        {
            if(instrument != null)
            {
                return await instrumentRepository.PutInstrument(instrument);
            }

            return false;
        }

        public async Task<IEnumerable<Instrument>> GetInstrumentsAsync()
        {
            return await instrumentRepository.GetInstrumentsAsync();
        }

        public async Task<Instrument> GetInstrumentAsync(int id)
        {
            if(id > 0)
            {
               return await instrumentRepository.GetInstrumentAsync(id);
            }

            return null;
        }


        #endregion

    }
}
