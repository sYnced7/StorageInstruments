using System.ComponentModel.DataAnnotations;

namespace StorageInstruments.Model
{
    public class Instrument
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(85)]
        public string Name { get; set; }
        public LocationType Location { get; set; }
        [Required]
        public string owner { get; set; }
        [Required]
        public InstrumentType Type { get; set; }

    }
}
