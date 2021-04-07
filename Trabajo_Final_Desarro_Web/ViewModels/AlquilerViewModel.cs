using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trabajo_Final_Desarro_Web.Models;

namespace Trabajo_Final_Desarro_Web.ViewModels
{
    public class AlquilerViewModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha_Alquiler { get; set; }
        public int Valor_Alquiler { get; set; }
    }
}
