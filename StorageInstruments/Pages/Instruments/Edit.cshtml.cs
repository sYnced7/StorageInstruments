using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StorageInstruments.Data;
using StorageInstruments.Model;

namespace StorageInstruments.Pages.Instruments
{
    public class EditModel : PageModel
    {
        private readonly IInstrumentData instrumentData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> LocationTypes { get; set; }
        public IEnumerable<SelectListItem> InstrumentTypes { get; set; }
        public Instrument Instrument { get; set; }
        public EditModel(IInstrumentData instrumentData, IHtmlHelper htmlHelper)
        {
            this.instrumentData = instrumentData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int instrumentId)
        {
            LocationTypes = htmlHelper.GetEnumSelectList<LocationType>();
            InstrumentTypes = htmlHelper.GetEnumSelectList<InstrumentType>();

            Instrument = instrumentData.GetById(instrumentId);
            if(Instrument == null)
            {
                RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}