using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trabajo_Final_Desarro_Web.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Email { get; set; }
        public string Nro_DNI { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public DateTime Fecha_Inscripcion { get; set; }
        public string Tema_Interes { get; set; }
        public string Estado { get; set; }
    }
}
