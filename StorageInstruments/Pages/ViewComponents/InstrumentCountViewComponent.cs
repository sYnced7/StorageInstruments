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
        private readonly IInstrumentRepository instrumentRepository;

        public InstrumentCountViewComponent(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }

        public IViewComponentResult Invoke()
        {
            var count = instrumentRepository.GetCountOfInstruments();
            return View(count);
        }
    }
}
