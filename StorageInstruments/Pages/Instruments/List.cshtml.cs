using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IInstrumentRepository instrumentRepository;

        public IEnumerable<Instrument> Instruments {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IInstrumentRepository instrumentRepository)
        {
            this.configuration = configuration;
            this.instrumentRepository = instrumentRepository;
        }
        public void OnGet()
        {
            Instruments = instrumentRepository.GetInstrumentsByName(SearchTerm);
        }
    }
}