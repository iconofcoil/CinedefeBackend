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
    public class PeliculasController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public PeliculasController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPeliculas([FromRoute]int id)
        {
            var pelicula = await _context.Peliculas.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // PUT: api/Peliculas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculas(int id, Pelicula peliculas)
        {
            if (id != peliculas.Id)
            {
                return BadRequest();
            }

            _context.Entry(peliculas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasExists(id))
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

        // POST: api/Peliculas
        [HttpPost]
        public async Task<ActionResult<Pelicula>> PostPeliculas(Pelicula peliculas)
        {
            _context.Peliculas.Add(peliculas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeliculas", new { id = peliculas.Id }, peliculas);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pelicula>> DeletePeliculas(int id)
        {
            var peliculas = await _context.Peliculas.FindAsync(id);
            if (peliculas == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(peliculas);
            await _context.SaveChangesAsync();

            return peliculas;
        }

        private bool PeliculasExists(int id)
        {
            return _context.Peliculas.Any(e => e.Id == id);
        }
    }
}
