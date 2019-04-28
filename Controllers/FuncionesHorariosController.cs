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
    public class FuncionesHorariosController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public FuncionesHorariosController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/FuncionHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionHorario>>> GetFuncionHorarios()
        {
            return await _context.FuncionHorarios.ToListAsync();
        }

        // GET: api/FuncionHorarios/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FuncionHorario>> GetFuncionHorario(int id)
        {
            var funcionHorario = await _context.FuncionHorarios.FindAsync(id);

            if (funcionHorario == null)
            {
                return NotFound();
            }

            return funcionHorario;
        }

        // GET: api/FuncionHorarios/5/fecha
        [HttpGet("{id:int}/fecha/{fecha}")]
        public async Task<ActionResult<List<FuncionHorario>>> GetFuncionHorario(int id, string fecha)
        {
            DateTime fechaDate = DateTime.Parse(fecha);
            var funcionHorario = await _context.FuncionHorarios.Where(x => x.FuncionId == id && x.Horario.Date == fechaDate).ToListAsync();

            if (funcionHorario == null)
            {
                return NotFound();
            }

            return funcionHorario;
        }

        // PUT: api/FuncionHorarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionHorario(int id, FuncionHorario funcionHorario)
        {
            if (id != funcionHorario.FuncionId)
            {
                return BadRequest();
            }

            _context.Entry(funcionHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionHorarioExists(id))
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

        // POST: api/FuncionHorarios
        [HttpPost]
        public async Task<ActionResult<FuncionHorario>> PostFuncionHorario(FuncionHorario funcionHorario)
        {
            _context.FuncionHorarios.Add(funcionHorario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuncionHorarioExists(funcionHorario.FuncionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuncionHorario", new { id = funcionHorario.FuncionId }, funcionHorario);
        }

        // DELETE: api/FuncionHorarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionHorario>> DeleteFuncionHorario(int id)
        {
            var funcionHorario = await _context.FuncionHorarios.FindAsync(id);
            if (funcionHorario == null)
            {
                return NotFound();
            }

            _context.FuncionHorarios.Remove(funcionHorario);
            await _context.SaveChangesAsync();

            return funcionHorario;
        }

        private bool FuncionHorarioExists(int id)
        {
            return _context.FuncionHorarios.Any(e => e.FuncionId == id);
        }
    }
}
