using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class HistorialCertificado
    {
        public int Id { get; set; } //PK
        public int ParticipanteId { get; set; }
        public int EventoId { get; set; }
        public int CertificadoId { get; set; }
        public int PagoId { get; set; }

        //Relaciones
        public Participante? Participantes { get; set; }
        public Evento? Eventos { get; set; }
        public Certificado? Certificados { get; set; }
        public Pago? Pagos { get; set; }

    }
}
