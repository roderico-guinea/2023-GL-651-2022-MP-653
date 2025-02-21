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
    public class ComentariosController : ControllerBase
    {
        private readonly BlogContext _context;

        public ComentariosController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Comentarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
            return await _context.Comentarios.ToListAsync();
        }

        // GET: api/Comentarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();
            return comentario;
        }

        // POST: api/Comentarios
        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.ComentarioId }, comentario);
        }

        // PUT: api/Comentarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.ComentarioId) return BadRequest();
            _context.Entry(comentario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Comentarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Comentarios/PorPublicacion/{publicacionId}
        [HttpGet("PorPublicacion/{publicacionId}")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentariosPorPublicacion(int publicacionId)
        {
            return await _context.Comentarios
                .Where(c => c.PublicacionId == publicacionId)
                .ToListAsync();
        }
    }
}
