using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trabajo_Final_Desarro_Web.Models
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha_Alquiler { get; set; }
        public int Valor_Alquiler { get; set; }

    
    }
}
