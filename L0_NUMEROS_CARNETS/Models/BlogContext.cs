using L0_NUMEROS_CARNETS.Models;
using Microsoft.EntityFrameworkCore;

namespace L01_NUMEROS_CARNETS.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Publicacion)
                .WithMany()
                .HasForeignKey(c => c.PublicacionId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
