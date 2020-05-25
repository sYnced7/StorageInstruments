using StorageInstruments.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentRepository
    {
        IEnumerable<Instrument> GetInstrumentsByName(string name);
        Instrument GetById(int id);

        Instrument Add(Instrument instrument);

        Instrument Update(Instrument instrument);

        Instrument Delete(int id);
        int GetCountOfInstruments();
        int Commit();
        /// <summary>
        /// API Post Action
        /// </summary>
        /// <param name="instrument"></param>
        /// <returns></returns>
        Task<Instrument> PostInstrument(Instrument instrument);
        /// <summary>
        /// API Delete Action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Instrument> DeleteInstrument(int id);

        /// <summary>
        /// API Put Action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instrument"></param>
        /// <returns></returns>
        Task<bool> PutInstrument(Instrument instrument);

        /// <summary>
        /// API Get All Action
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Instrument>> GetInstrumentsAsync();

        /// <summary>
        /// API Get by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Instrument> GetInstrumentAsync(int id);
    }
}
