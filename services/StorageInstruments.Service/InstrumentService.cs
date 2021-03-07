using Microsoft.Extensions.Logging;
using StorageInstruments.DataContract;
using StorageInstruments.DataContract.Utils;
using StorageInstruments.DTO;
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
        public InstrumentDto Delete(int id)
        {
            if(id > 0)
            {
                var instrument = instrumentRepository.Delete(id);
                instrumentRepository.Commit();
                return DTO.DTO.InstrumentToDto(instrument);
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
        public InstrumentDto GetInstrumentById(int id)
        {
            if(id > 0)
            {
                return DTO.DTO.InstrumentToDto(instrumentRepository.GetById(id));
            }
            logger.WriteLog("Failed to Get iteam with id " + id, LogLevel.Warning);
            return null;
        }

        /// <summary>
        /// Retrieves a list of instruments by his name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<InstrumentDto> GetInstrumentsByName(string name)
        {
            return ParserIEnumInstrument(instrumentRepository.GetInstrumentsByName(name));
        }
        /// <summary>
        /// Validates if is to update or add a new instrument
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        public InstrumentDto AddOrUpdateInstrument(InstrumentDto instrument)
        {
            if (instrument.Id > 0)
            {
                instrumentRepository.Update(DTO.DTO.DtoToInstrument(instrument));
            }
            else
            {
                instrumentRepository.Add(DTO.DTO.DtoToInstrument(instrument));
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
        public async Task<InstrumentDto> PostInstrumentAsync(InstrumentDto instrument)
        {
            if(instrument != null)
            {
                var aux = await instrumentRepository.PostInstrumentAsync(DTO.DTO.DtoToInstrument(instrument));
                instrumentRepository.Commit();
                return DTO.DTO.InstrumentToDto(aux);
            }
            logger.WriteLog("Failed to Post Async", LogLevel.Warning);
            return null;
        }
        /// <summary>
        /// Deletes an instrument throught API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InstrumentDto> DeleteInstrumentAsync(int id)
        {
            if(id > 0)
            {
                var aux = await instrumentRepository.DeleteInstrumentAsync(id);
            }
            logger.WriteLog("Failed to Delete Async with id " + id, LogLevel.Warning);
            return null;
        }

        public async Task<bool> UpdateInstrumentAsync(InstrumentDto instrument)
        {
            if(instrument != null)
            {
                return await instrumentRepository.UpdateInstrumentAsync(DTO.DTO.DtoToInstrument(instrument));
            }

            return false;
        }

        public async Task<IEnumerable<InstrumentDto>> GetInstrumentsAsync()
        {
            return ParserIEnumInstrument(await instrumentRepository.GetInstrumentsAsync());
        }

        public async Task<InstrumentDto> GetInstrumentAsync(int id)
        {
            if(id > 0)
            {
               return  DTO.DTO.InstrumentToDto(await instrumentRepository.GetInstrumentAsync(id));
            }

            return null;
        }


        #endregion

        public IEnumerable<InstrumentDto> ParserIEnumInstrument(IEnumerable<Instrument> instruments)
        {
            List<InstrumentDto> parser = new List<InstrumentDto>();

            foreach (var item in instruments)
            {
                parser.Add(DTO.DTO.InstrumentToDto(item));
            }

            return parser;
        }

    }
}
