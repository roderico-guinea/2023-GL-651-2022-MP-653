using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace L0_NUMEROS_CARNETS.Models
{
    public class Publicacion
    {
       
            [Key]
            public int PublicacionId { get; set; }

            [Required]
            [MaxLength(255)]
            public string Titulo { get; set; }

            [Required]
            public string Descripcion { get; set; }

            [ForeignKey("Usuario")]
            public int UsuarioId { get; set; }

            public Usuario Usuario { get; set; }
        
    }
}
