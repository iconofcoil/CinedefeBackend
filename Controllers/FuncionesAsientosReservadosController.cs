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
    public class FuncionesAsientosReservadosController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public FuncionesAsientosReservadosController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/FuncionesAsientosReservados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionAsientosReservados>>> GetFuncionesAsientosReservados()
        {
            return await _context.FuncionesAsientosReservados.ToListAsync();
        }

        // GET: api/FuncionesAsientosReservados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionAsientosReservados>> GetFuncionesAsientosReservados(int id)
        {
            var funcionesasientosreservados = await _context.FuncionesAsientosReservados.FindAsync(id);

            if (funcionesasientosreservados == null)
            {
                return NotFound();
            }

            return funcionesasientosreservados;
        }

        // PUT: api/FuncionesAsientosReservados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionesAsientosReservados(int id, FuncionAsientosReservados funcionesasientosreservados)
        {
            if (id != funcionesasientosreservados.FuncionId)
            {
                return BadRequest();
            }

            _context.Entry(funcionesasientosreservados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionesAsientosReservadosExists(id))
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

        // POST: api/FuncionesAsientosReservados
        [HttpPost]
        public async Task<ActionResult<FuncionAsientosReservados>> PostFuncionesAsientosReservados(FuncionAsientosReservados funcionesasientosreservados)
        {
            _context.FuncionesAsientosReservados.Add(funcionesasientosreservados);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuncionesAsientosReservadosExists(funcionesasientosreservados.FuncionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuncionesAsientosReservados", new { id = funcionesasientosreservados.FuncionId }, funcionesasientosreservados);
        }

        // DELETE: api/FuncionesAsientosReservados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionAsientosReservados>> DeleteFuncionesAsientosReservados(int id)
        {
            var funcionesasientosreservados = await _context.FuncionesAsientosReservados.FindAsync(id);
            if (funcionesasientosreservados == null)
            {
                return NotFound();
            }

            _context.FuncionesAsientosReservados.Remove(funcionesasientosreservados);
            await _context.SaveChangesAsync();

            return funcionesasientosreservados;
        }

        private bool FuncionesAsientosReservadosExists(int id)
        {
            return _context.FuncionesAsientosReservados.Any(e => e.FuncionId == id);
        }
    }
}
