using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabajo_Final_Desarro_Web.Models;


namespace Trabajo_Final_Desarro_Web.ViewModels
{
    public class DetalleAlquilerViewModel
    {
        public int Id { get; set; }
        public int CdId { get; set; }
        public CD CD { get; set; }
        public int AlquilerId { get; set; }
        public Alquiler Alquiler { get; set; }
        public int Dias_Prestamo { get; set; }
        public DateTime Fecha_Devolucion { get; set; }
    }
}
