using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.DTO;
using StorageInstruments.Model;

namespace StorageInstruments.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentService instrumentService;

        public InstrumentsController(IInstrumentService instrumentService)
        {
            this.instrumentService = instrumentService;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetInstruments()
        {
            var aux = await instrumentService.GetInstrumentsAsync();
            
            return aux.ToList();
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentDto>> GetInstrument(int id)
        {
            var instrument = await instrumentService.GetInstrumentAsync(id);

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
        }

        // PUT: api/Instruments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(int id, InstrumentDto instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            if (!await instrumentService.UpdateInstrumentAsync(instrument))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Instruments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InstrumentDto>> PostInstrument(InstrumentDto instrument)
        {
            var aux = await instrumentService.PostInstrumentAsync(instrument);

            return CreatedAtAction("GetInstrument", new { id = aux.Id }, aux);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InstrumentDto>> DeleteInstrument(int id)
        {
            var aux = await instrumentService.DeleteInstrumentAsync(id);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

    }
}
