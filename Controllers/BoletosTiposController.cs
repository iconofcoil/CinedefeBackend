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
    public class BoletosTiposController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public BoletosTiposController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/BoletosTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoletoTipo>>> GetBoletosTipos()
        {
            return await _context.BoletosTipos.ToListAsync();
        }

        // GET: api/BoletosTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoletoTipo>> GetBoletosTipos(int id)
        {
            var boletosTipos = await _context.BoletosTipos.FindAsync(id);

            if (boletosTipos == null)
            {
                return NotFound();
            }

            return boletosTipos;
        }

        // PUT: api/BoletosTipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoletosTipos(int id, BoletoTipo boletosTipos)
        {
            if (id != boletosTipos.Id)
            {
                return BadRequest();
            }

            _context.Entry(boletosTipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletosTiposExists(id))
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

        // POST: api/BoletosTipos
        [HttpPost]
        public async Task<ActionResult<BoletoTipo>> PostBoletosTipos(BoletoTipo boletosTipos)
        {
            _context.BoletosTipos.Add(boletosTipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoletosTipos", new { id = boletosTipos.Id }, boletosTipos);
        }

        // DELETE: api/BoletosTipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoletoTipo>> DeleteBoletosTipos(int id)
        {
            var boletosTipos = await _context.BoletosTipos.FindAsync(id);
            if (boletosTipos == null)
            {
                return NotFound();
            }

            _context.BoletosTipos.Remove(boletosTipos);
            await _context.SaveChangesAsync();

            return boletosTipos;
        }

        private bool BoletosTiposExists(int id)
        {
            return _context.BoletosTipos.Any(e => e.Id == id);
        }
    }
}
