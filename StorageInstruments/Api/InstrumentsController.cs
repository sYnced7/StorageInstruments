using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageInstruments.Data;
using StorageInstruments.DataContract;
using StorageInstruments.Model;

namespace StorageInstruments.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly IInstrumentService instrumentService;
        private readonly InstrumentDbContext _context;

        public InstrumentsController(IInstrumentService instrumentService, InstrumentDbContext context)
        {
            _context = context;
            this.instrumentService = instrumentService;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstruments()
        {
            return await _context.Instruments.ToListAsync();
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrument(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);

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
        public async Task<IActionResult> PutInstrument(int id, Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _context.Entry(instrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instruments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Instrument>> PostInstrument(Instrument instrument)
        {
            var aux = await instrumentService.PostInstrument(instrument);

            return CreatedAtAction("GetInstrument", new { id = aux.Id }, aux);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instrument>> DeleteInstrument(int id)
        {
            var aux = await instrumentService.DeleteInstrument(id);

            if (aux == null)
            {
                return NotFound();
            }

            return aux;
        }

        private bool InstrumentExists(int id)
        {
            return _context.Instruments.Any(e => e.Id == id);
        }
    }
}
