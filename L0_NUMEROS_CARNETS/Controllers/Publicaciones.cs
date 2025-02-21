using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using L0_NUMEROS_CARNETS.Models;

namespace L01_NUMEROS_CARNETS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly BlogContext _context;

        public PublicacionesController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicaciones()
        {
            return await _context.Publicaciones.ToListAsync();
        }

        // GET: api/Publicaciones/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacion>> GetPublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null) return NotFound();
            return publicacion;
        }

        // POST: api/Publicaciones
        [HttpPost]
        public async Task<ActionResult<Publicacion>> PostPublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPublicacion), new { id = publicacion.PublicacionId }, publicacion);
        }

        // PUT: api/Publicaciones/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacion(int id, Publicacion publicacion)
        {
            if (id != publicacion.PublicacionId) return BadRequest();
            _context.Entry(publicacion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Publicaciones/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null) return NotFound();
            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Publicaciones/PorUsuario/{usuarioId}
        [HttpGet("PorUsuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicacionesPorUsuario(int usuarioId)
        {
            return await _context.Publicaciones
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
