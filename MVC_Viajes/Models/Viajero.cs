using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Viajes.Models
{
    public class Viajero
    {
        public int Id { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Nombres { get; set; }
        
        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        public DateTime? Creado { get; set; }

        public DateTime? Modificado { get; set; }

        public DateTime? Eliminado { get; set; }
    }
}
