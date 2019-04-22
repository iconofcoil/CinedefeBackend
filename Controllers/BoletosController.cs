using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CinedefeBackend.Models;

namespace CinedefeBackend.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BoletosController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public BoletosController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Boletos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletos()
        {
            return await _context.Boletos.ToListAsync();
        }

        // GET: api/Boletos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoletos(int id)
        {
            var boletos = await _context.Boletos.FindAsync(id);

            if (boletos == null)
            {
                return NotFound();
            }

            return boletos;
        }

        // PUT: api/Boletos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoletos(int id, Boleto boletos)
        {
            if (id != boletos.Id)
            {
                return BadRequest();
            }

            _context.Entry(boletos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletosExists(id))
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

        // POST: api/Boletos
        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoletos(Boleto boletos)
        {
            _context.Boletos.Add(boletos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoletos", new { id = boletos.Id }, boletos);
        }

        // DELETE: api/Boletos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Boleto>> DeleteBoletos(int id)
        {
            var boletos = await _context.Boletos.FindAsync(id);
            if (boletos == null)
            {
                return NotFound();
            }

            _context.Boletos.Remove(boletos);
            await _context.SaveChangesAsync();

            return boletos;
        }

        private bool BoletosExists(int id)
        {
            return _context.Boletos.Any(e => e.Id == id);
        }
    }
}
