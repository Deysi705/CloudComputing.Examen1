using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class EstadoInscripcion
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }

        // Relaciones
        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
