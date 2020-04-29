using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class DetailModel : PageModel
    {
        private readonly IInstrumentRepository instrumentRepository;
        public Instrument Instrument { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }
        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentRepository.GetById(instrumentId);
            if(Instrument == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}