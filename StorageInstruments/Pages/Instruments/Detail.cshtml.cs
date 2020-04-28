using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.Data;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class DetailModel : PageModel
    {
        private readonly IInstrumentData instrumentsData;
        public Instrument Instrument { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IInstrumentData instrumentsData)
        {
            this.instrumentsData = instrumentsData;
        }
        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentsData.GetById(instrumentId);
            if(Instrument == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}