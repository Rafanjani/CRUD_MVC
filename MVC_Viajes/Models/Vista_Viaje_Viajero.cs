using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Viajes.Models
{
    public class Vista_Viaje_Viajero
    {
        public Viajero Viajero { get; set; }
        public Viaje Viaje { get; set; }
        public int Id { get; set; }
    }
}
