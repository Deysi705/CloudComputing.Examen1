using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class Inscripcion
    {
        public int Id { get; set; } //PK
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        //FK
        public int ParticipantesId { get; set; }

        // Relaciones
        public Evento? Eventos { get; set; }
        public Participante? Participantes { get; set; }
        public List<Pago>? Pagos { get; set; }

    }
}
