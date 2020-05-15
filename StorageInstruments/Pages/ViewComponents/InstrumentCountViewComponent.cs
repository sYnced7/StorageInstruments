using Microsoft.AspNetCore.Mvc;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageInstruments.Pages.ViewComponents
{
    public class InstrumentCountViewComponent : ViewComponent
    {
        private readonly IInstrumentService instrumentService;

        public InstrumentCountViewComponent(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }

        public IViewComponentResult Invoke()
        {
            var count = instrumentService.GetCountOfInstruments();
            return View(count);
        }
    }
}
