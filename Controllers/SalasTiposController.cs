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
    public class SalasTiposController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public SalasTiposController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/SalasTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaTipo>>> GetSalasTipos()
        {
            return await _context.SalasTipos.ToListAsync();
        }

        // GET: api/SalasTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaTipo>> GetSalasTipos(int id)
        {
            var salasTipos = await _context.SalasTipos.FindAsync(id);

            if (salasTipos == null)
            {
                return NotFound();
            }

            return salasTipos;
        }

        // PUT: api/SalasTipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalasTipos(int id, SalaTipo salasTipos)
        {
            if (id != salasTipos.Id)
            {
                return BadRequest();
            }

            _context.Entry(salasTipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalasTiposExists(id))
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

        // POST: api/SalasTipos
        [HttpPost]
        public async Task<ActionResult<SalaTipo>> PostSalasTipos(SalaTipo salasTipos)
        {
            _context.SalasTipos.Add(salasTipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalasTipos", new { id = salasTipos.Id }, salasTipos);
        }

        // DELETE: api/SalasTipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SalaTipo>> DeleteSalasTipos(int id)
        {
            var salasTipos = await _context.SalasTipos.FindAsync(id);
            if (salasTipos == null)
            {
                return NotFound();
            }

            _context.SalasTipos.Remove(salasTipos);
            await _context.SaveChangesAsync();

            return salasTipos;
        }

        private bool SalasTiposExists(int id)
        {
            return _context.SalasTipos.Any(e => e.Id == id);
        }
    }
}
