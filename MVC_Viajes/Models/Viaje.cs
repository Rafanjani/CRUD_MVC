using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Viajes.Models
{
    public class Viaje
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public int Plazas { get; set; }

        public string Destino { get; set; }

        public string Origen { get; set; }

        public decimal Precio { get; set; }

        public DateTime? Creado { get; set; }

        public DateTime? Modificado { get; set; }

        public DateTime? Eliminado { get; set; }
    }
}
