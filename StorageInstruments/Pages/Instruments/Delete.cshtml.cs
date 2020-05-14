using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.DataContract;
using StorageInstruments.Model;
using StorageInstruments.Service;

namespace StorageInstruments.Pages.Instruments
{
    public class DeleteModel : PageModel
    {
        private readonly IInstrumentService instrumentService;

        [BindProperty]
        public Instrument Instrument { get; set; }
        public DeleteModel(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }

        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentService.GetInstrument(true, instrumentId);

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