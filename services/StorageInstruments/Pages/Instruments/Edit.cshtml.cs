using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageInstruments.DataContract;
using StorageInstruments.DTO;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class EditModel : PageModel
    {
        private readonly IInstrumentService instrumentService;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> LocationTypes { get; set; }
        public IEnumerable<SelectListItem> InstrumentTypes { get; set; }
        [BindProperty]
        public InstrumentDto Instrument { get; set; }
        public EditModel(IInstrumentService instrumentService, IHtmlHelper htmlHelper)
        {
            this.instrumentService = instrumentService;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? instrumentId)
        {
            LoadEnums();
            if(instrumentId.HasValue)
            {
                Instrument = instrumentService.GetInstrumentById(instrumentId.Value);
            }
            else
            {
                Instrument = new InstrumentDto();
            }
            if (Instrument == null)
            {
                RedirectToPage("./NotFound");
            }

            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                LoadEnums();
                return Page();
            }

            instrumentService.AddOrUpdateInstrument(Instrument);
            
            TempData["Message"] = "Instrument Saved!";
            return RedirectToPage("./Detail", new { instrumentId = Instrument.Id });
        }

        public void LoadEnums()
        {
            LocationTypes = htmlHelper.GetEnumSelectList<LocationType>();
            InstrumentTypes = htmlHelper.GetEnumSelectList<InstrumentType>();
        }
    }
}