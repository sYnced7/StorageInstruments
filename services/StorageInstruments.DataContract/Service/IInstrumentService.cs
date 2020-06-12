using StorageInstruments.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorageInstruments.DataContract
{
    public interface IInstrumentService
    {
        InstrumentDto GetInstrumentById(int id);
        InstrumentDto Delete(int id);
        IEnumerable<InstrumentDto> GetInstrumentsByName(string name);
        InstrumentDto AddOrUpdateInstrument(InstrumentDto instrument);
        int GetCountOfInstruments();
        Task<InstrumentDto> PostInstrumentAsync(InstrumentDto instrument);
        Task<InstrumentDto> DeleteInstrumentAsync(int id);
        Task<bool> UpdateInstrumentAsync(InstrumentDto instrument);

        Task<IEnumerable<InstrumentDto>> GetInstrumentsAsync();

        Task<InstrumentDto> GetInstrumentAsync(int id);
    }
}
