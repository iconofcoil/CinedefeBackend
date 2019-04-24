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
    public class CiudadesController : ControllerBase
    {
        private readonly CinedefeContext _context;

        public CiudadesController(CinedefeContext context)
        {
            _context = context;
        }

        // GET: api/Ciudades
        [HttpGet]
        public async Task<ActionResult<List<Ciudad>>> GetSucursalesCiudades()
        {
            var sucursales = await _context.Sucursales.ToListAsync();

            var sucursalesCiudad = sucursales.GroupBy(x => x.Ciudad).Select(x => x.FirstOrDefault());

            List<Ciudad> ciudades = new List<Ciudad>();

            foreach (Sucursal suc in sucursalesCiudad)
            {
                ciudades.Add(new Ciudad() { Nombre = suc.Ciudad });
            }

            return Ok(ciudades);
        }
    }
}