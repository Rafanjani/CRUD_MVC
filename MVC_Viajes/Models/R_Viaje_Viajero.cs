﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Viajes.Models
{
    public class R_Viaje_Viajero
    {
        public int Id { get; set; }

        public int Viajero { get; set; }

        public int Viaje { get; set; }

        public DateTime? Creado { get; set; }

        public DateTime? Modificado { get; set; }

        public DateTime? Eliminado { get; set; }
    }
}
