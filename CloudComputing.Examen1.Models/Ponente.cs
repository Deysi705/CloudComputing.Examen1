using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class Ponente
    {
        public int Id { get; set; } //PK
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        //FK
        public int EspecialidadId { get; set; }

        // Relaciones
        public Especialidad? Especialidades { get; set; }
        public List<Sesion>? Sesiones { get; set; }
    }
}
