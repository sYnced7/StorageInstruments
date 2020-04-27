using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using StorageInstruments.Data;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IInstrumentData instrumentData;

        public IEnumerable<Instrument> Instruments {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IInstrumentData instrumentData)
        {
            this.configuration = configuration;
            this.instrumentData = instrumentData;
        }
        public void OnGet()
        {
            Instruments = instrumentData.GetInstrumentsByName(SearchTerm);
        }
    }
}