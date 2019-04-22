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
    public class SalasController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public SalasController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Salas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sala>>> GetSalas()
        {
            return await _context.Salas.ToListAsync();
        }

        // GET: api/Salas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSalas(int id)
        {
            var salas = await _context.Salas.FindAsync(id);

            if (salas == null)
            {
                return NotFound();
            }

            return salas;
        }

        // PUT: api/Salas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalas(int id, Sala salas)
        {
            if (id != salas.Id)
            {
                return BadRequest();
            }

            _context.Entry(salas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalasExists(id))
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

        // POST: api/Salas
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSalas(Sala salas)
        {
            _context.Salas.Add(salas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalas", new { id = salas.Id }, salas);
        }

        // DELETE: api/Salas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sala>> DeleteSalas(int id)
        {
            var salas = await _context.Salas.FindAsync(id);
            if (salas == null)
            {
                return NotFound();
            }

            _context.Salas.Remove(salas);
            await _context.SaveChangesAsync();

            return salas;
        }

        private bool SalasExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}
