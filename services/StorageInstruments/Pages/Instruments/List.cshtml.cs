using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.DataContract;
using StorageInstruments.DTO;

namespace StorageInstruments.Pages.Instruments
{
    public class ListModel : PageModel
    {
        private readonly IInstrumentService instrumentService;

        public IEnumerable<InstrumentDto> Instruments {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }
        public void OnGet()
        {
            Instruments = instrumentService.GetInstrumentsByName(SearchTerm);
        }
    }
}