using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class Inscripcion
    {
        public int Id { get; set; } //PK
        public DateTime Fecha { get; set; }

        //FK
        public int ParticipanteId { get; set; }
        public int TipoInscripcionId { get; set; }
        public int EstadoInscripcionId { get; set; }
        public int EventoId { get; set; }

        // Relaciones
        public Evento? Eventos { get; set; }
        public EstadoInscripcion? EstadoInscripciones { get; set; }
        public TipoInscripcion? TipoInscripciones { get; set; }
        public Participante? Participantes { get; set; }
        public List<Pago>? Pagos { get; set; }
    }
}
