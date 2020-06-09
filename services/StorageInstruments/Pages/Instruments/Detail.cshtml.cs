using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class DetailModel : PageModel
    {
        private readonly IInstrumentService instrumentService;
        public Instrument Instrument { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }
        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentService.GetInstrumentById(instrumentId);
            if(Instrument == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}