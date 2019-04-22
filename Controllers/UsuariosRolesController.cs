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
    public class UsuariosRolesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public UsuariosRolesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetUsuariosRoles()
        {
            return await _context.UsuariosRoles.ToListAsync();
        }

        // GET: api/UsuariosRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> GetUsuariosRoles(int id)
        {
            var usuarioRol = await _context.UsuariosRoles.FindAsync(id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        // POST: api/UsuariosRoles
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> PostUsuariosRoles(UsuarioRol usuarioRol)
        {
            _context.UsuariosRoles.Add(usuarioRol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuariosRoles", new { id = usuarioRol.Id }, usuarioRol);
        }

        // PUT: api/UsuariosRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosRoles(int id, UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosRolesExists(id))
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

        // DELETE: api/UsuariosRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioRol>> DeleteUsuariosRoles(int id)
        {
            var usuarioRol = await _context.UsuariosRoles.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            _context.UsuariosRoles.Remove(usuarioRol);
            await _context.SaveChangesAsync();

            return Ok(usuarioRol);
        }

        private bool UsuariosRolesExists(int id)
        {
            return _context.UsuariosRoles.Any(e => e.Id == id);
        }
    }
}
