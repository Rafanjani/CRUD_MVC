using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    [Table("t_viajeros", Schema = "dbo")]
    public class Viajero
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("cedula")]
        public string Cedula { get; set; }

        [Column("nombres")]
        public string Nombres { get; set; }

        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("creado")]
        public DateTime? Creado { get; set; }

        [Column("modificado")]
        public DateTime? Modificado { get; set; }

        [Column("eliminado")]
        public DateTime? Eliminado { get; set; }
    }
}
