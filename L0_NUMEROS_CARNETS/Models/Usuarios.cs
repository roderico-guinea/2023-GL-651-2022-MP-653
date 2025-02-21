﻿using System.ComponentModel.DataAnnotations;

namespace L0_NUMEROS_CARNETS.Models
{
    public class Usuarios   {

        [Key]

        public int usuarioId { get; set; }

        public int rollId  { get; set; }
        public string? nombreUsuario { get; set; }
        public string? clave  { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        

    }
}
