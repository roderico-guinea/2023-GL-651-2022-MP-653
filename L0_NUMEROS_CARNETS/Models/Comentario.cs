using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L0_NUMEROS_CARNETS.Models
{
    public class Comentario
    {
        [Key]
        public int ComentarioId { get; set; }

        [ForeignKey("Publicacion")]
        public int PublicacionId { get; set; }

        public string Texto { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public Publicacion Publicacion { get; set; }
        public Usuario Usuario { get; set; }
    
}
}
