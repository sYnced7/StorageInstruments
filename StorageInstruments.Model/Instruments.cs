using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StorageInstruments.Model
{
    public class Instruments
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationType Location { get; set; }
        public string owner { get; set; }
        public InstrumentType Type { get; set; }

    }
}
