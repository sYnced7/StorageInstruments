using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.DataContract;
using StorageInstruments.DTO;

namespace StorageInstruments.Pages.Instruments
{
    public class DeleteModel : PageModel
    {
        private readonly IInstrumentService instrumentService;

        [BindProperty]
        public InstrumentDto Instrument { get; set; }
        public DeleteModel(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }

        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentService.GetInstrumentById(instrumentId);

            if(Instrument == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int instrumentId)
        {
            var instrument = instrumentService.Delete(instrumentId);

            if (instrument == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{instrument.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}