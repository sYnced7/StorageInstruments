using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class EditModel : PageModel
    {
        private readonly IInstrumentRepository instrumentRepository;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> LocationTypes { get; set; }
        public IEnumerable<SelectListItem> InstrumentTypes { get; set; }
        [BindProperty]
        public Instrument Instrument { get; set; }
        public EditModel(IInstrumentRepository instrumentRepository, IHtmlHelper htmlHelper)
        {
            this.instrumentRepository = instrumentRepository;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? instrumentId)
        {
            LoadEnums();
            if(instrumentId.HasValue)
            {
                Instrument = instrumentRepository.GetById(instrumentId.Value);
            }
            else
            {
                Instrument = new Instrument();
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
            if(Instrument.Id > 0)
            {
                instrumentRepository.Update(Instrument);
            }
            else
            {
                instrumentRepository.Add(Instrument);
            }
            instrumentRepository.Commit();
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