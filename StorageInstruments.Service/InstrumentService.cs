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
        /// Could retrieve a instrument by id [not complete]
        /// </summary>
        /// <param name="getById"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Instrument GetInstrument(bool getById, int? id)
        {
            if(getById)
            {
                if(id != null)
                {
                    int val = 0;
                    bool validId = int.TryParse(id.ToString(), out val);
                    if(validId && val > 0)
                    {
                        return instrumentRepository.GetById(val);
                    }
                }
                return null;
            }
            return null;
        }
    }
}
