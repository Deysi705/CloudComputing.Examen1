using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class Evento
    {
        public int Id { get; set; } //PK
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }

        //FK
        public int TipoEventosId { get; set; }

        // Relaciones
        public TipoEvento? TipoEventos { get; set; }
        public List<Sesion>? Sesiones { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
        public List<Certificado>? Certificados { get; set; }

    }
}
