using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Final_Desarro_Web.Models
{
    public class Sancion
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public string Tipo_Sancion{ get; set; }
        public int Nro_Dias_Sancion { get; set; }
               
    }
}
