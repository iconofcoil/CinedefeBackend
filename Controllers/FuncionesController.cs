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
    public class FuncionesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public FuncionesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Funciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcion>>> GetFunciones()
        {
            return await _context.Funciones.ToListAsync();
        }

        // GET: api/Funciones/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Funcion>> GetFunciones([FromRoute]int id)
        {
            var funciones = await _context.Funciones.FindAsync(id);

            if (funciones == null)
            {
                return NotFound();
            }

            return funciones;
        }

        // GET: api/Funciones/5/horarios
        [HttpGet("{id:int}/horarios")]
        public async Task<ActionResult<List<FuncionHorario>>> GetHorariosFuncion([FromRoute]int id)
        {
            var horarios = await _context.FuncionHorarios.Where(x => x.FuncionId == id).ToListAsync();

            if (horarios == null)
            {
                return NotFound();
            }

            return horarios;
        }

        // GET: api/Funciones/5/horarios/fechas
        [HttpGet("{id:int}/horarios/fechas")]
        public async Task<ActionResult<List<FuncionHorario>>> GetFechasFuncion([FromRoute]int id)
        {
            List<FuncionHorario> funcionFechas = new List<FuncionHorario>();

            var horarios = await _context.FuncionHorarios.Where(x => x.FuncionId == id).ToListAsync();

            if (horarios == null)
            {
                return NotFound();
            }
            else
            {
                var fechas = horarios.Select(x => x.Horario.Date).Distinct();

                foreach (DateTime d in fechas)
                {
                    funcionFechas.Add(new FuncionHorario { FuncionId = id, Horario = d });
                }
            }

            return funcionFechas;
        }

        // GET: api/Funciones/5/extended
        [HttpGet("{id:int}/extended")]
        public async Task<ActionResult<FuncionExtended>> GetFuncionesExtended([FromRoute]int id)
        {
            // Retrieves Funcion
            var funcion = await _context.Funciones.Where(x => x.Id == id).SingleOrDefaultAsync();

            if (funcion == null)
            {
                return NotFound();
            }

            var funcionExtended = new FuncionExtended(funcion);

            // Retrieves Sala
            funcionExtended.Sala = await _context.Salas.Where(x => x.Id == funcionExtended.Sala.Id).SingleOrDefaultAsync();

            if (funcionExtended.Sala.Id == 0)
            {
                return NotFound();
            }

            // Retrieves Pelicula
            funcionExtended.Pelicula = await _context.Peliculas.Where(x => x.Id == funcionExtended.Pelicula.Id).SingleOrDefaultAsync();

            if (funcionExtended.Pelicula.Id == 0)
            {
                return NotFound();
            }

            return Ok(funcionExtended);
        }

        // GET: api/funciones/sucursal/id
        [HttpGet("sucursal/{id:int}")]
        public async Task<ActionResult<FuncionDisponibleView>> GetFuncionesDisponiblesBySucursal([FromRoute]int id)
        {
            var funciones = await _context.vwFuncionesDisponibles.Where(x => x.SucursalId == id).ToListAsync();
            
            if (funciones == null)
            {
                return NotFound();
            }

            return Ok(funciones);
        }

        // PUT: api/Funciones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunciones([FromRoute]int id, [FromBody]Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionExists(id))
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

        // POST: api/Funciones
        [HttpPost]
        public async Task<ActionResult<Funcion>> PostFunciones([FromBody]Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunciones", new { id = funcion.Id }, funcion);
        }

        // DELETE: api/Funciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcion>> DeleteFunciones(int id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }

            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();

            return funcion;
        }

        private bool FuncionExists(int id)
        {
            return _context.Funciones.Any(e => e.Id == id);
        }
    }
}
