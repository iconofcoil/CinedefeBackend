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
    public class PeliculasClasificacionesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public PeliculasClasificacionesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/PeliculasClasificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeliculaClasificacion>>> GetPeliculasClasificaciones()
        {
            return await _context.PeliculasClasificaciones.ToListAsync();
        }

        // GET: api/PeliculasClasificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeliculaClasificacion>> GetPeliculasClasificaciones(int id)
        {
            var peliculasClasificaciones = await _context.PeliculasClasificaciones.FindAsync(id);

            if (peliculasClasificaciones == null)
            {
                return NotFound();
            }

            return peliculasClasificaciones;
        }

        // PUT: api/PeliculasClasificaciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculasClasificaciones(int id, PeliculaClasificacion peliculasClasificaciones)
        {
            if (id != peliculasClasificaciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(peliculasClasificaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasClasificacionesExists(id))
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

        // POST: api/PeliculasClasificaciones
        [HttpPost]
        public async Task<ActionResult<PeliculaClasificacion>> PostPeliculasClasificaciones(PeliculaClasificacion peliculasClasificaciones)
        {
            _context.PeliculasClasificaciones.Add(peliculasClasificaciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeliculasClasificaciones", new { id = peliculasClasificaciones.Id }, peliculasClasificaciones);
        }

        // DELETE: api/PeliculasClasificaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PeliculaClasificacion>> DeletePeliculasClasificaciones(int id)
        {
            var peliculasClasificaciones = await _context.PeliculasClasificaciones.FindAsync(id);
            if (peliculasClasificaciones == null)
            {
                return NotFound();
            }

            _context.PeliculasClasificaciones.Remove(peliculasClasificaciones);
            await _context.SaveChangesAsync();

            return peliculasClasificaciones;
        }

        private bool PeliculasClasificacionesExists(int id)
        {
            return _context.PeliculasClasificaciones.Any(e => e.Id == id);
        }
    }
}
