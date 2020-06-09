﻿using Microsoft.Extensions.Logging;
using StorageInstruments.DataContract;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageInstruments.Service
{
    public class InstrumentService : IInstrumentService
    {
        private readonly IInstrumentRepository instrumentRepository;
        private readonly ISeriLog logger;

        public InstrumentService(IInstrumentRepository instrumentRepository, ISeriLog logger)
        {
            this.instrumentRepository = instrumentRepository;
            this.logger = logger;
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
            logger.WriteLog("Failed to delete iteam with id " + id, LogLevel.Warning);
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
            logger.WriteLog("Failed to Get iteam with id " + id, LogLevel.Warning);
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
        public async Task<Instrument> PostInstrumentAsync(Instrument instrument)
        {
            if(instrument != null)
            {
                var aux = await instrumentRepository.PostInstrumentAsync(instrument);
                return aux;
            }
            logger.WriteLog("Failed to Post Async", LogLevel.Warning);
            return null;
        }
        /// <summary>
        /// Deletes an instrument throught API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Instrument> DeleteInstrumentAsync(int id)
        {
            if(id > 0)
            {
                var aux = await instrumentRepository.DeleteInstrumentAsync(id);
            }
            logger.WriteLog("Failed to Delete Async with id " + id, LogLevel.Warning);
            return null;
        }

        public async Task<bool> UpdateInstrumentAsync(Instrument instrument)
        {
            if(instrument != null)
            {
                return await instrumentRepository.UpdateInstrumentAsync(instrument);
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
