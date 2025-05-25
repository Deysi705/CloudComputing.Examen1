using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class Ponente
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Especialidad { get; set; }
               
        // Relaciones
        public List<EventoPonente>? EventosPonentes { get; set; }
    }
}
