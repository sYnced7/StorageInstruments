using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class DeleteModel : PageModel
    {
        private readonly IInstrumentRepository instrumentRepository;

        [BindProperty]
        public Instrument Instrument { get; set; }
        public DeleteModel(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }

        public IActionResult OnGet(int instrumentId)
        {
            Instrument = instrumentRepository.GetById(instrumentId);

            if(Instrument == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int instrumentId)
        {
            var instrument = instrumentRepository.Delete(instrumentId);

            instrumentRepository.Commit();

            if(instrument == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{instrument.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}