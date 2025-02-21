using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L0_NUMEROS_CARNETS.Models
{
    public class UsuariosDBContext : DbContext

    {
        public UsuariosDBContext(DbContextOptions<UsuariosDBContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}