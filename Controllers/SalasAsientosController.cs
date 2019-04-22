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
    [Route("api/[controller]")]
    [ApiController]
    public class SalasAsientosController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public SalasAsientosController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/SalasAsientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaAsientos>>> GetSalasAsientos()
        {
            return await _context.SalasAsientos.ToListAsync();
        }

        // GET: api/SalasAsientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaAsientos>> GetSalasAsientos(int id)
        {
            var salasAsientos = await _context.SalasAsientos.FindAsync(id);

            if (salasAsientos == null)
            {
                return NotFound();
            }

            return salasAsientos;
        }

        // PUT: api/SalasAsientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalasAsientos(int id, SalaAsientos salasAsientos)
        {
            if (id != salasAsientos.SalaId)
            {
                return BadRequest();
            }

            _context.Entry(salasAsientos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalasAsientosExists(id))
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

        // POST: api/SalasAsientos
        [HttpPost]
        public async Task<ActionResult<SalaAsientos>> PostSalasAsientos(SalaAsientos salasAsientos)
        {
            _context.SalasAsientos.Add(salasAsientos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalasAsientosExists(salasAsientos.SalaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalasAsientos", new { id = salasAsientos.SalaId }, salasAsientos);
        }

        // DELETE: api/SalasAsientos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaAsientos>> DeleteSalasAsientos(int id)
        {
            var salasAsientos = await _context.SalasAsientos.FindAsync(id);
            if (salasAsientos == null)
            {
                return NotFound();
            }

            _context.SalasAsientos.Remove(salasAsientos);
            await _context.SaveChangesAsync();

            return salasAsientos;
        }

        private bool SalasAsientosExists(int id)
        {
            return _context.SalasAsientos.Any(e => e.SalaId == id);
        }
    }
}
