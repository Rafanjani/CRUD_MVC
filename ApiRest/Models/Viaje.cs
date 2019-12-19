using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{
    [Table("t_viajes", Schema = "dbo")]
    public class Viaje
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }

        [Column("plazas")]
        public int Plazas { get; set; }

        [Column("destino")]
        public string Destino { get; set; }

        [Column("origen")]
        public string Origen { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("creado")]
        public DateTime? Creado { get; set; }

        [Column("modificado")]
        public DateTime? Modificado { get; set; }

        [Column("eliminado")]
        public DateTime? Eliminado { get; set; }
    }
}
