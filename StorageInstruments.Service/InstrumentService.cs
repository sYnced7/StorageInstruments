using StorageInstruments.DataContract;
using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
