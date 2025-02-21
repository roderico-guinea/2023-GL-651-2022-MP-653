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
    public class UsuariosController : ControllerBase
    {
        private readonly BlogContext _context;

        public UsuariosController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        // PUT: api/Usuarios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId) return BadRequest();
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Usuarios/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/Usuarios/BuscarPorNombre?nombre=Juan&apellido=Perez
        [HttpGet("BuscarPorNombre")]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarPorNombre(string nombre, string apellido)
        {
            return await _context.Usuarios
                .Where(u => u.Nombre.Contains(nombre) && u.Apellido.Contains(apellido))
                .ToListAsync();
        }

        // GET: api/Usuarios/BuscarPorRol/{rolId}
        [HttpGet("BuscarPorRol/{rolId}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> BuscarPorRol(int rolId)
        {
            return await _context.Usuarios.Where(u => u.RolId == rolId).ToListAsync();
        }
    }
}