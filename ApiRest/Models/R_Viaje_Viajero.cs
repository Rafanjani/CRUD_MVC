using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Models
{

    [Table("r_viajero_viaje", Schema = "dbo")]
    public class R_Viaje_Viajero
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("viajero")]
        public int Viajero { get; set; }

        [Column("viaje")]
        public int Viaje { get; set; }

        [Column("creado")]
        public DateTime? Creado { get; set; }

        [Column("modificado")]
        public DateTime? Modificado { get; set; }

        [Column("eliminado")]
        public DateTime? Eliminado { get; set; }
    }
}
