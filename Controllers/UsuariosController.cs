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
    public class UsuariosController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public UsuariosController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/View
        [HttpGet("View")]
        public async Task<ActionResult<IEnumerable<UsuariosRolesView>>> GetUsuariosRolesView()
        {
            return await _context.vwUsuariosRoles.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}", Name = "GetUsuarios")]
        public async Task<ActionResult<Usuario>> GetUsuarios([FromRoute]int id)
        {
            var usuario = await _context.Usuarios.Where(u => u.Id == id).SingleOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // GET: api/Usuarios/5/extended
        [HttpGet("{id}/extended")]
        public async Task<ActionResult<UsuarioExtended>> GetUsuarioExtended(int id)
        {
            // Retrieves Usuario
            var usuario = await _context.Usuarios.Where(x => x.Id == id).SingleOrDefaultAsync();
            
            if (usuario == null)
            {
                return NotFound();
            }

            // Retrieves Rol
            var usuarioExtended = new UsuarioExtended(usuario);
            usuarioExtended.Rol = await _context.UsuariosRoles.Where(r => r.Id == usuarioExtended.Rol.Id).SingleOrDefaultAsync();

            if (usuarioExtended.Rol.Id == 0)
            {
                return NotFound();
            }

            return Ok(usuarioExtended);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios([FromRoute]int id, [FromBody]Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuarios([FromBody]UsuarioPost usuarioPost)
        {
            var usuario = new Usuario();
            usuario.Nombre = usuarioPost.Nombre;
            usuario.Email = usuarioPost.Email;
            usuario.RolId = usuarioPost.RolId;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var newRecord = await _context.Usuarios.Where(u => u.Id == usuario.Id).SingleOrDefaultAsync();

            return Ok(newRecord);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuarios([FromRoute]int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
