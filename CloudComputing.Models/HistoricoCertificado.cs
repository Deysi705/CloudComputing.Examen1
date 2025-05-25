using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputingExamen1.Models
{
    public class HistoricoCertificado
    {
        public int Id { get; set; } //PK
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
        public int CertificadoId { get; set; }
        public int PagoId { get; set; }

        //FK
        public int EventosId { get; set; }

        // Relaciones
        public Evento? Eventos { get; set; }

    }
}
