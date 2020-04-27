using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace StorageInstruments.Pages.Instruments
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        public string Name { get; set; }
        public void OnGet(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}