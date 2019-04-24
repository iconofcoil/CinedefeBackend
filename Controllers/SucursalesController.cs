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
    public class SucursalesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public SucursalesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _context.Sucursales.ToListAsync();
        }

        // GET: api/Sucursales/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sucursal>> GetSucursales([FromRoute]int id)
        {
            var sucursales = await _context.Sucursales.FindAsync(id);

            if (sucursales == null)
            {
                return NotFound();
            }

            return sucursales;
        }

        // GET: api/Sucursales/ciudad
        [HttpGet("{ciudad}")]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursalesByCiudad([FromRoute]string ciudad)
        {
            var sucursales = await _context.Sucursales.Where(x => x.Ciudad == ciudad).ToListAsync();

            if (sucursales == null)
            {
                return NotFound();
            }

            return sucursales;
        }

        // PUT: api/Sucursales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursales([FromHeader]int id, [FromBody]Sucursal sucursales)
        {
            if (id != sucursales.Id)
            {
                return BadRequest();
            }

            _context.Entry(sucursales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalesExists(id))
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

        // POST: api/Sucursales
        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursales([FromBody]Sucursal sucursales)
        {
            _context.Sucursales.Add(sucursales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursales", new { id = sucursales.Id }, sucursales);
        }

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sucursal>> DeleteSucursales(int id)
        {
            var sucursales = await _context.Sucursales.FindAsync(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursales);
            await _context.SaveChangesAsync();

            return sucursales;
        }

        private bool SucursalesExists(int id)
        {
            return _context.Sucursales.Any(e => e.Id == id);
        }
    }
}
