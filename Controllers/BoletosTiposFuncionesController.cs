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
    public class BoletosTiposFuncionesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public BoletosTiposFuncionesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/BoletoTipoFunciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoletoTipoFuncion>>> GetBoletoTipoFuncion()
        {
            return await _context.BoletoTipoFuncion.ToListAsync();
        }

        // GET: api/BoletoTipoFunciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoletoTipoFuncion>> GetBoletoTipoFuncion(int id)
        {
            var boletoTipoFuncion = await _context.BoletoTipoFuncion.FindAsync(id);

            if (boletoTipoFuncion == null)
            {
                return NotFound();
            }

            return boletoTipoFuncion;
        }

        // PUT: api/BoletoTipoFunciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoletoTipoFuncion(int id, BoletoTipoFuncion boletoTipoFuncion)
        {
            if (id != boletoTipoFuncion.BoletoTipoId)
            {
                return BadRequest();
            }

            _context.Entry(boletoTipoFuncion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletoTipoFuncionExists(id))
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

        // POST: api/BoletoTipoFunciones
        [HttpPost]
        public async Task<ActionResult<BoletoTipoFuncion>> PostBoletoTipoFuncion(BoletoTipoFuncion boletoTipoFuncion)
        {
            _context.BoletoTipoFuncion.Add(boletoTipoFuncion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BoletoTipoFuncionExists(boletoTipoFuncion.BoletoTipoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBoletoTipoFuncion", new { id = boletoTipoFuncion.BoletoTipoId }, boletoTipoFuncion);
        }

        // DELETE: api/BoletoTipoFunciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoletoTipoFuncion>> DeleteBoletoTipoFuncion(int id)
        {
            var boletoTipoFuncion = await _context.BoletoTipoFuncion.FindAsync(id);
            if (boletoTipoFuncion == null)
            {
                return NotFound();
            }

            _context.BoletoTipoFuncion.Remove(boletoTipoFuncion);
            await _context.SaveChangesAsync();

            return boletoTipoFuncion;
        }

        private bool BoletoTipoFuncionExists(int id)
        {
            return _context.BoletoTipoFuncion.Any(e => e.BoletoTipoId == id);
        }
    }
}
