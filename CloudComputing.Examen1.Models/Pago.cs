using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudComputing.Examen1.Models
{
    public class Pago
    {
        public int Id { get; set; } //PK
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoTransaccion { get; set; }

        //FK
        public int MedioPagoId { get; set; }
        public int InscripcionId { get; set; }
        public int EstadoPagoId { get; set; }

        // Relaciones
        public MedioPago? MedioPagos { get; set; }
        public EstadoPago? EstadoPagos { get; set; }
        public Inscripcion? Inscripciones { get; set; }
    }
}
