using StorageInstruments.Model;

namespace StorageInstruments.DTO
{
    public class InstrumentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationType Location { get; set; }
        public string owner { get; set; }
        public InstrumentType Type { get; set; }
    }
}
